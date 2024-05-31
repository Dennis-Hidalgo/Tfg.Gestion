using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tfg.Gestion.Invoices;
using Tfg.Gestion.Orders;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Web.Pages.Invoices
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateInvoiceViewModel Invoice { get; set; }

        public List<SelectListItem> Orders { get; set; }


        private readonly IInvoiceAppService _invoiceAppService;
        private readonly IRepository<Order, Guid> _orderRepository;

        public CreateModalModel(
            IInvoiceAppService invoiceAppService,
            IRepository<Order, Guid> orderRepository)
        {
            _invoiceAppService = invoiceAppService;
            _orderRepository = orderRepository;
        }

        public async Task OnGetAsync()
        {
            Invoice = new CreateInvoiceViewModel();
            var orderLookup = await _invoiceAppService.GetOrderLookupAsync();
            Orders = orderLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _invoiceAppService.CreateAsync(
            ObjectMapper.Map<CreateInvoiceViewModel, CreateUpdateInvoiceDto>(Invoice)
            );
            return NoContent();
        }

        public class CreateInvoiceViewModel
        {
            [SelectItems(nameof(Orders))]
            [DisplayName("OrderId")]
            public Guid OrderId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; } = string.Empty;

            [Required]
            public string Description { get; set; } = string.Empty;

            [Required]
            public decimal PricePerUnit { get; set; }

            [Required]
            public int StockQuantity { get; set; }
        }
    }
}
