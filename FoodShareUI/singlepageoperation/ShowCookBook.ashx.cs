using FoodShareBLL;
using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// ShowCookBook 的摘要说明
    /// </summary>
    public class ShowCookBook : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            int cookindex;
            int uid;
            UserInfo user = (UserInfo)(context.Session["cuinfo"]);
            uid = user.UId;
            if (context.Request["cbindex"] == null || !int.TryParse(context.Request["cbindex"].ToString(), out cookindex))
            {
                cookindex = 1;
            }
            int cookpagesize = 6;
            CookBookBLL cbll = new CookBookBLL();
            int cookpagecount = cbll.GetPageCount(cookpagesize,uid);
            cookindex = cookindex < 1 ? 1 : cookindex;
            cookindex = cookindex > cookpagecount ? cookpagecount : cookindex;
            string cookPageBar = PageBarHelper.GetPageBar(cookindex, cookpagecount);
            cookPageBar = cookPageBar.Replace("pageindex", "cbindex");
            List<CookBook> list = new List<CookBook>();
            
            list = cbll.GetList(cookindex, cookpagesize, uid);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(cookindex, cookpagecount);
            pagebar = pagebar.Replace("pageindex", "cbindex").Replace("pages", "cbpages");
            string json = js.Serialize(new { SList = list, PageBar = pagebar });
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