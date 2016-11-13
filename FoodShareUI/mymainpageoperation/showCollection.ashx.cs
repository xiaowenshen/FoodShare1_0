using FoodShareBLL;
using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// showCollection 的摘要说明
    /// </summary>
    public class showCollection : IHttpHandler ,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid;
            UserInfo user = (UserInfo)(context.Session["uinfo"]);
            CollectTableBLL cbll = new CollectTableBLL();
            uid = user.UId;
            List<CookBook> list = new List<CookBook>();
            list = cbll.GetCollectTable(uid);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { SList = list });
            context.Response.Write(json);
            //int cookindex;
            //if (context.Request["cbindex"] == null || !int.TryParse(context.Request["cbindex"].ToString(), out cookindex))
            //{
            //    cookindex = 1;
            //}
            //int cookpagesize = 6;
            //int cookpagecount = cbll.GetPageCount(cookpagesize , uid);
            //cookindex = cookindex < 1 ? 1 : cookindex;
            //cookindex = cookindex > cookpagecount ? cookpagecount : cookindex;
            //string cookPageBar = PageBarHelper.GetPageBar(cookindex, cookpagecount);
            //cookPageBar = cookPageBar.Replace("pageindex", "cbindex");
            //string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(cookindex, cookpagecount);
            //pagebar = pagebar.Replace("pageindex", "cbindex").Replace("pages", "cbpages");
        
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