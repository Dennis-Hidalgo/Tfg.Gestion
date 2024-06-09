using AutoMapper;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Dishes;
using Tfg.Gestion.Inventories;
using Tfg.Gestion.Invoices;
using Tfg.Gestion.OrderDetails;
using Tfg.Gestion.Orders;
using Tfg.Gestion.ProductProviders;
using Tfg.Gestion.Products;
using Tfg.Gestion.RawMaterialDetails;
using Tfg.Gestion.RawMaterials;
using Tfg.Gestion.SalesHistories;

namespace Tfg.Gestion;

public class GestionApplicationAutoMapperProfile : Profile
{
    public GestionApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Product, ProductDto>();
        CreateMap<CreateUpdateProductDto, Product>();
        CreateMap<ProductDto, CreateUpdateProductDto>();

        // Provider mappings
        CreateMap<ProductProvider, ProductProviderDto>();
        CreateMap<CreateUpdateProductProviderDto, ProductProvider>();
        CreateMap<ProductProviderDto, CreateUpdateProductProviderDto>();

        // RawMaterial mappings
        CreateMap<RawMaterial, RawMaterialDto>();
        CreateMap<CreateUpdateRawMaterialDto, RawMaterial>();
        CreateMap<RawMaterialDto, CreateUpdateRawMaterialDto>();
        CreateMap<ProductProvider, ProductProviderLookupDto>();

        // Dish mappings
        CreateMap<Dish, DishDto>();
        CreateMap<CreateUpdateDishDto, Dish>();
        CreateMap<DishDto, CreateUpdateDishDto>();

        // Order mappings
        CreateMap<Order, OrderDto>();
        CreateMap<CreateUpdateOrderDto, Order>();
        CreateMap<OrderDto, CreateUpdateOrderDto>();
        CreateMap<Customer, CustomerLookupDto>();

        // Customer mappings
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
        CreateMap<CustomerDto, CreateUpdateCustomerDto>();

        // OrderDetail mappings
        CreateMap<OrderDetail, OrderDetailDto>();
        CreateMap<CreateUpdateOrderDetailDto, OrderDetail>();
        CreateMap<OrderDetailDto,  CreateUpdateOrderDetailDto>();

        // Inventory mappings
        CreateMap<Inventory, InventoryDto>();
        CreateMap<CreateUpdateInventoryDto, Inventory>();
        CreateMap<InventoryDto, CreateUpdateInventoryDto>();
        CreateMap<RawMaterial, RawMaterialLookupDto>();

        // SalesHistory mappings
        CreateMap<SalesHistory, SalesHistoryDto>();
        CreateMap<CreateUpdateSalesHistoryDto, SalesHistory>();
        CreateMap<SalesHistoryDto, CreateUpdateSalesHistoryDto>();

        // Invoice mappings
        CreateMap<Invoice, InvoiceDto>();
        CreateMap<CreateUpdateInvoiceDto, Invoice>();
        CreateMap<InvoiceDto, CreateUpdateInvoiceDto>();

        // RawMaterialDetail mappings
        CreateMap<RawMaterialDetail, RawMaterialDetailDto>();
        CreateMap<CreateUpdateRawMaterialDetailDto, RawMaterialDetail>();
        CreateMap<RawMaterialDetailDto, CreateUpdateRawMaterialDetailDto>();
    }
}
