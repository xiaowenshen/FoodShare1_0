using FoodShare.Model;
using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// addComment 的摘要说明
    /// </summary>
    public class addComment : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            UserInfo user1 = (UserInfo)context.Session["uinfo"];
            UserInfo user2 = new UserInfo();
            UserInfoBLL ubll = new UserInfoBLL();
            CommentBLL cbll = new CommentBLL();
            int u2id = Convert.ToInt32(context.Request.Form["u2id"]);
            
            user2 = ubll.GetUserInfoById(u2id);

            string res = "";
            if(user1 == null)
            {
                res = "UNRES";
            }
          
            Comment ct = new Comment();
            //LoadInfo(user1,user2,ct);
            ct.addtime = DateTime.Now;
            ct.comment = context.Request.Form["msg"] != null ? context.Request.Form["msg"] : string.Empty;
            ct.isdel = false;
            ct.U1name = user1.name;
            ct.UId1 = user1.UId;
            ct.U1path = user1.display;
            ct.U2name = user2.name;
            ct.U2path = user2.display;
            ct.UId2 = user2.UId;

            if(cbll.Add(ct))
            {
                res = "OK";
            }
            else
            {
                res = "ERROR";
            }

            context.Response.Write(res);
                
        }
        private void LoadInfo(UserInfo user1, UserInfo user2, Comment ct)
        {
            

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