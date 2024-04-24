using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Tfg.Gestion.Web;

[Dependency(ReplaceServices = true)]
public class GestionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Gestion";
}
