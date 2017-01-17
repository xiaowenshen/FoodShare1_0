using FoodShareDAL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareBLL
{
    public partial class UserFocusBLL
    {
        public object UserFoucsDAL { get; private set; }

        public bool Add(UserFocus focus)
        {
            UserFocusDAL udal = new UserFocusDAL();
            return udal.Add(focus) > 0;
        }

        public bool delete(int fid)
        {
            UserFocusDAL udal = new UserFocusDAL();
            return udal.Delete(fid) ;
        }

        public bool Update(UserFocus focus)
        {
            UserFocusDAL udal = new UserFocusDAL();
            return udal.Update(focus);
        }

        public int GetTotalCount(int uid)
        {
            UserFocusDAL udal = new UserFocusDAL();
            return udal.GetRecordCount(uid);
        }
        public int GetPageCount(int pagesize,int uid)
        {
            int totalcount = GetTotalCount(uid);
            return Convert.ToInt32(pagesize == 0 ? 0 : Math.Ceiling(1.0 * totalcount / pagesize ) );
        }

        public List<UserFocus> GetList(int uid,int pagesize,int pageindex)
        {
            UserFocusDAL udal = new UserFocusDAL();
            int start = (pageindex - 1) * pagesize + 1;
            int end = pageindex * pagesize;
            return udal.GetList(start, end, uid);
        }

        public bool CheckFocus(int uid1,int uid2)
        {
            UserFocusDAL udal = new UserFocusDAL();
            return udal.CheckFocus(uid1,uid2) ;
        }
    }
}
