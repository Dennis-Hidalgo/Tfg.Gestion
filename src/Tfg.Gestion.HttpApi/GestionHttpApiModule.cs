using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using Tfg.Gestion.Localization;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Tfg.Gestion;

[DependsOn(
    typeof(GestionApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpTenantManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
    )]
public class GestionHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClient();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<GestionResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
