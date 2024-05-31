using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Tfg.Gestion.Customers;

namespace Tfg.Gestion.Web.Pages.Customers
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateUpdateCustomerDto Customer { get; set; }

        private readonly ICustomerAppService _customerAppService;

        public CreateModalModel(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public void OnGet()
        {
            Customer = new CreateUpdateCustomerDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _customerAppService.CreateAsync(Customer);

            return NoContent();
        }
    }
}
