using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using Tfg.Gestion.Orders;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tfg.Gestion.Web.Pages.Orders
{
    public class EditModalModel : GestionPageModel
    {
        [BindProperty]
        public EditOrderViewModel Order { get; set; }
        public List<SelectListItem> Customers { get; set; }

        private readonly IOrderAppService _orderAppService;

        public EditModalModel(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var orderDto = await _orderAppService.GetAsync(id);
            Order = ObjectMapper.Map<OrderDto, EditOrderViewModel>(orderDto);

            var customerLookup = await _orderAppService.GetCustomerLookupAsync();
            Customers = customerLookup.Items
                .Select(x => new SelectListItem(x.FirstName, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _orderAppService.UpdateAsync(
                Order.Id,
                ObjectMapper.Map<EditOrderViewModel, CreateUpdateOrderDto>(Order)
            );

            return NoContent();
        }

        public class EditOrderViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [HiddenInput]
            public Guid CustomerId { get; set; }

            [Required]
            [HiddenInput]
            public Guid UserId { get; set; }

            [Required]
            public string OrderStatus { get; set; }
        }
    }
}
