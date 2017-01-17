using FoodShareBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// deleteWork 的摘要说明
    /// </summary>
    public class deleteWork : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int res = 0;
            int wid = -1;
            if (context.Request["wid"] != null)
            {
                MyWorksBLL MBLL = new MyWorksBLL();
                wid = Convert.ToInt32(context.Request["wid"]);
                if (MBLL.Delete(wid) )
                    res = 1;

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