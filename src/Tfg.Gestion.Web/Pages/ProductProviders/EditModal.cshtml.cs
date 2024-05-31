using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Tfg.Gestion.ProductProviders;

namespace Tfg.Gestion.Web.Pages.ProductProviders
{
    public class EditModalModel : GestionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateProductProviderDto ProductProvider { get; set; }

        private readonly IProductProviderAppService _ProductProviderAppService;

        public EditModalModel(IProductProviderAppService ProductProviderAppService)
        {
            _ProductProviderAppService = ProductProviderAppService;
        }

        public async Task OnGetAsync()
        {
            var ProductProviderDto = await _ProductProviderAppService.GetAsync(Id);
            ProductProvider = ObjectMapper.Map<ProductProviderDto, CreateUpdateProductProviderDto>(ProductProviderDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _ProductProviderAppService.UpdateAsync(Id, ProductProvider);
            return NoContent();
        }
    }
}
