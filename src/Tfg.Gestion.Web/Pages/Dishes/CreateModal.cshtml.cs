using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Tfg.Gestion.Dishes;

namespace Tfg.Gestion.Web.Pages.Dishes
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateUpdateDishDto Dish { get; set; }

        private readonly IDishAppService _dishAppService;

        public CreateModalModel(IDishAppService dishAppService)
        {
            _dishAppService = dishAppService;
        }
        public void OnGet()
        {
            Dish = new CreateUpdateDishDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _dishAppService.CreateAsync(Dish);

            return NoContent();
        }
    }
}
