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
    /// showFocus 的摘要说明
    /// </summary>
    public class showFocus : IHttpHandler ,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user = (UserInfo)context.Session["uinfo"];
            UserFocusBLL ubll = new UserFocusBLL();
            int uid = user.UId;
            int focusindex;
            if (context.Request["focusindex"] == null || !int.TryParse(context.Request["focusindex"].ToString(), out focusindex))
            {
                focusindex = 1;
            }
            int pagesize = 4;
            int pagecount = ubll.GetPageCount(pagesize , uid);
            focusindex = focusindex < 1 ? 1 : focusindex;
            focusindex = focusindex > pagecount ? pagecount : focusindex;
            string PageBar = PageBarHelper.GetPageBar(focusindex, pagecount);
            PageBar = PageBar.Replace("pageindex", "focusindex");
            List<UserFocus> list = new List<UserFocus>();
            list = ubll.GetList(uid, pagesize, focusindex);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(focusindex, pagecount);
            pagebar = pagebar.Replace("pageindex", "focusindex").Replace("pages", "focuspages");
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

        public object UserFocusBLL { get; private set; }
    }
}