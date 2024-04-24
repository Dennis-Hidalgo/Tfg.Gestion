using Volo.Abp.Settings;

namespace Tfg.Gestion.Settings;

public class GestionSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(GestionSettings.MySetting1));
    }
}
