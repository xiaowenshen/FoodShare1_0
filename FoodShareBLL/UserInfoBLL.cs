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

        public List<UserInfo> GetUserInfoList(int index , int pagesize ,string msg)
        {
            int start = (index - 1) * pagesize;
            int end = index * pagesize;
            return udal.GetUserInfoList(start , end, msg);
        }
    }
}
