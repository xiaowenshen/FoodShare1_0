using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShareDAL;
using FoodShareMODEL;
namespace FoodShareBLL
{
    public partial class UserInfoBLL
    {
        UserInfoDAL udal = new UserInfoDAL();
        // <summary>
        /// 通过用户名获取对象
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public UserInfo GetUserInfo(string account)
        {
            return udal.GetInfo(account);

        }

        public bool Add(UserInfo info )
        {
            return udal.Add(info) > 0;

        }

        public UserInfo GetUserInfoById(int uid)
        {
            return udal.GetUserInfoById(uid);
        }

        public List<UserInfo> GetUserInfoList( string msg)
        {
            return udal.GetUserInfoList(msg);
        }
        //模糊查询
        public List<UserInfo> GetUserInfoList(int index , int pagesize ,string msg)
        {
            int start = (index - 1) * pagesize;
            int end = index * pagesize;
            return udal.GetUserInfoList(start , end, msg);
        }

        //获取页码数
        public int GetPageCount(int pagesize)
        {
            return  Convert.ToInt32(Math.Ceiling( udal.GetTotalCount()*1.0/pagesize));
        }

        //获取分页列表
        public List<UserInfo> GetUserInfoList(int pageindex, int pagesize)
        {
            int start = (pageindex - 1) * pagesize;
            int end = pagesize * pageindex;
            return udal.GetUserInfoList(start, end);


        }
    }
}
