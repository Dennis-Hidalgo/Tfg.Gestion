using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Tfg.Gestion.ProductProviders;

namespace Tfg.Gestion.Web.Pages.ProductProviders
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateUpdateProductProviderDto ProductProvider { get; set; }

        private readonly IProductProviderAppService _productProviderAppService;

        public CreateModalModel(IProductProviderAppService productProviderAppService)
        {
            _productProviderAppService = productProviderAppService;
        }
        public void OnGet()
        {
            ProductProvider = new CreateUpdateProductProviderDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productProviderAppService.CreateAsync(ProductProvider);

            return NoContent();
        }
    }
}
