using Abp.Web.Mvc.Views;

namespace ImproveX.Web.Views
{
    public abstract class ImproveXWebViewPageBase : ImproveXWebViewPageBase<dynamic>
    {

    }

    public abstract class ImproveXWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected ImproveXWebViewPageBase()
        {
            LocalizationSourceName = ImproveXConsts.LocalizationSourceName;
        }
    }
}