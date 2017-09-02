using System.Threading.Tasks;
using Abp.Application.Services;
using ImproveX.Sessions.Dto;

namespace ImproveX.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
