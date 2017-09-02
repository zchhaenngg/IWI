using ImproveX.EntityFramework;
using EntityFramework.DynamicFilters;

namespace ImproveX.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly ImproveXDbContext _context;

        public InitialHostDbBuilder(ImproveXDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
