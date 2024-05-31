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
using Tfg.Gestion.ProductProviders;
using Tfg.Gestion.RawMaterials;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Tfg.Gestion.Web.Pages.RawMaterials
{
    public class CreateModalModel : GestionPageModel
    {
        [BindProperty]
        public CreateRawMaterialViewModel RawMaterial { get; set; }

        public List<SelectListItem> ProductProviders { get; set; }


        private readonly IRawMaterialAppService _rawMaterialAppService;
        private readonly IRepository<ProductProvider, Guid> _productProviderRepository;

        public CreateModalModel(
            IRawMaterialAppService rawMaterialAppService,
            IRepository<ProductProvider, Guid> productProviderRepository)
        {
            _rawMaterialAppService = rawMaterialAppService;
            _productProviderRepository = productProviderRepository;
        }

        public async Task OnGetAsync()
        {
            RawMaterial = new CreateRawMaterialViewModel();
            var productProviderLookup = await _rawMaterialAppService.GetProductProviderLookupAsync();
            ProductProviders = productProviderLookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
            .ToList();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _rawMaterialAppService.CreateAsync(
            ObjectMapper.Map<CreateRawMaterialViewModel, CreateUpdateRawMaterialDto>(RawMaterial)
            );
            return NoContent();
        }

        public class CreateRawMaterialViewModel
        {
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
