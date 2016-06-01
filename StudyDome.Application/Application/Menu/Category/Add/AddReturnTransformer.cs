using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Application;
using StudyDome.Application.Models.Menu.Category;

namespace StudyDome.Application.Application.Menu.Category.Add
{
    public class AddReturnTransformer : AppReturnTransFormer
    {
        public override dynamic GetValue(ReturnContext context, object data)
        {
             var foodCategory = data as StudyDome.Service.Menu.Models.CategoryModel;
            return this.ResultValue(data: new CategoryModel()
            {
                CategoryName = foodCategory.CategoryName,
                Id = foodCategory.Id,
                Sort = foodCategory.Sort
            });
        }
    }
}
