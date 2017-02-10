using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.mymainpageoperation
{
    /// <summary>
    /// addtomenulist 的摘要说明
    /// </summary>
    public class addtomenulist : IHttpHandler , System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string res = "OK";
            UserInfo user = context.Session["uinfo"] == null ? null : (UserInfo)context.Session["uinfo"];
            if(user ==null)
            {
                res = "NOLOG";
                context.Response.Write(res);
            }
            string[] content = context.Request["text"] != null ? context.Request["text"].ToString().Split(',') : null;
           int cid =  context.Request["cid"] != null ? Convert.ToInt32(context.Request["cid"].ToString()) :　-1;
          
            int test = Convert.ToInt32(context.Request["cid"].ToString());
            if (user!=null && content.Length>0 && cid !=-1)
            {
                CookBookBLL CBLL = new CookBookBLL();
                CookBook CB = CBLL.GetCookBookById(cid);
                foreach (string item in content)
                {
                    ManageMenuBLL mbll = new ManageMenuBLL();
                    ManageMenu mm = mbll.GetManageMenuById(Convert.ToInt32(item));
                    FoodMenuBLL FBLL = new FoodMenuBLL();
                    FoodMenu fmenu = new FoodMenu();
                    fmenu.CId = cid;
                    fmenu.CIntroduce = CB.CIntroduce;
                    fmenu.CName = CB.CTitle;
                    fmenu.CTitle = CB.CTitle;
                    fmenu.FIntroduce = mm.MenuIntroduce;
                    fmenu.FName = mm.MenuName;
                    fmenu.ClassID = Convert.ToInt32(item);
                    fmenu.UId = user.UId;
                    if(!FBLL.Add(fmenu))
                    {
                        res = "error";
                    }
                }
            }
            else
            {
                res = "error";
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