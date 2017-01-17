using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// CheckFocus 的摘要说明
    /// </summary>
    public class CheckFocus : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";
            UserFocusBLL ubll = new UserFocusBLL();
            //判断状态
            int state = -1;//未登录
            int focus = -1;//未关注

            if(context.Session["uinfo"] != null)
            {
                UserInfo user1 =(UserInfo)context.Session["uinfo"];
                state = 1;//登陆了 
                if(context.Session["cuinfo"]!=null  )
                {
                    UserInfo user2 = (UserInfo)context.Session["cuinfo"];
                    focus = ubll.CheckFocus(user1.UId, user2.UId) == true ? 1 : -1;//1为关注，-1为未关注
                }
                


            }
            int[] result = { state, focus };
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { State = state , Focus = focus });
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