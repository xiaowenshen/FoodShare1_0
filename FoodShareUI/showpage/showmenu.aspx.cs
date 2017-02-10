using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodShareUI.showpage
{
    public partial class showmenu : System.Web.UI.Page
    {
        public List<FoodMenu> List { get; set; }
        public string showitem { get; set; }
        public string FoodMenuName { get; set; }
        public string FoodIntroduce { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadMenu();
        }

        private void LoadMenu()
        {
            int MenuId = -1;
            if(Request.QueryString["MenuId"] == null || !int.TryParse(Request.QueryString["MenuId"].ToString(),out MenuId))
            {
                Response.Redirect("mymainpage.aspx");
            }
            FoodMenuBLL FBLL = new FoodMenuBLL();
            List<FoodMenu> list =  FBLL.GetList(MenuId);
           
            if(list != null && list.Count > 0)
            {
                FoodMenuName = list[0].FName;
                FoodIntroduce = list[0].FIntroduce;
                List = list;
                StringBuilder sb = new StringBuilder();
                foreach (var item in List)
                {
                    sb.AppendFormat("<div class='view view-third'><a href = '{0}' class='b-link-stripe b-animate-go  swipebox'  title='{1}'><img src = '../{2}' style=\"width: 360px; height: 260px\" class='img-responsive'/><div class=\"mask\"><h2>{3}</h2><p>{4}</p><a href='/showcookbook.aspx?cid={5}&op=0' target='_blank' ><span class=\"gall\">More</span></a></div></a></div>", item.Path,item.CTitle,item.Path, item.CTitle, item.CIntroduce,item.CId);
                }
                showitem = sb.ToString();
            }
            else
            {
                ManageMenuBLL mbll = new ManageMenuBLL();
                ManageMenu mm =  mbll.GetManageMenuById(MenuId);
                FoodMenuName = mm.MenuName;
                FoodIntroduce = mm.MenuIntroduce;
              showitem = "<div>菜单是空的！~</div>";
                

            }
        }

    }
}