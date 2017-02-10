using FoodShareBLL;
using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShareUI.showpage
{
    public partial class editWork : CheckSession
    {


      public  MyWorks work { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = -1;
            MyWorksBLL mbll = new MyWorksBLL();
            UserInfo user = (UserInfo)Session["uinfo"];
           
            if (int.TryParse(Request.QueryString["wid"].ToString(), out wid)&&wid!=-1&&mbll.IsUserWork(user.UId,wid))
            {

                string  id = Request.QueryString["wid"].ToString();
                work = mbll.GetWorkById(wid);
            }
            else
            {
                Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
            }
            

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            MyWorksBLL mbll = new MyWorksBLL();
            work.WTitle = Request["title"].ToString();
            work.introduce = Request["content"].ToString();
            if (mbll.UpDate(work))
            {
                Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
            }
            else
            {
                Response.Write("alert('修改失败，请稍后再试！')");
            }
        }

        protected void returnmypage_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
        }
    }
}