using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Threading.Tasks;
using Tfg.Gestion.RawMaterials;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tfg.Gestion.Web.Pages.RawMaterials
{
    public class EditModalModel : GestionPageModel
    {
        [BindProperty]
        public EditRawMaterialViewModel RawMaterial { get; set; }
        public List<SelectListItem> ProductProviders { get; set; }

        private readonly IRawMaterialAppService _rawMaterialAppService;

        public EditModalModel(IRawMaterialAppService rawMaterialAppService)
        {
            _rawMaterialAppService = rawMaterialAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var rawMaterialDto = await _rawMaterialAppService.GetAsync(id);
            RawMaterial = ObjectMapper.Map<RawMaterialDto, EditRawMaterialViewModel>(rawMaterialDto);

            var productProviderLookup = await _rawMaterialAppService.GetProductProviderLookupAsync();
            ProductProviders = productProviderLookup.Items
                .Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _rawMaterialAppService.UpdateAsync(
                RawMaterial.Id,
                ObjectMapper.Map<EditRawMaterialViewModel, CreateUpdateRawMaterialDto>(RawMaterial)
            );

            return NoContent();
        }

        public class EditRawMaterialViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [SelectItems(nameof(ProductProviders))]
            [DisplayName("Product Provider")]
            public Guid ProductProviderId { get; set; }

            [Required]
            [StringLength(128)]
            public string Name { get; set; } = string.Empty;

            [Required]
            public string Description { get; set; } = string.Empty;
        }
    }
}
