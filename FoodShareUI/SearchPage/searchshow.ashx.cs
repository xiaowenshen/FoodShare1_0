using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareMODEL;
using FoodShareBLL;
using FoodShareCOMMON;

namespace FoodShareUI.SearchPage
{
    /// <summary>
    /// searchshow 的摘要说明
    /// </summary>
    public class searchshow : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if(context.Request.Form["msg"] == null || context.Request.Form["msg"].ToString().Trim() == "")
            {
                context.Response.Redirect("Search.aspx");
            }
      
            string msg = context.Request.Form["msg"].ToString().Trim();
            //作品进行查找
            MyWorksBLL mybll = new MyWorksBLL();
            List<MyWorks>  works = mybll.GetList(msg);
            //菜谱查找
            CookBookBLL cbll = new CookBookBLL();
            List<CookBook> cookbook = cbll.GetList(msg);
            //用户查找
            UserInfoBLL ubll = new UserInfoBLL();
            List<UserInfo> user = ubll.GetUserInfoList(msg);

            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string jsondata = js.Serialize(new { Works = works, CookBook = cookbook, User = user });
            context.Response.Write(jsondata);
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