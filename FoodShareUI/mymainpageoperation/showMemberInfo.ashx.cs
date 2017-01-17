using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareBLL;
using FoodShareMODEL;
using FoodShareCOMMON;
namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// showMemberInfo 的摘要说明
    /// </summary>
    public class showMemberInfo : IHttpHandler ,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = 1;
            if(context.Request["index"] == null || !int.TryParse(context.Request["index"].ToString(),out index))
            {
                index = 1;
            }
            int pagesize = 4;
            UserInfoBLL uill = new UserInfoBLL();
            int pagecount = uill.GetPageCount(pagesize);
            index = index <= 0 ? 1 : index;
            index = index > pagecount ? pagecount : index;
            List<UserInfo> list = uill.GetUserInfoList(index, pagesize);
            string pagebar = PageBarHelper.GetPageBar(index, pagecount);
            pagebar = pagebar.Replace("pageindex", "memberindex").Replace("pages", "focuspages");
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
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
    }
}