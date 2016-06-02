using Easy.Public.HttpRequestService;
using Easy.Rpc;
using Easy.Rpc.Cluster;
using Easy.Rpc.LoadBalance;
using StudyDome.Service.Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDome.Service.Menu
{
  public  class CategoryService:ICategoryService,Easy.Domain.ServiceFramework.IService
    {
        [ServiceProtocol]
        [Directory("StudyMenu", "Category/Add")]
        [Cluster(FailfastCluster.NAME)]
        [LoadBalance(RandomLoadBalance.NAME)]
        public virtual ResultWithData<CategoryModel> Add(AddModel addModel, InvokerContext context = null)
        {
            var actualContext = context as ServiceInvokerContext;
            var categroyInvoker = new CategoryInvoke<ResultWithData<CategoryModel>>((invoker, node, path) =>
            {
                string url = invoker.JoinURL(node, path);
                var request = HttpRequestClient.Request(url, "POST", false);
                request.Headers.Add("SystemId", actualContext.SystemId);
                request.Headers.Add("Version", actualContext.Version);
                request.ContentType = "application/json";

                return request.Send(addModel)
                        .GetBodyContent<ResultWithData<CategoryModel>>(close: true);

            });
            return ClientInvoker.Invoke(categroyInvoker, context);
        }

        [ServiceProtocol]
        [Directory("StudyMenu", "Category/Select")]
        [Cluster(FailoverCluster.NAME)]
        [LoadBalance(RandomLoadBalance.NAME)]
        public virtual ResultWithData<PageList<CategoryModel>> Select(int restaurantId, InvokerContext context = null)
        {
            var actualContext = context as ServiceInvokerContext;
            var categroyInvoker = new CategoryInvoke<ResultWithData<PageList<CategoryModel>>>((invoker, node, path) =>
            {
                string url = invoker.JoinURL(node, path) + "?restaurantId=" + restaurantId;
                var request = HttpRequestClient.Request(url, "POST", false);
                request.Headers.Add("SystemId", actualContext.SystemId);
                request.Headers.Add("Version", actualContext.Version);
                request.ContentType = "application/json";

                return request.Send()
                        .GetBodyContent<ResultWithData<PageList<CategoryModel>>>(close: true);
            });
            return ClientInvoker.Invoke(categroyInvoker, context);
        }



    }

    class CategoryInvoke<T> : BaseInvoker<T>
    {
        public CategoryInvoke(Func<BaseInvoker<T>, Node, string, T> func)
            : base(func)
        {

        }
        public override string JoinURL(Node node, string path)
        {
            return node.Url.Trim() + path.Trim();
        }        
    }
}
