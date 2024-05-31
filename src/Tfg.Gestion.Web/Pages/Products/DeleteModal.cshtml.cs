using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tfg.Gestion.Products;

namespace Tfg.Gestion.Web.Pages.Products
{
    public class DeleteModalModel : GestionPageModel
    {
        [BindProperty]
        public Guid ProductId { get; set; }
        public CreateUpdateProductDto Product { get; set; }

        private readonly IProductAppService _productAppService;

        public DeleteModalModel(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public void OnGet(Guid id)
        {
            ProductId = id;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _productAppService.DeleteAsync(ProductId);
            return NoContent();
        }
    }
}
