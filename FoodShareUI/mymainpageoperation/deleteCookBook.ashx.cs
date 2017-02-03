using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// deleteCookBook 的摘要说明
    /// </summary>
    public class deleteCookBook : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int cid = -1;
            int res = 0;
            UserInfo user = new UserInfo();
            if (context.Session["uinfo"] != null)
            {
                user = (UserInfo)context.Session["uinfo"];
            }
            if ( context.Request["cid"] != null && int.TryParse(context.Request["cid"].ToString(),out  cid) )
            {
                CookBookBLL cbll = new CookBookBLL();
               
                if(cbll.deleteCookBook(user.UId,cid))
                {
                    res = 1;
                }
            }
            context.Response.Write(res);
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