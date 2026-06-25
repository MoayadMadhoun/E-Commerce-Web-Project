using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using MyStore.Repository;

namespace MyStore.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly CategoryRepository _categoryRepository;

        public IndexModel(CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }
        public List<Category> categoriesList { get; set; }
        public async Task OnGet()
        {
            categoriesList = await _categoryRepository.GetAllAsync();
        }
    }
}
