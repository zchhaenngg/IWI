using System.Threading.Tasks;
using Abp.Application.Services;
using ImproveX.Configuration.Dto;

namespace ImproveX.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}