using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// ShowMenuList 的摘要说明
    /// </summary>
    public class ShowMenuList : IHttpHandler , System.Web.SessionState.IRequiresSessionState
    {

        ManageMenuBLL mmbll = new ManageMenuBLL();
        public void ProcessRequest(HttpContext context)
        {
            UserInfo user = (UserInfo)context.Session["uinfo"];
            context.Response.ContentType = "text/plain";
            List<ManageMenu> list = new List<ManageMenu>();
            list = mmbll.GetList( user.UId);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { SList = list });
            context.Response.Write(json);
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