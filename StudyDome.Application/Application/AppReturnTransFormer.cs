using Easy.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Easy.Public;
using StudyDome.Service;

namespace StudyDome.Application.Application
{
    public abstract class AppReturnTransFormer : IReturnTransformer
    {
        public int Order
        {
            get { return 0; }
        }

        public abstract dynamic GetValue(ReturnContext context, object data);

        public virtual bool IsMapped(ReturnContext context)
        {
            int v = StringHelper.ToInt32(context.Version, 0);
            if (context.SystemId.ToUpper() == "APP" && v >= this.Order)
            {
                return true;
            }
            return false;
        }

        public dynamic ResultValue<T>(int status = 200, T data = default(T), string message = "")
        {
            var result = new ResultWithData<T>(status, data, message);
            return result;
        }
    }
}
