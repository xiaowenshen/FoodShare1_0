using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// ShowMyStrategy 的摘要说明
    /// </summary>
    public class ShowMyStrategy : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid;
            UserInfo user = (UserInfo)(context.Session["uinfo"]);
            uid = user.UId;
            int index = 1;
            if(context.Request.Form["mspageindex"] == null || !int.TryParse(context.Request.Form["mspageindex"].ToString(),out index))
            {
                index = 1;
            }
            MyStrategyBLL mbll = new MyStrategyBLL();
            int pagesize = 8;
            int pagecount = mbll.GetPageCount(pagesize,uid);
            index = index < 1 ? 1 : index;
            index = index > pagecount ? pagecount : index;
            List<MyStrategy> list = new List<MyStrategy>();
            
            list = mbll.GetList(uid, index, pagesize);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(index, pagecount);
            pagebar = pagebar.Replace("pageindex", "mspageindex").Replace("pages", "mspages");
            string json = js.Serialize(new { SList = list,PageBar = pagebar });
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