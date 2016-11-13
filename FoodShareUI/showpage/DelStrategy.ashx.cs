using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.showpage
{
    /// <summary>
    /// DelStrategy 的摘要说明
    /// </summary>
    public class DelStrategy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int sid = Convert.ToInt32(context.Request.Form["sid"]);
            MyStrategyBLL mbll = new MyStrategyBLL();
            string res;
            if(mbll.Delete(sid))
            {
                res = "ok";
            }
            else
            {
                res = "error";
            }
            context.Response.Write( res);
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