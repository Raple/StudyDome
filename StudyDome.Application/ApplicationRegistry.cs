using Easy.Domain.Application;
using StudyDome.Application.Application.Menu;

namespace StudyDome.Application
{
    /// <summary>
    /// 应用服务注册中心
    /// </summary>
    public static class ApplicationRegistry
    {
        static ApplicationRegistry()
        {
            ApplicationFactory.Instance().Register(new CategoryApplication());
        }
    }

    /// <summary>
    /// 商品分类应用服务
    /// </summary>
    public static CategoryApplication Category
    {
        get
        {
            return ApplicationFactory.Instance().Get<CategoryApplication>();
        }
    }
}
