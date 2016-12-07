using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.GuideShow
{
    /// <summary>
    /// ShowMenu 的摘要说明
    /// </summary>
    public class ShowMenu : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        ManageMenuBLL mmbll = new ManageMenuBLL();
        public void ProcessRequest(HttpContext context)
        {
         
            context.Response.ContentType = "text/plain";
            int index = 1;
            if (context.Request.Form["menupageindex"] == null || !int.TryParse(context.Request.Form["menupageindex"].ToString(), out index))
            {
                index = 1;
            }
            int pagesize = 3;
            int pagecount = mmbll.GetPageCount(pagesize);
            index = index < 1 ? 1 : index;
            index = index > pagecount ? pagecount : index;
            List<ManageMenu> list = new List<ManageMenu>();

            list = mmbll.GetList(index, pagesize);
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(index, pagecount);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            pagebar = pagebar.Replace("pageindex", "menupageindex").Replace("pages", "menupages");
            string json = js.Serialize(new { SList = list, PageBar = pagebar, Index = index });
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