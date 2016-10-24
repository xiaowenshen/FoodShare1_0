using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoodShareMODEL;
using FoodShareBLL;
namespace FoodShare1_0
{
    /// <summary>
    /// register 的摘要说明
    /// </summary>
    public class register : IHttpHandler
    {
        UserInfoBLL ubll = new UserInfoBLL();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //接收数据
            string name = context.Request["name"] != null ? context.Request["name"].ToString() : string.Empty;
            string account = context.Request["account"]  != null ? context.Request["account"].ToString() : string.Empty;
            string pwd = context.Request["pwd"] != null ? context.Request["pwd"].ToString() : string.Empty;
            string email = context.Request["email"] != null ? context.Request["email"].ToString() : string.Empty;
            string question = context.Request["uquestion"] != null ? context.Request["uquestion"].ToString() : string.Empty;
            string ans = context.Request["uanswer"] != null ? context.Request["uanswer"].ToString() : string.Empty;
            UserInfo info = new UserInfo();
            info.name = name;
            info.account = account;
            info.pwd = pwd;
            info.email = email;
            info.addtime = DateTime.Now;
            info.answer = ans;
            info.question = question;
            info.sex = true;
            info.isdel = false;
            info.address = string.Empty;
            info.birthday = string.Empty;
            info.introduce = string.Empty;
            info.introduce = string.Empty;
            info.display = string.Empty;
            
            if(ubll.Add(info))
            {
                context.Response.Write("OK");
            }
            else
            {
                context.Response.Write("ERROR");
            }




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