using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareMODEL;
using System.Text;
using FoodShareBLL;
namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// addCookbookinfo 的摘要说明
    /// </summary>
    public class addCookbookinfo : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            CookBook cb = new CookBook();
            cb.addtime = DateTime.Now;
            cb.isdel = false;
            cb.path = context.Request.Form["path"];
            cb.UId = ((UserInfo)context.Session["uinfo"]).UId;
            cb.stepcount =Convert.ToInt32(context.Request.Form["spancount"].ToString());
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= cb.stepcount; i++)
            {
                sb.Append(context.Request.Form["introduce" + i].ToString()+"#");
            }
            cb.CContent = sb.ToString();
            cb.CIntroduce = context.Request.Form["CIntroduce"].ToString();
            cb.CTitle = context.Request.Form["CTitle"].ToString();
            CookBookBLL cbll = new CookBookBLL();
            if(cbll.AddCookBook(cb))
            {
                context.Response.Write("OK");
            }
            else
            {
                 context.Response.Write("ERROR");
            }
            
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