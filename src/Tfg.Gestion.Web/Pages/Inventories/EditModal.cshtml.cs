using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using Tfg.Gestion.Inventories;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tfg.Gestion.Web.Pages.Inventories
{
    public class EditModalModel : GestionPageModel
    {
        [BindProperty]
        public EditInventoryViewModel Inventory { get; set; }
        public List<SelectListItem> RawMaterials { get; set; }

        private readonly IInventoryAppService _inventoryAppService;

        public EditModalModel(IInventoryAppService inventoryAppService)
        {
            _inventoryAppService = inventoryAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var inventoryDto = await _inventoryAppService.GetAsync(id);
            Inventory = ObjectMapper.Map<InventoryDto, EditInventoryViewModel>(inventoryDto);

            var rawMaterialLookup = await _inventoryAppService.GetRawMaterialLookupAsync();
            RawMaterials = rawMaterialLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _inventoryAppService.UpdateAsync(
                Inventory.Id,
                ObjectMapper.Map<EditInventoryViewModel, CreateUpdateInventoryDto>(Inventory)
            );

            return NoContent();
        }

        public class EditInventoryViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [HiddenInput]
            public Guid RawMaterialId { get; set; }

            [Required]
            public int StockQuantity { get; set; } = 0;

        }
    }
}
