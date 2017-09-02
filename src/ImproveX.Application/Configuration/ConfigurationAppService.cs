using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using ImproveX.Configuration.Dto;

namespace ImproveX.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : ImproveXAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
