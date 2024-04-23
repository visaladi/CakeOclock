using Microsoft.JSInterop;
using Tangy_Models;

namespace TangyWeb_Server.Pages.Category
{
    public partial class CategoryList
    {
        private IEnumerable<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
        public bool IsLoading { get; set; }
        private int DeleteCategoryId { get; set; } = 0;



        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadCategories();
            }
        }

        private async Task LoadCategories()
        {
            IsLoading = true;
            StateHasChanged();
            Categories = await _categoryRepository.GetAll();
            IsLoading = false;
            StateHasChanged();
        }

        private void HandleDelete(int id)
        {
            DeleteCategoryId = id;
            _jsRuntime.InvokeVoidAsync("ShowDeleteConfiremationModel");
        }

        public async Task ConfirmDeleteClick(bool isConfirmed)
        {
            IsLoading = true;
            if (isConfirmed && DeleteCategoryId != 0)
            {
                //delete
                //await Task.Delay(5000);
                await _categoryRepository.Delete(DeleteCategoryId);
                await LoadCategories(); ;
                await _jsRuntime.InvokeVoidAsync("HideDeleteConfiremationModel");
            }
            IsLoading = false;
        }
    }
}
