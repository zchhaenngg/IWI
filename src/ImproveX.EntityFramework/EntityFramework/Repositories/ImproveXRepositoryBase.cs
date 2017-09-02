using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace ImproveX.EntityFramework.Repositories
{
    public abstract class ImproveXRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ImproveXDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ImproveXRepositoryBase(IDbContextProvider<ImproveXDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class ImproveXRepositoryBase<TEntity> : ImproveXRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ImproveXRepositoryBase(IDbContextProvider<ImproveXDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
