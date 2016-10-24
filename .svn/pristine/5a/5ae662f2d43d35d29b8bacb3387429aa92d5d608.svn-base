using FoodShareCOMMON;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShare1_0
{
    public partial class mypage : CheckSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
           {
               int id;

               UserInfo info = (UserInfo)Session["uinfo"];
               string passid = Request["id"] != null ? Request["id"].ToString() : string.Empty;
               if (int.TryParse(passid, out id) && info != null)
               {

                   if (info.UId != id)
                   {
                       Session["uinfo"] = null;
                       Response.Redirect("login.aspx");
                   }
               }
           }
           else
           {
               Session["uinfo"] = null;
               Response.Redirect("login.aspx");
           }

        }
    }
}