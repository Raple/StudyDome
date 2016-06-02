using Easy.Domain.ServiceFramework;
using StudyDome.Service.Menu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyDome.Service
{
  public  class ServicesRegistry
    {
        readonly static ServiceFactory factory;
        static ServicesRegistry()
        {
            ServiceFactoryBuilder b = new ServiceFactoryBuilder();

            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StudyDome.Service.dll");
            string path2 = "";
            if (!string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath))
            {
                path2 = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, "StudyDome.Service.dll");
            }

            string usedPath = "";
            if (!File.Exists(path1))
            {
                usedPath = path2;
            }
            else
            {
                usedPath = path1;
            }

            Stream stream = Assembly.ReflectionOnlyLoadFrom(usedPath).GetManifestResourceStream("StudyDome.Services.services.xml");

            factory = b.Build(stream);
        }

        /// <summary>
        /// 菜品分类服务接口
        /// </summary>
        public static ICategoryService Category
        {
            get
            {
                return factory.Get<ICategoryService>();
            }
        }

    }
}
