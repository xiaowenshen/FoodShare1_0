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
    public partial class singlepage : System.Web.UI.Page
    {

        MyWorksBLL mbll = new MyWorksBLL();
        CookBookBLL cbll = new CookBookBLL();
        public string WorkPageBar { get; set; }
        public string CookPageBar { get; set; }

        public UserInfo Uinfo { get; set; }
        //记录作品集当前index
        public int WorkIndex { get; set; }
        //记录作品一共多少页
        public int WorkPageCount { get; set; }
        //记录菜谱索引
        public int CookIndex { get; set; }
        //记录菜谱总页数
        public int CookPageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            int cid = 0;
            if(Request.QueryString["cid"] == null || !int.TryParse(Request.QueryString["cid"].ToString(),out cid))
            {
                Response.Redirect("TESTGUID.aspx");
            }
            UserInfoBLL ubll = new UserInfoBLL();
            UserInfo user = ubll.GetUserInfoById(cid);
            if(user != null)
            {
                Uinfo = user;
                Session["cuinfo"] = user;
            }
            ShowMyWorks();
            
        }
        /// <summary>
        /// 展示作品
        /// </summary>
        private void ShowMyWorks()
        {
            int workindex;
            if (Request["pageindex"] == null || !int.TryParse(Request["pageindex"].ToString(), out workindex))
            {
                workindex = 1;
            }
            int workpagesize = 6;
            int workpagecount = mbll.GetPageCount(workpagesize,Uinfo.UId);
            workindex = workindex < 1 ? 1 : workindex;
            workindex = workindex > workpagecount ? workpagecount : workindex;
            WorkIndex = workindex;
            WorkPageCount = workpagecount;
            WorkPageBar = PageBarHelper.GetPageBar(WorkIndex, WorkPageCount);
            Repeater1.DataSource = mbll.GetList(Uinfo.UId, workpagesize, workindex);
            Repeater1.DataBind();
        }
    }
}