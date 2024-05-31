using Microsoft.EntityFrameworkCore;
using Tfg.Gestion.Customers;
using Tfg.Gestion.Dishes;
using Tfg.Gestion.Employess;
using Tfg.Gestion.Inventories;
using Tfg.Gestion.Invoices;
using Tfg.Gestion.OrderDetails;
using Tfg.Gestion.Orders;
using Tfg.Gestion.ProductProviders;
using Tfg.Gestion.Products;
using Tfg.Gestion.RawMaterialDetails;
using Tfg.Gestion.RawMaterials;
using Tfg.Gestion.SalesHistories;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Tfg.Gestion.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class GestionDbContext :
    AbpDbContext<GestionDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductProvider> Providers { get; set; }
    public DbSet<RawMaterial> RawMaterials { get; set; }
    public DbSet<Dish> Dishes { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<SalesHistory> SalesHistories { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<RawMaterialDetail> RawMaterialDetails { get; set; }

    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }


    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public GestionDbContext(DbContextOptions<GestionDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(GestionConsts.DbTablePrefix + "YourEntities", GestionConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        builder.Entity<Product>(b =>
        {
            b.ToTable("Products");
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Title).IsRequired().HasMaxLength(128);
        });
        builder.Entity<ProductProvider>(b =>
        {
            b.ToTable("ProductProviders");
            b.ConfigureByConvention();
        });

        builder.Entity<RawMaterial>(b =>
        {
            b.ToTable("RawMaterials");
            b.ConfigureByConvention();
            b.HasOne(rm => rm.ProductProvider).WithMany().HasForeignKey(rm => rm.ProductProviderId);
        });

        builder.Entity<Dish>(b =>
        {
            b.ToTable("Dishes");
            b.ConfigureByConvention();
        });

        builder.Entity<Order>(b =>
        {
            b.ToTable("Orders");
            b.ConfigureByConvention();
            b.HasOne(o => o.Customer).WithMany().HasForeignKey(o => o.CustomerId);
            b.HasOne(o => o.Employee).WithMany().HasForeignKey(o => o.EmployeeId);
        });

        builder.Entity<Employee>(b =>
        {
            b.ToTable("Employees"); // Mapea a la tabla de usuarios de ABP
            b.ConfigureByConvention(); // Método de ABP para configurar la entidad por convención
        });

        builder.Entity<Customer>(b =>
        {
            b.ToTable("Customers");
            b.ConfigureByConvention();
        });

        builder.Entity<OrderDetail>(b =>
        {
            b.ToTable("OrderDetails");
            b.ConfigureByConvention();
            b.HasOne(od => od.Order).WithMany().HasForeignKey(od => od.OrderId);
            b.HasOne(od => od.Dish).WithMany().HasForeignKey(od => od.DishId);
        });

        builder.Entity<Inventory>(b =>
        {
            b.ToTable("Inventories");
            b.ConfigureByConvention();
            b.HasOne(i => i.RawMaterial).WithMany().HasForeignKey(i => i.RawMaterialId);
        });

        builder.Entity<SalesHistory>(b =>
        {
            b.ToTable("SalesHistories");
            b.ConfigureByConvention();
            b.HasOne(sh => sh.Order).WithMany().HasForeignKey(sh => sh.OrderId);
        });

        builder.Entity<Invoice>(b =>
        {
            b.ToTable("Invoices");
            b.ConfigureByConvention();
            b.HasOne(i => i.Order).WithMany().HasForeignKey(i => i.OrderId);
        });


        builder.Entity<RawMaterialDetail>(b =>
        {
            b.ToTable("RawMaterialDetails");
            b.ConfigureByConvention();
            b.HasOne(rmd => rmd.Dish).WithMany().HasForeignKey(rmd => rmd.DishId);
            b.HasOne(rmd => rmd.RawMaterial).WithMany().HasForeignKey(rmd => rmd.RawMaterialId);
        });
    }
}
