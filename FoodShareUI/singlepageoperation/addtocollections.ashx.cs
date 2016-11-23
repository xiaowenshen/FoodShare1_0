using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// addtocollection 的摘要说明
    /// </summary>
    public class addtocollections : IHttpHandler , System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int menuid = -1;
            string result = "";
            if(context.Request.Form["menuid"] == null || !int.TryParse(context.Request.Form["menuid"].ToString(),out menuid))
            {
                result = "ERROR";
            }
            CollectTableBLL ctbll = new CollectTableBLL();
            UserInfo user = (UserInfo)context.Session["cuinfo"];

            if(ctbll.IsExistCollectTable(menuid , user.UId))
            {
                result = "EXIST";
            }
            else if(ctbll.Add(LoadCookTable(menuid, user.UId)))
            {
                result = "OK";
            }
            else
            {
                result = "ERROR";

            }
            context.Response.Write(result);
        }

        private CollectTable LoadCookTable(int menuid,int uid)
        {
            CollectTable ct = new CollectTable();
            ct.addtime = DateTime.Now;
            ct.CId = menuid;
            ct.isdel = false;
            ct.UId = uid;
            return ct;

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