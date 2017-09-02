using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ImproveX.EntityFramework;

namespace ImproveX.Migrator
{
    [DependsOn(typeof(ImproveXDataModule))]
    public class ImproveXMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ImproveXDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}