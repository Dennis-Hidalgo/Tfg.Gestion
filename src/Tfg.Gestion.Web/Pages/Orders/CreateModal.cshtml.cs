using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Orders;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace Tfg.Gestion.Web.Pages.Orders
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateOrderViewModel Order { get; set; }

        public List<SelectListItem> Customers { get; set; }


        private readonly IOrderAppService _orderAppService;
        private readonly IRepository<Customer, Guid> _customerRepository;
        private readonly ICurrentUser _currentUserRepository;

        public CreateModalModel(
            IOrderAppService orderAppService,
            IRepository<Customer, Guid> customerRepository,
            ICurrentUser currentUserRepository)
        {
            _orderAppService = orderAppService;
            _customerRepository = customerRepository;
            _currentUserRepository = currentUserRepository;
        }

        public async Task OnGetAsync()
        {
            Order = new CreateOrderViewModel();
            var customerLookup = await _orderAppService.GetCustomerLookupAsync();
            Customers = customerLookup.Items.Select(x => new SelectListItem(x.FirstName, x.Id.ToString()))
            .ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _orderAppService.CreateAsync(
            ObjectMapper.Map<CreateOrderViewModel, CreateUpdateOrderDto>(Order)
            );

            return NoContent();
        }

        public class CreateOrderViewModel
        {
            [SelectItems(nameof(Customers))]
            [DisplayName("Customers")]
            public Guid CustomerId { get; set; }

            [Required]
            public string OrderStatus { get; set; }

        }
    }
}
