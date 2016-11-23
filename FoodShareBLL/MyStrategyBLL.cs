using FoodShareDAL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareBLL
{
    public partial  class MyStrategyBLL
    {
        MyStrategyDAL mdal = new MyStrategyDAL();
        /// <summary>
        /// 根据攻略id获取攻略
        /// </summary>
        /// <param name="SId">攻略id</param>
        /// <returns></returns>
        public MyStrategy GetMyStrategyById(int SId)
        {
            return mdal.GetMyStrategyById(SId);
        }
        /// <summary>
        /// 获取全部攻略
        /// </summary>
        /// <returns></returns>
        public List<MyStrategy> GetList()
        {
            return mdal.GetList();

        }
        /// <summary>
        /// 获取指定范围的列表
        /// </summary>
        /// <param name="pageindex">页码下标</param>
        /// <param name="pagesize">页面容量</param>
        /// <returns></returns>
        public List<MyStrategy> GetList(int pageindex,int pagesize)
        {
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mdal.GetList(start, end);
        }

        /// <summary>
        /// 获取指定用户的指定范围的列表
        /// </summary>
        /// /// <param name="uid">用户id</param>
        /// <param name="pageindex">页码下标</param>
        /// <param name="pagesize">页面容量</param>
        /// <returns></returns>
        public List<MyStrategy> GetList(int uid,int pageindex, int pagesize)
        {
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mdal.GetList(uid,start, end);
        }

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="ms">MyStrategy对象</param>
        /// <returns></returns>
        public bool Add(MyStrategy ms)
        {
            return mdal.Add(ms);
        }
        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="sid">攻略id</param>
        /// <returns></returns>
        public bool Delete(int sid)
        {
            return mdal.Delete(sid);
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="ms">MyStrategy对象</param>
        /// <returns></returns>
        public bool Edit(MyStrategy ms)
        {
            return mdal.Update(ms);
        }

        public int GetPageCount(int pagesize)
        {
            if (pagesize <= 0) return 0;
            int maxrecord = mdal.GetRecordCount();
            return Convert.ToInt32(Math.Ceiling(1.0*maxrecord / pagesize));
        }
        public int GetPageCount(int pagesize,int uid)
        {
            if (pagesize <= 0) return 0;
            int maxrecord = mdal.GetRecordCount(uid);
            return Convert.ToInt32(Math.Ceiling(1.0 * maxrecord / pagesize));
        }
    }
}
