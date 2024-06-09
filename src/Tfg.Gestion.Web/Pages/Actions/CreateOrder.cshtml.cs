using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Dishes;
using Tfg.Gestion.Orders;
using Volo.Abp.Domain.Repositories;

namespace Tfg.Gestion.Web.Pages.Actions
{
    public class CreateOrderModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
