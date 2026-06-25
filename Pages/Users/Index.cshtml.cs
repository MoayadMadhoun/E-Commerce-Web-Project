using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyStore.Data;
using MyStore.Models;

namespace MyStore.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;

        public IndexModel(AppDbContext context)
        {
            _context = context;
        }

        //  Search
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //  Pagination
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;

        public int TotalPages { get; set; }

        public List<AppUser> Users { get; set; }

        //  Selected Users
        [BindProperty]
        public List<string> SelectedUserIds { get; set; }

        private void LoadUsers()
        {
            var query = _context.Users.AsQueryable();

            //  Filter by Email
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                query = query.Where(u => u.Email.Contains(SearchTerm));
            }

            //  Total pages
            var totalItems = query.Count();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            //  Fix page index
            if (PageIndex < 1)
                PageIndex = 1;

            if (PageIndex > TotalPages && TotalPages > 0)
                PageIndex = TotalPages;

            //  Pagination
            Users = query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public void OnGet()
        {
            LoadUsers();
        }

        public IActionResult OnPost()
        {
            if (SelectedUserIds == null || !SelectedUserIds.Any())
            {
                ModelState.AddModelError(string.Empty, "Please select at least one user.");
                LoadUsers();
                return Page();
            }

            // send data by temp data 
            TempData["SelectedUserIds"] = string.Join(",", SelectedUserIds);

            return RedirectToPage("/Users/SendEmail");
        }
    }
}