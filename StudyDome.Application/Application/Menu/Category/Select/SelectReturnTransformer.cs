using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using StudyDome.Application.Models.Menu.Category;

namespace StudyDome.Application.Application.Menu.Category.Select
{
    public class SelectReturnTransformer : AppReturnTransFormer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
            var tempDate = data as PageList<StudyDome.Service.Menu.Models.CategoryModel>;
            int count = tempDate.TotalRows;
            var list = tempDate.Collections as List<StudyDome.Service.Menu.Models.CategoryModel>;
            List<CategoryModel> result = new List<CategoryModel>();
            foreach (var item in list)
            {
                var temp = new CategoryModel
                {
                    CategoryName = item.CategoryName,
                    Id = item.Id,
                    Sort = item.Sort
                };
                result.Add(temp);
            }
            
            return this.ResultValue(data:new PageList<CategoryModel> { TotalRows=count,Collections=result});
        }
    }
}
