using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Tangy_Models;
using TangyWeb_Server.Helper;

namespace TangyWeb_Server.Pages.Product
{
    public partial class ProductUpsert
    {
        private const long MaxFileSize = 2 * 1024 * 1024;
        [Parameter]
        public int Id { get; set; }

        private ProductDTO Product { get; set; } = new()
        {
            ImageUrl = "/images/default.png"
        };
        private IEnumerable<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        private string Title { get; set; } = "Create";

        public bool IsLoading { get; set; }
        public string OldImageUrl { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadProduct();
            }


        }

        private async Task LoadProduct()
        {
            IsLoading = true;
            StateHasChanged();
            Categories = await _categoryRepository.GetAll();

            if (Id != 0)
            {
                //update
                Title = "Update";
                Product = await _productRepository.Get(Id);
                OldImageUrl = Product.ImageUrl;
            }


            IsLoading = false;
            StateHasChanged();
        }

        private async Task UpsertProduct()
        {
            if (Product.Id == 0)
            {
                //create
                await _productRepository.Create(Product);
                await _jsRuntime.ToastrSuccess("Product Created Successfully");

            }
            else
            {
                //update
                if (OldImageUrl != Product.ImageUrl)
                {
                    _fileUpload.DeleteFile(OldImageUrl);
                }
                await _productRepository.Update(Product);
                await _jsRuntime.ToastrSuccess("Product Updated Successfully");

            }
            _navigationManager.NavigateTo("/product");


        }

        private async Task HandleImageUpload(InputFileChangeEventArgs e)
        {
            IsLoading = true;
            try
            {
                if (e.GetMultipleFiles().Count > 0)
                {
                    foreach (var file in e.GetMultipleFiles())
                    {
                        // Check if the file size exceeds the maximum allowed size
                        if (file.Size > MaxFileSize)
                        {
                            await _jsRuntime.ToastrFailure("File size exceeds the maximum limit of 20 MB");
                            return;
                        }

                        System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.Name);
                        if (fileInfo.Extension.ToLower() == ".jpg" ||
                            fileInfo.Extension.ToLower() == ".png" ||
                            fileInfo.Extension.ToLower() == ".jpeg")
                        {
                            Product.ImageUrl = await _fileUpload.UploadFile(file);
                        }
                        else
                        {
                            await _jsRuntime.ToastrFailure("Please select .jpg/ .jpeg/ .png file only");
                            return;
                        }
                    }
                }
                IsLoading = false;
            }
            catch (Exception ex)
            {
                await _jsRuntime.ToastrFailure(ex.Message);
            }
        }




        
    }
}

// private async Task HandleImageUpload(InputFileChangeEventArgs e)
// {
//     IsLoading = true;
//     try
//     {
//         if (e.GetMultipleFiles().Count > 0)
//         {
//             foreach (var file in e.GetMultipleFiles())
//             {
//                 // Check file size
//                 if (file.Size > 2097152) // 1MB
//                 {
//                     await _jsRuntime.ToastrFailure("File size exceeds the limit of 1MB");
//                     return;
//                 }

//                 System.IO.FileInfo fileInfo = new System.IO.FileInfo(file.Name);
//                 if (fileInfo.Extension.ToLower() == ".jpg" ||
//                     fileInfo.Extension.ToLower() == ".png" ||
//                     fileInfo.Extension.ToLower() == ".jpeg")
//                 {
//                     Product.ImageUrl = await _fileUpload.UploadFile(file);
//                 }
//                 else
//                 {
//                     await _jsRuntime.ToastrFailure("Please select .jpg/ .jpeg/ .png file only");
//                     return;
//                 }
//             }
//         }
//     }
//     catch (Exception ex)
//     {
//         // Handle exception
//     }
//     finally
//     {
//         IsLoading = false;
//     }
// }