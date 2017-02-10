using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

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

            context.Response.ContentType = "text/plain";
            UserInfo user = context.Session["uinfo"]==null ? null : (UserInfo)context.Session["uinfo"];
            if(user == null )
            {
                Page pg = new Page();
                context.Response.Redirect(pg.ResolveUrl("~/login.aspx"));
            }
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