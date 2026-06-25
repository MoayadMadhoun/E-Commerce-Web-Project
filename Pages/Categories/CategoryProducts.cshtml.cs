using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using MyStore.Repository;

namespace MyStore.Pages.Categories
{
    public class CategoryProductsModel : PageModel
    {
        private readonly CategoryRepository _categoryRepository;

        public CategoryProductsModel(CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public List<Product> Products { get; set; }
     
        public async Task OnGet(int catId)
        {
            Products = await _categoryRepository.GetAllCategoryProductsAsync(catId);
        }
    }
}
