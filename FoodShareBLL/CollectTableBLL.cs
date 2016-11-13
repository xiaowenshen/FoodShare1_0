using FoodShareDAL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareBLL
{
    public partial class CollectTableBLL
    {
        /// <summary>
        /// 添加到收藏
        /// </summary>
        /// <param name="ct">关联数据对象</param>
        /// <returns></returns>
        public bool Add(CollectTable ct)
        {
            CollectTableDAL CDAL = new CollectTableDAL();
            return CDAL.Add(ct);
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="cid">菜谱id</param>
        /// <param name="uid">用户id</param>
        /// <returns></returns>

        public bool Delete(int cid ,int uid)
        {
            CollectTableDAL CDAL = new CollectTableDAL();

            return CDAL.Delete(cid, uid);
        }
        /// <summary>
        /// 获取收藏
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <returns></returns>
        public List<CookBook> GetCollectTable(int uid)
        {

            CollectTableDAL CDAL = new CollectTableDAL();
            return CDAL.GetCollection(uid);
        }

        public bool IsExistCollectTable(int cid ,int uid)
        {
            CollectTableDAL CDAL = new CollectTableDAL();
            return CDAL.IsExistCollectTable(cid, uid);
        }

        public int GetPageCount(int pagesize,int uid)
        {
            CollectTableDAL CDAL = new CollectTableDAL();
            int totalcount = CDAL.GetMaxCount(uid);
            return totalcount > 0 && pagesize > 0 ? Convert.ToInt32(Math.Ceiling(totalcount * 1.0 / pagesize)) : 1;
        }
    }
}
