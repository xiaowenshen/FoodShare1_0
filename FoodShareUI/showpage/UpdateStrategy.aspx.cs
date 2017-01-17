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
    public partial class UpdateStrategy : System.Web.UI.Page
    {
        MyStrategyBLL sbll = new MyStrategyBLL();
        public MyStrategy ms { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int sid = -1;
            string URL = Request.Url.PathAndQuery;
            if (!int.TryParse(Request.QueryString["Sid"].ToString(), out sid))
            {
                Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));

            }
            if (LoadMyStrategy(sid) != null)
            {
                ms = LoadMyStrategy(sid);
            }
        }
        private MyStrategy LoadMyStrategy(int sid)
        {

            return sbll.GetMyStrategyById(sid);

        }

        protected void edit_Click(object sender, EventArgs e)
        {
            string content = Request.Form["content"] != null ? Request.Form["content"].ToString() : string.Empty;
            string title = Request.Form["title"] != null ? Request.Form["title"].ToString() : string.Empty;
            if (title != "" && title != " " && content != "" && content != " ")
            {
                ms.STitle = title;
                ms.SContent = content;
                if (sbll.Edit(ms))
                {
                    Response.Write("<script>alert('" + "修改成功！" + "')</script>");
                    Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));

                }
                else
                {
                    Response.Write("<script>alert('" + "修改失败！请稍后再试！" + "')</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('" + "内容，标题不能为空" + "')</script>");
            }

        }

        protected void returnmypage_Click(object sender, EventArgs e)
        {
            Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));

        }
    }
}