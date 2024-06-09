using Tfg.Gestion.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Tfg.Gestion.Permissions;

public class GestionPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var tfgGestionGrupo = context.AddGroup(GestionPermissions.GroupName, L("Permission:Gestion"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(GestionPermissions.MyPermission1, L("Permission:MyPermission1"));
        var customersPermission = tfgGestionGrupo.AddPermission(GestionPermissions.Customers.Default, L("Permission:Customers"));
        customersPermission.AddChild(GestionPermissions.Customers.Create, L("Permission:Customers.Create"));
        customersPermission.AddChild(GestionPermissions.Customers.Edit, L("Permission:Customers.Edit"));
        customersPermission.AddChild(GestionPermissions.Customers.Delete, L("Permission:Customers.Delete"));

        var dishesPermission = tfgGestionGrupo.AddPermission(GestionPermissions.Dishes.Default, L("Permission:Dishes"));
        dishesPermission.AddChild(GestionPermissions.Dishes.Create, L("Permission:Dishes.Create"));
        dishesPermission.AddChild(GestionPermissions.Dishes.Edit, L("Permission:Dishes.Edit"));
        dishesPermission.AddChild(GestionPermissions.Dishes.Delete, L("Permission:Dishes.Delete"));

        var inventoriesPermission = tfgGestionGrupo.AddPermission(GestionPermissions.Inventories.Default, L("Permission:Inventories"));
        inventoriesPermission.AddChild(GestionPermissions.Inventories.Create, L("Permission:Inventories.Create"));
        inventoriesPermission.AddChild(GestionPermissions.Inventories.Edit, L("Permission:Inventories.Edit"));
        inventoriesPermission.AddChild(GestionPermissions.Inventories.Delete, L("Permission:Inventories.Delete"));

        var orderDetailsPermission = tfgGestionGrupo.AddPermission(GestionPermissions.OrderDetails.Default, L("Permission:OrderDetails"));
        orderDetailsPermission.AddChild(GestionPermissions.OrderDetails.Create, L("Permission:OrderDetails.Create"));
        orderDetailsPermission.AddChild(GestionPermissions.OrderDetails.Edit, L("Permission:OrderDetails.Edit"));
        orderDetailsPermission.AddChild(GestionPermissions.OrderDetails.Delete, L("Permission:OrderDetails.Delete"));

        var ordersPermission = tfgGestionGrupo.AddPermission(GestionPermissions.Orders.Default, L("Permission:Orders"));
        ordersPermission.AddChild(GestionPermissions.Orders.Create, L("Permission:Orders.Create"));
        ordersPermission.AddChild(GestionPermissions.Orders.Edit, L("Permission:Orders.Edit"));
        ordersPermission.AddChild(GestionPermissions.Orders.Delete, L("Permission:Orders.Delete"));

        var productProvidersPermission = tfgGestionGrupo.AddPermission(GestionPermissions.ProductProviders.Default, L("Permission:ProductProviders"));
        productProvidersPermission.AddChild(GestionPermissions.ProductProviders.Create, L("Permission:ProductProviders.Create"));
        productProvidersPermission.AddChild(GestionPermissions.ProductProviders.Edit, L("Permission:ProductProviders.Edit"));
        productProvidersPermission.AddChild(GestionPermissions.ProductProviders.Delete, L("Permission:ProductProviders.Delete"));

        var rawMaterialDetailsPermission = tfgGestionGrupo.AddPermission(GestionPermissions.RawMaterialDetails.Default, L("Permission:RawMaterialDetails"));
        rawMaterialDetailsPermission.AddChild(GestionPermissions.RawMaterialDetails.Create, L("Permission:RawMaterialDetails.Create"));
        rawMaterialDetailsPermission.AddChild(GestionPermissions.RawMaterialDetails.Edit, L("Permission:RawMaterialDetails.Edit"));
        rawMaterialDetailsPermission.AddChild(GestionPermissions.RawMaterialDetails.Delete, L("Permission:RawMaterialDetails.Delete"));

        var rawMaterialsPermission = tfgGestionGrupo.AddPermission(GestionPermissions.RawMaterials.Default, L("Permission:RawMaterials"));
        rawMaterialsPermission.AddChild(GestionPermissions.RawMaterials.Create, L("Permission:RawMaterials.Create"));
        rawMaterialsPermission.AddChild(GestionPermissions.RawMaterials.Edit, L("Permission:RawMaterials.Edit"));
        rawMaterialsPermission.AddChild(GestionPermissions.RawMaterials.Delete, L("Permission:RawMaterials.Delete"));

        var salesHistoriesPermission = tfgGestionGrupo.AddPermission(GestionPermissions.SalesHistories.Default, L("Permission:SalesHistories"));
        salesHistoriesPermission.AddChild(GestionPermissions.SalesHistories.Create, L("Permission:SalesHistories.Create"));
        salesHistoriesPermission.AddChild(GestionPermissions.SalesHistories.Edit, L("Permission:SalesHistories.Edit"));
        salesHistoriesPermission.AddChild(GestionPermissions.SalesHistories.Delete, L("Permission:SalesHistories.Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GestionResource>(name);
    }
}
