using Abp.AutoMapper;
using ImproveX.Sessions.Dto;

namespace ImproveX.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}