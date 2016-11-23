using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// UploadCookBook 的摘要说明
    /// </summary>
    public class UploadCookBooks : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
           int count = Convert.ToInt32(context.Request.Form["count"]);
            context.Session["count"] = count;
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("一共有<span name = 'spancount' id='spancount'>{0}</span>步<br/>",count);
            for(int i= 1;i <= count; i++)
            {
                sb.AppendFormat("第{0}步：<br/><div><textarea placeholder=\"步骤介绍...\" name=\"{1}\"></textarea></div><br/>",i, "introduce" + i);
            }
            context.Response.Write(sb.ToString());
       
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