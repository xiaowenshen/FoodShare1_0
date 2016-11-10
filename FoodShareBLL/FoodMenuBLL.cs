using FoodShareDAL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareBLL
{
    public partial class FoodMenuBLL
    {
        public FoodMenu GetFoodMenuById(int mid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.GetFoodMenuById(mid);
        }

        public bool Add(FoodMenu model)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.Add(model) > 0;

        }
        public bool Edit(FoodMenu model)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.Update(model);
        }
        /// <summary>
        /// 删除整个菜谱
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public bool Delete(int cid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.Delete(cid);
        }
        /// <summary>
        /// 删除菜谱中的指定1条数据
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>

        public bool DeleteItem(int fid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.DeleteAnItem(fid);
        }
        /// <summary>
        /// 获取指定用户的页码总数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize, int classid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            int pagecount = fdal.GetRecordCount(classid);
            return pagecount > 0 && pagesize > 0 ? Convert.ToInt32(Math.Ceiling(1.0 * pagecount / pagesize)) : 1;
        }
        
        public List<FoodMenu> GetList(int start , int end,int classid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.GetList(start, end, classid);
        }

        public List<FoodMenu> GetList(int classid)
        {
            FoodMenuDAL fdal = new FoodMenuDAL();
            return fdal.GetList( classid);
        }



    }
}
