using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyStore.Extention;
using MyStore.Models;
using MyStore.Repository;
using StartASP.Repositories;

namespace MyStore.Pages.Products
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _productRepo;
        private readonly CategoryRepository _categoryRepository;

        public PaginatedList<Product> Products { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? CategoryId { get; set; }

        //sorting routing variables
        [BindProperty(SupportsGet = true)]
        public string SortField { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        public SelectList Categories { get; set; }



        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } =1;
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 2;


        public IndexModel(ProductRepository productRepo, CategoryRepository categoryRepository)
        {
            this._productRepo = productRepo;
            this._categoryRepository = categoryRepository;
        }
        public async Task OnGet()
        {
            Categories = new SelectList(await _categoryRepository.GetAllAsync(), "CategoryId", "Name");
            var query = _productRepo.GetAllQueryable();

            if (!string.IsNullOrEmpty(SearchTerm))
            {
                //query = query.Where(p => p.Name.Contains(SearchTerm));
                query = query.Where(p => EF.Functions.Like(p.Name, $"%{SearchTerm}%"));
            }
            if (CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == CategoryId);
            }

            //apply sort
            //switch (SortOrder)
            //{
            //    case "Name":
            //        query = query.OrderBy(p => p.Name);
            //        break;
            //    case "Name_desc":
            //        query = query.OrderByDescending(p => p.Name);
            //        break;
            //    case "Prices":
            //        query = query.OrderBy(p => p.Price);
            //        break;
            //    case "Prices_desc":
            //        query = query.OrderByDescending(p => p.Price);
            //        break;
            //    default:
            //        query = query.OrderBy(p => p.ProductId);
            //        break;
            //}

            string sorder = "";
            if (SortOrder!=null && SortOrder.Contains("_")) sorder = "desc";

            query = query.ApplySorting(SortField, sorder);

            //Products = await query.ToListAsync();
            Products = await PaginatedList<Product>.CreateAsync(query, PageIndex, PageSize);
        }
    }
}
