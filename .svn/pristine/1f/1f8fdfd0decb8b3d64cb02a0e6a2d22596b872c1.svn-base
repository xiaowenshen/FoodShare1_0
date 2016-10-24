using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace FoodShareCOMMON
{
    public  class CheckSession : System.Web.UI.Page
    {
        public void page_Init()
        {
            if(Session["uinfo"]==null)
            {
                Response.Redirect("login.aspx");
            }

        }

    }
}
