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
        MyWorksBLL mbll = new MyWorksBLL();
        CookBookBLL cbll = new CookBookBLL();
        public string WorkPageBar { get; set; }
        public string CookPageBar { get; set; }

        public UserInfo Uinfo {get; set;}
        //记录作品集当前index
        public int WorkIndex { get; set;}
        //记录作品一共多少页
        public int WorkPageCount { get; set; }
        //记录菜谱索引
        public int CookIndex { get; set; }
        //记录菜谱总页数
        public int CookPageCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Uinfo = (UserInfo)Session["uinfo"];
            ShowMyWorks();
            ShowCookBook();
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
            int workpagecount = mbll.GetPageCount(workpagesize);
            workindex = workindex < 1 ? 1 : workindex;
            workindex = workindex > workpagecount ? workpagecount : workindex;
            WorkIndex = workindex;
            WorkPageCount = workpagecount;
            WorkPageBar = PageBarHelper.GetPageBar(WorkIndex, WorkPageCount);
            Repeater1.DataSource = mbll.GetList(Uinfo.UId, workpagesize, workindex);
            Repeater1.DataBind();
        }
        /// <summary>
        /// 展示菜谱
        /// </summary>
        private void ShowCookBook()
        {
            int cookindex;
            if(Request["CookIndex"] == null || !int.TryParse(Request["CookIndex"].ToString(), out cookindex))
            {
                cookindex = 1;
            }
            int cookpagesize = 6;
            int cookpagecount = cbll.GetPageCount(cookpagesize);
            cookindex = cookindex < 1 ? 1 : cookindex;
            cookindex = cookindex > cookpagecount ? cookpagecount : cookindex;
            CookIndex = cookindex;
            CookPageCount = cookpagecount;
            string cookPageBar = PageBarHelper.GetPageBar(cookindex, cookpagecount);
            cookPageBar = cookPageBar.Replace("pageindex", "CookIndex");
            CookPageBar = cookPageBar;
            Repeater2.DataSource = cbll.GetList(cookindex, cookpagesize,Uinfo.UId);
            Repeater2.DataBind();

        }

    }
}