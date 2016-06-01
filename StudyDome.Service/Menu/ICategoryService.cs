using Easy.Rpc;
using StudyDome.Service.Menu.Models;
using System.Collections.Generic;

namespace StudyDome.Service.Menu
{
    public interface ICategoryService
    {
        /// <summary>
        /// 添加商品分类
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns>商品分类ID</returns>
        ResultWithData<CategoryModel> Add(AddModel addModel, InvokerContext context = null);

        /// <summary>
        /// 查询所有商品分类
        /// </summary>
        /// <param name="restaurantId">餐厅ID</param>
        /// <returns>商品分类列表</returns>
        ResultWithData<PageList<CategoryModel>> Select(int restaurantId, InvokerContext context = null);

    }
}
