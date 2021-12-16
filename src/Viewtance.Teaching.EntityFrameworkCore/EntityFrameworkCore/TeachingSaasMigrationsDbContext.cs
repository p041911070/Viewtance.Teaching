using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.LanguageManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TextTemplateManagement.EntityFrameworkCore;
using Volo.Saas.EntityFrameworkCore;
using Volo.Saas.Editions;
using Volo.Saas.Tenants;
using Volo.Payment.EntityFrameworkCore;

namespace Viewtance.Teaching.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(ISaasDbContext))]
    [ConnectionStringName("Saas")]
    public class TeachingSaasMigrationsDbContext : 
        AbpDbContext<TeachingSaasMigrationsDbContext>,
        ISaasDbContext
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */

        #region Entities from the modules

        /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
         * and replaced them for this DbContext. This allows you to perform JOIN
         * queries for the entities of these modules over the repositories easily. You
         * typically don't need that for other modules. But, if you need, you can
         * implement the DbContext interface of the needed module and use ReplaceDbContext
         * attribute just like IIdentityProDbContext and ISaasDbContext.
         *
         * More info: Replacing a DbContext of a module ensures that the related module
         * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
         */

        // SaaS
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

        #endregion

        public TeachingSaasMigrationsDbContext(DbContextOptions<TeachingSaasMigrationsDbContext> options)
            : base(options)
        {
            AbpCommonDbProperties.DbTablePrefix = "Teaching";
#if DEBUG
            AbpIdentityDbProperties.DbTablePrefix = "Teaching";

#else
            AbpIdentityDbProperties.DbTablePrefix = "SRP";

#endif
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigureSaas();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(TeachingConsts.DbTablePrefix + "YourEntities", TeachingConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}
