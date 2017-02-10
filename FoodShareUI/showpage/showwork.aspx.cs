using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShareUI.showpage
{
    public partial class showwork : System.Web.UI.Page
    {

        public MyWorks work { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int wid = -1;
            MyWorksBLL mbll = new MyWorksBLL();

            if (int.TryParse(Request.QueryString["wid"].ToString(), out wid) && wid != -1 )
            {

                string id = Request.QueryString["wid"].ToString();
                work = mbll.GetWorkById(wid);
            }
            else
            {
                Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
            }


        }
        

        protected void returnmypage_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));
        }
    }
}