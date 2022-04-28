using Microsoft.EntityFrameworkCore;
using Sketec.Infrastructure.Datas.WebCreditStaging.Configurations;

#nullable disable

namespace Sketec.Infrastructure.Data.WebCreditStaging
{
    public partial class WebCreditStagingContext : DbContext
    {
        public WebCreditStagingContext(DbContextOptions<WebCreditStagingContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<ArOutstandingWebCreditLimit> ArOutstandingWebCreditLimits { get; set; }
        //public virtual DbSet<OdsArOutstanding> OdsArOutstandings { get; set; }
        //public virtual DbSet<OdsBillingSd> OdsBillingSds { get; set; }
        //public virtual DbSet<OdsBillingSdItem> OdsBillingSdItems { get; set; }
        //public virtual DbSet<OdsCreditMaster> OdsCreditMasters { get; set; }
        //public virtual DbSet<OdsCustomerMaster> OdsCustomerMasters { get; set; }
        //public virtual DbSet<OdsDeliveryFlowDomestic> OdsDeliveryFlowDomestics { get; set; }
        //public virtual DbSet<OdsDeliveryFlowExport> OdsDeliveryFlowExports { get; set; }
        //public virtual DbSet<OdsExportOrder> OdsExportOrders { get; set; }
        //public virtual DbSet<OdsFiCashSale> OdsFiCashSales { get; set; }
        //public virtual DbSet<OdsOpenGl> OdsOpenGls { get; set; }
        //public virtual DbSet<OdsPartnerFunction> OdsPartnerFunctions { get; set; }
        //public virtual DbSet<ViewArOutstanding> ViewArOutstandings { get; set; }
        //public virtual DbSet<ViewArOutstandingWebCreditLimit> ViewArOutstandingWebCreditLimits { get; set; }
        //public virtual DbSet<ViewCreditMaster> ViewCreditMasters { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

        //    modelBuilder.ApplyConfiguration(new ArOutstandingWebCreditLimitEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsArOutstandingEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsBillingSdEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsBillingSdItemEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsCreditMasterEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsCustomerMasterEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsDeliveryFlowDomesticEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsDeliveryFlowExportEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsExportOrderEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsFiCashSaleEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsOpenGlEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new OdsPartnerFunctionEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new ViewArOutstandingEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new ViewArOutstandingWebCreditLimitEntityTypeConfiguration());
        //    modelBuilder.ApplyConfiguration(new ViewCreditMasterEntityTypeConfiguration());
        //}
    }
}
