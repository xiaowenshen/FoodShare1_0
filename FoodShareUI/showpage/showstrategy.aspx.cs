﻿using FoodShareBLL;
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
    public partial class showstrategy : CheckSession
    {
     
        public MyStrategy ms { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int sid = -1;
           string URL =  Request.Url.PathAndQuery;
            if ( !int.TryParse(Request.QueryString["Sid"].ToString(),out sid))
            {
                Response.Redirect(Page.ResolveUrl("~/mymainpage.aspx"));

            }
            if(LoadMyStrategy(sid)!=null)
            {
                ms = LoadMyStrategy(sid);
            }
        }

        private MyStrategy LoadMyStrategy(int sid)
        {
            MyStrategyBLL sbll = new MyStrategyBLL();
            return sbll.GetMyStrategyById(sid);

        }
     


    }
}