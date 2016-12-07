using FoodShareBLL;
using FoodShareMODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodShareUI.GuideShow
{
    /// <summary>
    /// showtop 的摘要说明
    /// </summary>
    public class showtop : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
           
            int cookpagesize = 3;
            CookBookBLL cbll = new CookBookBLL();
            List<CookBook> list = new List<CookBook>();

            list = cbll.GetList(1, cookpagesize);
            System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            
            string json = js.Serialize(new { SList = list});
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