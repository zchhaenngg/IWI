using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImproveX.ProductionControl;
using ImproveX.ProductionControl.Basic;

namespace ImproveX.EntityFramework
{
    public static  class DbModelBuilderExtension
    {
        public static void SetTableOfProductionControl(this DbModelBuilder modelBuilder)
        {
            var prefix = string.Empty;
            var schemaName = "PdCtrl";

            SetTableName<Factory>(modelBuilder, prefix + "Factory", schemaName);

            SetTableName<Procedure>(modelBuilder, prefix + "Procedure", schemaName);

            SetTableName<ProcedureStatus>(modelBuilder, prefix + "ProcedureStatus", schemaName);

            SetTableName<Product>(modelBuilder, prefix + "Product", schemaName);

            SetTableName<Workshop>(modelBuilder, prefix + "Workshop", schemaName);

            SetTableName<WorkshopProduct>(modelBuilder, prefix + "WorkshopProduct", schemaName);

            SetTableName<ProcedureTask>(modelBuilder, prefix + "ProcedureTask", schemaName);

            SetTableName<ProductTask>(modelBuilder, prefix + "ProductTask", schemaName);

            SetTableName<WorkOrder>(modelBuilder, prefix + "WorkOrder", schemaName);
        }

        public static void SetNavigationOfProductionControl(this DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Procedure>(config =>
            {
                config.HasRequired(p => p.Product).WithMany(pt => pt.Procedures).HasForeignKey(p => p.ProductId);
                //todo test
                config.HasOptional(p => p.PreviewProcedure).WithMany().HasForeignKey(p => p.PreviewProcedureId);
                config.HasOptional(p => p.NextProcedure).WithMany().HasForeignKey(np => np.NextProcedureId);
            });

            modelBuilder.Entity<Workshop>(config => 
            {
                config.HasRequired(w => w.Factory).WithMany(f => f.Workshops).HasForeignKey(p => p.FactoryId);
            });

            modelBuilder.Entity<WorkshopProduct>(config => 
            {
                config.HasRequired(w => w.Product).WithMany(p => p.WorkshopProducts).HasForeignKey(wsp => wsp.ProductId);
                config.HasRequired(wsp => wsp.Workshop).WithMany(w => w.WorkshopProducts).HasForeignKey(wsp => wsp.WorkshopId);
            });

            modelBuilder.Entity<ProcedureTask>(config => 
            {
                config.HasRequired(t => t.Procedure).WithMany(p => p.ProcedureTasks).HasForeignKey(t => t.ProcedureId);
                config.HasRequired(t => t.ProductTask).WithMany(pt => pt.ProcedureTasks).HasForeignKey(t => t.ProductTaskId);
                config.HasOptional(t => t.NextProcedureTask).WithMany().HasForeignKey(t => t.NextProcedureTaskId);
                config.HasRequired(t => t.ProcedureStatus).WithMany().HasForeignKey(t => t.ProcedureStatusId);
            });

            modelBuilder.Entity<ProductTask>(config => 
            {
                config.HasRequired(t => t.Product).WithMany(p => p.ProductTasks).HasForeignKey(t => t.ProductId);
            });

        }

        public static void Entity<TEntityType>(this DbModelBuilder modelBuilder, Action<EntityTypeConfiguration<TEntityType>> action) 
            where TEntityType : class
        {
            var config = modelBuilder.Entity<TEntityType>();
            action(config);
        }


        public static void SetTableName<TEntity>(DbModelBuilder modelBuilder, string tableName, string schemaName)
            where TEntity : class
        {
            if (schemaName == null)
            {
                modelBuilder.Entity<TEntity>().ToTable(tableName);
            }
            else
            {
                modelBuilder.Entity<TEntity>().ToTable(tableName, schemaName);
            }
        }
    }
}
