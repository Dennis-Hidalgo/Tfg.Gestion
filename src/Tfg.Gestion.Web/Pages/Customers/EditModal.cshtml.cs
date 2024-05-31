using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;

namespace Tfg.Gestion.Web.Pages.Customers
{
    public class EditModalModel : GestionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }

        private readonly ICustomerAppService _customerAppService;

        public EditModalModel(ICustomerAppService CustomerAppService)
        {
            _customerAppService = CustomerAppService;
        }

        public async Task OnGetAsync()
        {
            var CustomerDto = await _customerAppService.GetAsync(Id);
            Customer = ObjectMapper.Map<CustomerDto, CreateUpdateCustomerDto>(CustomerDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.UpdateAsync(Id, Customer);
            return NoContent();
        }
    }
}
