namespace ImproveX.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initProductionControl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            CreateTable(
                "PdCtrl.Factory",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Factory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PdCtrl.Workshop",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        FactoryId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Workshop_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PdCtrl.Factory", t => t.FactoryId)
                .Index(t => t.FactoryId);
            
            CreateTable(
                "PdCtrl.WorkshopProduct",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        ProductId = c.Guid(nullable: false),
                        WorkshopId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkshopProduct_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PdCtrl.Product", t => t.ProductId)
                .ForeignKey("PdCtrl.Workshop", t => t.WorkshopId)
                .Index(t => t.ProductId)
                .Index(t => t.WorkshopId);
            
            CreateTable(
                "PdCtrl.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PdCtrl.Procedure",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        ProductId = c.Guid(nullable: false),
                        NextProcedureId = c.Guid(),
                        PreviewProcedureId = c.Guid(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Procedure_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PdCtrl.Procedure", t => t.NextProcedureId)
                .ForeignKey("PdCtrl.Procedure", t => t.PreviewProcedureId)
                .ForeignKey("PdCtrl.Product", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.NextProcedureId)
                .Index(t => t.PreviewProcedureId);
            
            CreateTable(
                "PdCtrl.ProcedureTask",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartTime = c.DateTime(),
                        FinishTime = c.DateTime(),
                        ProcedureId = c.Guid(nullable: false),
                        ProductTaskId = c.Guid(nullable: false),
                        NextProcedureTaskId = c.Guid(),
                        ProcedureStatusId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProcedureTask_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PdCtrl.ProcedureTask", t => t.NextProcedureTaskId)
                .ForeignKey("PdCtrl.Procedure", t => t.ProcedureId)
                .ForeignKey("PdCtrl.ProcedureStatus", t => t.ProcedureStatusId)
                .ForeignKey("PdCtrl.ProductTask", t => t.ProductTaskId)
                .Index(t => t.ProcedureId)
                .Index(t => t.ProductTaskId)
                .Index(t => t.NextProcedureTaskId)
                .Index(t => t.ProcedureStatusId);
            
            CreateTable(
                "PdCtrl.ProcedureStatus",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProcedureStatus_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "PdCtrl.ProductTask",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        WorkOrder_Id = c.Guid(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductTask_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("PdCtrl.Product", t => t.ProductId)
                .ForeignKey("PdCtrl.WorkOrder", t => t.WorkOrder_Id)
                .Index(t => t.ProductId)
                .Index(t => t.WorkOrder_Id);
            
            CreateTable(
                "PdCtrl.WorkOrder",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkOrder_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id");
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id");
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id");
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers");
            DropForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles");
            DropForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions");
            DropForeignKey("PdCtrl.ProductTask", "WorkOrder_Id", "PdCtrl.WorkOrder");
            DropForeignKey("PdCtrl.WorkshopProduct", "WorkshopId", "PdCtrl.Workshop");
            DropForeignKey("PdCtrl.WorkshopProduct", "ProductId", "PdCtrl.Product");
            DropForeignKey("PdCtrl.Procedure", "ProductId", "PdCtrl.Product");
            DropForeignKey("PdCtrl.ProcedureTask", "ProductTaskId", "PdCtrl.ProductTask");
            DropForeignKey("PdCtrl.ProductTask", "ProductId", "PdCtrl.Product");
            DropForeignKey("PdCtrl.ProcedureTask", "ProcedureStatusId", "PdCtrl.ProcedureStatus");
            DropForeignKey("PdCtrl.ProcedureTask", "ProcedureId", "PdCtrl.Procedure");
            DropForeignKey("PdCtrl.ProcedureTask", "NextProcedureTaskId", "PdCtrl.ProcedureTask");
            DropForeignKey("PdCtrl.Procedure", "PreviewProcedureId", "PdCtrl.Procedure");
            DropForeignKey("PdCtrl.Procedure", "NextProcedureId", "PdCtrl.Procedure");
            DropForeignKey("PdCtrl.Workshop", "FactoryId", "PdCtrl.Factory");
            DropIndex("PdCtrl.ProductTask", new[] { "WorkOrder_Id" });
            DropIndex("PdCtrl.ProductTask", new[] { "ProductId" });
            DropIndex("PdCtrl.ProcedureTask", new[] { "ProcedureStatusId" });
            DropIndex("PdCtrl.ProcedureTask", new[] { "NextProcedureTaskId" });
            DropIndex("PdCtrl.ProcedureTask", new[] { "ProductTaskId" });
            DropIndex("PdCtrl.ProcedureTask", new[] { "ProcedureId" });
            DropIndex("PdCtrl.Procedure", new[] { "PreviewProcedureId" });
            DropIndex("PdCtrl.Procedure", new[] { "NextProcedureId" });
            DropIndex("PdCtrl.Procedure", new[] { "ProductId" });
            DropIndex("PdCtrl.WorkshopProduct", new[] { "WorkshopId" });
            DropIndex("PdCtrl.WorkshopProduct", new[] { "ProductId" });
            DropIndex("PdCtrl.Workshop", new[] { "FactoryId" });
            DropTable("PdCtrl.WorkOrder",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkOrder_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.ProductTask",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProductTask_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.ProcedureStatus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProcedureStatus_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.ProcedureTask",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ProcedureTask_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.Procedure",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Procedure_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.Product",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.WorkshopProduct",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_WorkshopProduct_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.Workshop",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Workshop_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("PdCtrl.Factory",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Factory_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            AddForeignKey("dbo.AbpUserRoles", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserLogins", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpUserClaims", "UserId", "dbo.AbpUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpPermissions", "RoleId", "dbo.AbpRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AbpFeatures", "EditionId", "dbo.AbpEditions", "Id", cascadeDelete: true);
        }
    }
}
