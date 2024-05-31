using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Tfg.Gestion.Dishes;

namespace Tfg.Gestion.Web.Pages.Dishes
{
    public class EditModalModel : GestionPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        [BindProperty]
        public CreateUpdateDishDto Dish { get; set; }

        private readonly IDishAppService _dishAppService;

        public EditModalModel(IDishAppService DishAppService)
        {
            _dishAppService = DishAppService;
        }

        public async Task OnGetAsync()
        {
            var DishDto = await _dishAppService.GetAsync(Id);
            Dish = ObjectMapper.Map<DishDto, CreateUpdateDishDto>(DishDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _dishAppService.UpdateAsync(Id, Dish);
            return NoContent();
        }
    }
}
