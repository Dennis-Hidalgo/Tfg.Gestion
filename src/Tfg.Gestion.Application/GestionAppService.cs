using System;
using System.Collections.Generic;
using System.Text;
using Tfg.Gestion.Localization;
using Volo.Abp.Application.Services;

namespace Tfg.Gestion;

/* Inherit your application services from this class.
 */
public abstract class GestionAppService : ApplicationService
{
    protected GestionAppService()
    {
        LocalizationResource = typeof(GestionResource);
    }
}
