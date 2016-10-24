using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareBLL;
using FoodShareMODEL;
namespace FoodShareUI
{
    /// <summary>
    /// checkAccount 的摘要说明
    /// </summary>
    public class checkAccount : IHttpHandler
    {
        UserInfoBLL ubll = new UserInfoBLL();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string account = context.Request["account"] != null ? context.Request["account"].ToString() : string.Empty;
            UserInfo info = ubll.GetUserInfo(account);
            if(info != null)
            {
                context.Response.Write("ERROR");
            }
            else
            {
                context.Response.Write("OK");
            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}