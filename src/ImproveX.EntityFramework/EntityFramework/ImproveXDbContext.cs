using System.Data.Common;
using Abp.Zero.EntityFramework;
using ImproveX.Authorization.Roles;
using ImproveX.Authorization.Users;
using ImproveX.MultiTenancy;

namespace ImproveX.EntityFramework
{
    public class ImproveXDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public ImproveXDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in ImproveXDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of ImproveXDbContext since ABP automatically handles it.
         */
        public ImproveXDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public ImproveXDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public ImproveXDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
