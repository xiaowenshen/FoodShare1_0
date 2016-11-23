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


    }
}
