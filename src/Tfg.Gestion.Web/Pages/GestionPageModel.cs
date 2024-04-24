using Tfg.Gestion.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Tfg.Gestion.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class GestionPageModel : AbpPageModel
{
    protected GestionPageModel()
    {
        LocalizationResourceType = typeof(GestionResource);
    }
}
