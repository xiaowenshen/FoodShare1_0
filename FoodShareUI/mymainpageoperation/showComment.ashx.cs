using FoodShare.Model;
using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// showComment 的摘要说明
    /// </summary>
    public class showComment : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user = (UserInfo)(context.Session["uinfo"]);
            int index = 1;
            if (context.Request.Form["commentindex"] == null || !int.TryParse(context.Request.Form["commentindex"].ToString(), out index))
            {
                index = 1;
            }
            int pagesize = 6;
            CommentBLL cbll = new CommentBLL();
            int pagecount = cbll.GetPageCount(pagesize, user.UId);
            index = index < 1 ? 1 : index;
            index = index > pagecount ? pagecount : index;
            List<Comment> list = new List<Comment>();

            list = cbll.GetList(user.UId,index, pagesize);
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(index, pagecount);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            pagebar = pagebar.Replace("pageindex", "commentpageindex").Replace("pages", "commentpages");
            string json = js.Serialize(new { SList = list, PageBar = pagebar, Index = index ,UID =user.UId });
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