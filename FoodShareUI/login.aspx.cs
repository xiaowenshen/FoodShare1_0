using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodShareMODEL;
using FoodShareBLL;
namespace FoodShare1_0
{
    public partial class login : System.Web.UI.Page
    {
        UserInfoBLL ubll = new UserInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            //验证用户名存不存在
            UserInfo info = new UserInfo();
            if(Session["uinfo"] == null )
            {
                string account = Request["account"].ToString();
                string pwd = Request["pwd"].ToString();
                info = ubll.GetUserInfo(account);
             //   Response.Write("<script>alert('111111111')</script>");
                if(info != null)
                {
                    if(info.pwd.Equals(pwd))
                    {
                        string url = "mypage.aspx?id=" + info.UId ;
                        Session["uinfo"] = info;
                   //     Response.Write("<script>alert('1111" + url + "')</script>");
                        Response.Redirect(url);
                    }
                    else
                    {
                        Response.Write("<script>alert('请输入正确的密码')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('请输入正确的用户名')</script>");
                }
            }
            else
            {
               
                string url = "mypage.aspx?id=" + info.UId;
             //   Response.Write("<script>alert('222222"+url+"')</script>");
                Response.Redirect(url);
            }

        }
    }
}