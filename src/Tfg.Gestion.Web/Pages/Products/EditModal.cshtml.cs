using System;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tfg.Gestion.Products;

namespace Tfg.Gestion.Web.Pages.Products
{
    public class EditModalModel : GestionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateProductDto Product { get; set; }

        private readonly IProductAppService _productAppService;

        public EditModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public async Task OnGetAsync()
        {
            var productDto = await _productAppService.GetAsync(Id);
            Product = ObjectMapper.Map<ProductDto, CreateUpdateProductDto>(productDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.UpdateAsync(Id, Product);
            return NoContent();
        }
    }
}
