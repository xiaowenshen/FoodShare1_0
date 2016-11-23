using FoodShareBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// deleteFocus 的摘要说明
    /// </summary>
    public class deleteFocus : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int fid = -1;
            string result = "";
            if(context.Request.Form["fid"] == null || !int.TryParse(context.Request.Form["fid"].ToString(),out fid))
            {
                result = "NO_GET_NUM";
            }
            UserFocusBLL fbll = new UserFocusBLL();
            if(fbll.delete(fid))
            {
                result = "OK";
            }
            else
            {
                result = "FID_ERROR";
            }
            context.Response.Write(result);

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