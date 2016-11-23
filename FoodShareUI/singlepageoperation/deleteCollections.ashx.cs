using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// deleteCollection 的摘要说明
    /// </summary>
    public class deleteCollections : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int cid = -1;
            string res = "";
            if(context.Request.Form["menuid"]==null || !int.TryParse(context.Request.Form["menuid"].ToString(),out cid))
            {
                res = "ERROR";
            }
            CollectTableBLL cbll = new CollectTableBLL();
            int uid = ((UserInfo)context.Session["cuinfo"]).UId;
            if(cbll.Delete(cid,uid))
            {
                res = "OK";

            }
            else
            {
                res = "ERROR";
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