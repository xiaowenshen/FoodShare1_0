using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShareDAL;
namespace FoodShareBLL
{
   public partial  class ManageMenuBLL
    {

        public List<ManageMenu> GetList(int pageindex,int pagesize,int uid)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mmdal.GetList(start, end,uid);
        }
        public List<ManageMenu> GetList(int pageindex, int pagesize)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mmdal.GetList(start, end);
        }

        public bool Edit(ManageMenu model)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            return mmdal.Update(model);
        }
       
        public bool Remove(int Menuid)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            return mmdal.Delete(Menuid);
        }

        public bool Add(ManageMenu model)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            return mmdal.Add(model) > 0;
        }

        public int GetPageCount(int pagesize,int uid)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            int pagecount = mmdal.GetRecordCount(uid);
            return pagecount > 0 && pagesize > 0 ? Convert.ToInt32( Math.Ceiling(1.0 * pagecount / pagesize)) : 1;
        }
        public int GetPageCount(int pagesize)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            int pagecount = mmdal.GetRecordCount();
            return pagecount > 0 && pagesize > 0 ? Convert.ToInt32(Math.Ceiling(1.0 * pagecount / pagesize)) : 1;
        }

        public ManageMenu GetManageMenuById(int mid)
        {
            ManageMenuDAL mmdal = new ManageMenuDAL();
            return mmdal.GetModelById(mid);
        }

        

        

    }
}
