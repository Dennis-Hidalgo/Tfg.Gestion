using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Tfg.Gestion.Invoices;

namespace Tfg.Gestion.Web.Pages.Invoices
{
    public class EditModalModel : GestionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateInvoiceDto Invoice { get; set; }

        private readonly IInvoiceAppService _InvoiceAppService;

        public EditModalModel(IInvoiceAppService InvoiceAppService)
        {
            _InvoiceAppService = InvoiceAppService;
        }

        public async Task OnGetAsync()
        {
            var InvoiceDto = await _InvoiceAppService.GetAsync(Id);
            Invoice = ObjectMapper.Map<InvoiceDto, CreateUpdateInvoiceDto>(InvoiceDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _InvoiceAppService.UpdateAsync(Id, Invoice);
            return NoContent();
        }
    }
}
