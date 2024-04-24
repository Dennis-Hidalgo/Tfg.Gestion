using Tfg.Gestion.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Tfg.Gestion.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class GestionController : AbpControllerBase
{
    protected GestionController()
    {
        LocalizationResource = typeof(GestionResource);
    }
}
