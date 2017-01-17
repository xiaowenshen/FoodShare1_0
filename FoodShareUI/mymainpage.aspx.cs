using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodShareMODEL;
using FoodShareBLL;
using FoodShareCOMMON;
namespace FoodShareUI
{
    public partial class mymainpage : CheckSession
    {
   
        public UserInfo Uinfo {get; set;}
       
        protected void Page_Load(object sender, EventArgs e)
        {
            Uinfo = (UserInfo)Session["uinfo"];
        }
    }
}