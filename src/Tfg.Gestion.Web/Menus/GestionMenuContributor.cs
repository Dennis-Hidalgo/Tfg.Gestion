using System.Threading.Tasks;
using Tfg.Gestion.Localization;
using Tfg.Gestion.MultiTenancy;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace Tfg.Gestion.Web.Menus;

public class GestionMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<GestionResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                GestionMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.GetAdministration().AddItem(
     new ApplicationMenuItem(
         "CustomIdentity.Users",
         l["Users"],
         url: "/custom-identity/users",
         icon: "fas fa-users",
         requiredPermissionName: IdentityPermissions.Users.Default
     )
 );

        context.Menu.AddItem(
    new ApplicationMenuItem(
        "TfgGestion",
        l["Menu:TfgGestion"],
        icon: "fa fa-book"
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.Products",
            l["Menu:Products"],
            url: "/Products"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.RawMaterials",
            l["Menu:RawMaterials"],
            url: "/RawMaterials"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.ProductProviders",
            l["Menu:ProductProviders"],
            url: "/ProductProviders"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.Invoices",
            l["Menu:Invoices"],
            url: "/Invoices"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.Customers",
            l["Menu:Customers"],
            url: "/Customers"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.Dishes",
            l["Menu:Dishes"],
            url: "/Dishes"
        )
    ).AddItem(
        new ApplicationMenuItem(
            "TfgGestion.Inventories",
            l["Menu:Inventories"],
            url: "/Inventories"
        )
    )
);

        return Task.CompletedTask;
    }
}
