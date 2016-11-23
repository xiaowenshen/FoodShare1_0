using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// ShowCollection 的摘要说明
    /// </summary>
    public class ShowCollection : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid;
            UserInfo user = (UserInfo)(context.Session["cuinfo"]);
            CollectTableBLL cbll = new CollectTableBLL();
            uid = user.UId;
            List<CookBook> list = new List<CookBook>();
            list = cbll.GetCollectTable(uid);
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