using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareCOMMON;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// showWorks 的摘要说明
    /// </summary>
    public class showWorks : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user = (UserInfo)context.Session["uinfo"];
            int index = 1;
            if (context.Request["worksindex"] == null || !int.TryParse(context.Request["worksindex"], out index)) 
            {
                index = 1;
            }
            int pagesize = 6;
            MyWorksBLL mbll = new MyWorksBLL();
            int pagecount = mbll.GetPageCount(pagesize,user.UId);
            index = index <= 0 ? 1 : index;
            index = index >= pagecount ? pagecount : index;

            List<MyWorks> list = new List<MyWorks>();
            list = mbll.GetList(user.UId, pagesize, index);
            string pagebar = PageBarHelper.GetPageBar(index, pagecount);
            pagebar = pagebar.Replace("pageindex", "worksindex").Replace("pages", "workspages");
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
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