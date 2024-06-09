using AutoMapper;
using Tfg.Gestion.Inventories;
using Tfg.Gestion.Orders;
using Tfg.Gestion.RawMaterials;

namespace Tfg.Gestion.Web;

public class GestionWebAutoMapperProfile : Profile
{
    public GestionWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<Pages.RawMaterials.CreateModalModel.CreateRawMaterialViewModel, CreateUpdateRawMaterialDto>();
        CreateMap<RawMaterialDto, Pages.RawMaterials.EditModalModel.EditRawMaterialViewModel>();
        CreateMap<Pages.RawMaterials.EditModalModel.EditRawMaterialViewModel, CreateUpdateRawMaterialDto>();

        CreateMap<Pages.Inventories.CreateModalModel.CreateInventoryViewModel, CreateUpdateInventoryDto>();
        CreateMap<InventoryDto, Pages.Inventories.EditModalModel.EditInventoryViewModel>();
        CreateMap<Pages.Inventories.EditModalModel.EditInventoryViewModel, CreateUpdateInventoryDto>();

        CreateMap<Pages.Orders.CreateModalModel.CreateOrderViewModel, CreateUpdateOrderDto>();
        CreateMap<OrderDto, Pages.Orders.EditModalModel.EditOrderViewModel>();
        CreateMap<Pages.Orders.EditModalModel.EditOrderViewModel, CreateUpdateOrderDto>();
    }
}
