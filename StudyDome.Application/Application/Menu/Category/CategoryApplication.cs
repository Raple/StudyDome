using Easy.Domain.Application;
using Easy.Domain.Base;
using StudyDome.Service;
using StudyDome.Service.Menu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyDome.Application.Application.Menu
{
   public class CategoryApplication: BaseApplication
    {
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="name">商品分类对象</param>
        /// <param name="sort">排序码</param>
        /// <param name="restaurantId">门店ID</param>
        /// <returns>商品分类ID</returns>
        public IReturn Add(string name, int sort, int restaurantId)
        {
            var result = ServicesRegistry.Category.Add(new AddModel() { Name = name, RestaurantId = restaurantId, Sort = sort });
            if (result.ResultStatus != 200)
            {
                throw new BrokenRuleException(result.ResultStatus.ToString(), result.Message);
            }
            return this.Write("Add", result.DataBody);
        }


        /// <summary>
        /// 查询所有商品分类
        /// </summary>
        /// <param name="restaurantId">门店ID</param>
        /// <returns>商品分类列表</returns>
        public IReturn Select(int restaurantId)
        {
            var result = ServicesRegistry.Category.Select(restaurantId);
            if (result.ResultStatus != 200)
            {
                throw new BrokenRuleException(result.ResultStatus.ToString(), result.Message);
            }
            return this.Write("Select", result.DataBody);
        }

    }
}
