using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Models;
using MyStore.Repository;
using StartASP.Repositories;

namespace MyStore.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly CategoryRepository _categoryRepository;

        public DeleteModel(CategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        public Category category { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int id)
        {
            category = await _categoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound();
            }

            await _categoryRepository.DeleteAsync(id);

            return RedirectToPage("Index");

        }
    }
}
