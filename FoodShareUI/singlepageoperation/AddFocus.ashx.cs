using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.singlepageoperation
{
    /// <summary>
    /// AddFocus 的摘要说明
    /// </summary>
    public class AddFocus : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int res = 0;
            if (context.Session["uinfo"] != null && context.Session["cuinfo"] != null)
            {
                UserFocusBLL ubll = new UserFocusBLL();
                UserInfo user1 = (UserInfo)context.Session["uinfo"];
                UserInfo user2 = (UserInfo)context.Session["cuinfo"];
                UserFocus uf = new UserFocus();
                //添加uf的信息
                uf.addtime = DateTime.Now;
                uf.isdel = false;
                uf.U1name = user1.name;
                uf.U2Introduce = user2.introduce;
                uf.U2name = user2.name;
                uf.U2path = user2.display;
                uf.UId1 = user1.UId;
                uf.UId2 = user2.UId;
                if(ubll.Add(uf))
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