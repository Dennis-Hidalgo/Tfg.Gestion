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
using Tfg.Gestion.RawMaterials;
using Tfg.Gestion.Inventories;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Tfg.Gestion.Web.Pages.Inventories
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateInventoryViewModel Inventory { get; set; }

        public List<SelectListItem> RawMaterials { get; set; }


        private readonly IInventoryAppService _inventoryAppService;
        private readonly IRepository<RawMaterial, Guid> _rawMaterialRepository;

        public CreateModalModel(
            IInventoryAppService inventoryAppService,
            IRepository<RawMaterial, Guid> rawMaterialRepository)
        {
            _inventoryAppService = inventoryAppService;
            _rawMaterialRepository = rawMaterialRepository;
        }

        public async Task OnGetAsync()
        {
            Inventory = new CreateInventoryViewModel();
            var rawMaterialLookup = await _inventoryAppService.GetRawMaterialLookupAsync();
            RawMaterials = rawMaterialLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var datos = await _inventoryAppService.CreateAsync(
            ObjectMapper.Map<CreateInventoryViewModel, CreateUpdateInventoryDto>(Inventory)
            );
            string hola = "hola";
            await _inventoryAppService.CreateAsync(
            ObjectMapper.Map<CreateInventoryViewModel, CreateUpdateInventoryDto>(Inventory)
            );
            return NoContent();
        }

        public class CreateInventoryViewModel
        {
            [SelectItems(nameof(RawMaterials))]
            [DisplayName("Product Provider")]
            public Guid RawMaterialId { get; set; }

            [Required]
            [StringLength(128)]
            public int StockQuantity { get; set; }

        }
    }
}
