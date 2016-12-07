using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI
{
    /// <summary>
    /// ShowStrategy 的摘要说明
    /// </summary>
    public class ShowStrategy : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int index = 1;
            if(context.Request["mspageindex"] == null || !int.TryParse(context.Request["mspageindex"].ToString(),out index))
            {
                index = 1;//
            }
            MyStrategyBLL sbll = new MyStrategyBLL();
            int pagesize = 6;
            int pagecount = sbll.GetPageCount(pagesize);
            index = index <= 0 ? 1 : index;
            index = index >= pagecount ? pagecount : index;
            string pagebar = FoodShareCOMMON.PageBarHelper.GetPageBar(index, pagecount);
            pagebar = pagebar.Replace("pageindex", "mspageindex").Replace("pages","mspages");
            List<MyStrategy> list = sbll.GetList(index, pagesize);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = js.Serialize(new { SList = list, PageBar = pagebar });
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}