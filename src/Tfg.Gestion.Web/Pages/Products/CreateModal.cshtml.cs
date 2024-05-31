using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Tfg.Gestion.Products;

namespace Tfg.Gestion.Web.Pages.Products
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateUpdateProductDto Product { get; set; }

        private readonly IProductAppService _productAppService;

        public CreateModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }
        public void OnGet()
        {
            Product = new CreateUpdateProductDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.CreateAsync(Product);
            
            return NoContent();
        }
    }
}
