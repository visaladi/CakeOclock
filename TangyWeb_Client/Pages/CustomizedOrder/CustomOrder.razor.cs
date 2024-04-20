using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Tangy_Common;
using Tangy_Models;
using TangyWeb_Client.Helper;
using TangyWeb_Client.ViewModels;

namespace TangyWeb_Client.Pages.CustomizedOrder
{
    public partial class CustomOrder
    {
        private OrderDTO Order { get; set; } = null;
        public bool IsProcessing { get; set; } = false;
        private IEnumerable<ProductDTO> Products { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsProcessing = true;

            List<ShoppingCart> cart = await _localStorage.GetItemAsync<List<ShoppingCart>>(SD.ShoppingCart);
            if (cart == null)
            {
                cart = new List<ShoppingCart>();
            }
            Products = await _productService.GetAll();

            Order = new()
            {
                OrderHeader = new()
                {

                    OrderTotal = 0,
                    Status = SD.Status_Pending

                },
                OrderDetails = new List<OrderDetailDTO>()
            };

            foreach (var item in cart)
            {
                ProductDTO product = Products?.FirstOrDefault(u => u.Id == item.ProductId);
                ProductPriceDTO productPrice = product?.ProductPrices?.FirstOrDefault(u => u.Id == item.ProductPriceId);

                if (product != null && productPrice != null)
                {
                    OrderDetailDTO orderDetailDTO = new()
                    {
                        ProductId = item.ProductId,
                        Size = productPrice.Size,
                        Count = item.Count,
                        Price = productPrice.Price,
                        ProductName = product.Name,
                        Product = product,
                    };

                    Order.OrderDetails.Add(orderDetailDTO);
                    Order.OrderHeader.OrderTotal += (item.Count * productPrice.Price);
                }
            }


            if (await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails) != null)
            {
                var userInfo = await _localStorage.GetItemAsync<UserDTO>(SD.Local_UserDetails);
                Order.OrderHeader.UserId = userInfo.Id;
                Order.OrderHeader.Name = userInfo.Name;
                Order.OrderHeader.Email = userInfo.Email;
                Order.OrderHeader.PhoneNumber = userInfo.PhoneNumber;

            }

            IsProcessing = false;
        }

        private async Task ConfirmOrderNow()
        {
            try
            {
                IsProcessing = true;


                // Update the order details or any other logic as needed
                Order.OrderHeader.Status = SD.Status_Pending;

                // Create a DTO to represent the order details if needed
                var orderDTO = new OrderDTO
                {
                    OrderHeader = Order.OrderHeader,
                    OrderDetails = Order.OrderDetails.ToList() // Make a copy if needed
                };

                var result = await _orderService.Make(orderDTO);

                await _localStorage.SetItemAsync(SD.Local_OrderDetails, result);

                // Additional logic if needed after confirming the order directly

                if (result.OrderHeader != null || result.OrderDetails != null)
                {
                    await _jsRuntime.ToastrSuccess("Order Placed successfully");
                    _navigationManager.NavigateTo("/orderconfirmation");
                }
                else
                {
                    await _jsRuntime.ToastrFailure("Faild to Place the Order! Please fill the nessary information...!");
                }
            }
            catch (Exception e)
            {
                await _jsRuntime.ToastrFailure(e.Message);
            }
            finally
            {
                IsProcessing = false;
            }
        }

        private async Task HandleCheckout()
        {
            try
            {
                IsProcessing = true;
                var paymentDto = new StripePaymentDTO()
                {
                    Order = Order
                };

                var result = await _paymentService.Checkout(paymentDto);

                Order.OrderHeader.SessionId = result.Data.ToString();

                var orderDTOSaved = await _orderService.Create(paymentDto);

                //     var StripeSessionAndPI = result.Data.ToString().Split(';');

                //     Order.OrderHeader.SessionId = StripeSessionAndPI[0];
                //     Order.OrderHeader.PaymentIntentId = StripeSessionAndPI[1];

                //

                await _localStorage.SetItemAsync(SD.Local_OrderDetails, orderDTOSaved);

                await _jsRuntime.InvokeVoidAsync("redirectToCheckout", result.Data.ToString());
            }
            catch (Exception e)
            {
                await _jsRuntime.ToastrFailure(e.Message);
            }
        }

        private int maxAllowedFiles = int.MaxValue;
        private long maxFileSize = long.MaxValue;
        private List<string> fileNames = new();
        private List<UploadResultDTO> uploadResults = new();

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            using var content = new MultipartFormDataContent();

            foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
            {
                var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

                fileNames.Add(file.Name);

                content.Add(
                    content: fileContent,
                    name: "\"files\"",

                    fileName: file.Name);
            }

            var response = await Http.PostAsync("/api/File", content);
            var newUploadResults = await response.Content.ReadFromJsonAsync<List<UploadResultDTO>>();

            if (newUploadResults is not null)
            {
                uploadResults = uploadResults.Concat(newUploadResults).ToList();
            }
        }

        private string? GetStoredFileName(string fileName)
        {
            var uploadResult = uploadResults.SingleOrDefault(f => f.FileName == fileName);
            if (uploadResult is not null)
                return uploadResult.StoredFileName;

            return "File not found.";
        }

        private async Task DownloadFile(string storedFileName, string originalFileName)
        {
            var response = await Http.GetAsync($"/api/File/{storedFileName}");

            if (!response.IsSuccessStatusCode)
            {
                await _jsRuntime.InvokeVoidAsync("alert", "File not found.");
            }
            else
            {
                var fileStream = response.Content.ReadAsStream();
                using var streamRef = new DotNetStreamReference(stream: fileStream);
                await _jsRuntime.InvokeVoidAsync("downloadFileFromStream", originalFileName, streamRef);
            }
        }
    }
}
