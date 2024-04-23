using Microsoft.AspNetCore.Components;
using Tangy_Models;

namespace TangyWeb_Server.Pages.Category
{
    public partial class CategoryUpsert
    {

        [Parameter]
        public int Id { get; set; }

        private CategoryDTO Category { get; set; } = new CategoryDTO();
        private string Title { get; set; } = "Create";

        public bool IsLoading { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                if (Id == 0)
                {
                    //create
                    IsLoading = false;
                }
                else
                {
                    //update
                    Title = "Update";
                    await LoadCategory();
                }
            }


        }

        private async Task LoadCategory()
        {
            IsLoading = true;
            StateHasChanged();
            Category = await _categoryRepository.Get(Id);
            IsLoading = false;
            StateHasChanged();
        }

        private async Task UpsertCategory()
        {
            if (Category.Id == 0)
            {
                //create
                await _categoryRepository.Create(Category);

            }
            else
            {
                //update
                await _categoryRepository.Update(Category);

            }
            _navigationManager.NavigateTo("/category");


        }
    }
}
