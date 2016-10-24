using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareCOMMON
{
    public class PageBarHelper
    {
        /// <summary>
        /// 生成数字页码条 包含上下首末页  
        /// </summary>
        /// <param name="pageindex">当前页码</param>
        /// <param name="pagecount">总页数</param>
        /// <returns></returns>
        public static string GetPageBar(int pageindex,int pagecount)
        {
            //如果只有一页  不需要数字页码条
            if(pagecount==1)
            {
                return string.Empty;
            }

            if(pageindex<=0)
            {
                pageindex = 1;
            }
            if(pageindex>pagecount)
            {
                pageindex = pagecount;
            }
            //计算开始结束值
            int start = pageindex - 5;
            if(start<=0)
            {
                start = 1;
            }
            int end = start + 9;
            if(end>pagecount)
            {
                end = pagecount;
                start = pagecount - 9 < 1 ? 1 : pagecount - 9;
            }
            StringBuilder sb = new StringBuilder();
            //添加上一页和首页
            if(pageindex==1)
            {
                sb.Append("<span class=\"disabled_page\">首页</span><span class=\"disabled_page\">上一页</span>");

            }
            else if(pageindex>1)
            {
                sb.AppendFormat("<a href='?pageindex=1'> 首页 </a><a href='?pageindex={0}' class = 'pages'> 上一页 </a>",pageindex - 1);

            }
            //添加数字条
            for (int i  = start; i  <= end; i ++)
            {
                if(i==pageindex)
                {
                    //访问当前页 不用加超链接
                    sb.AppendFormat("<a href='javascript:void(0)' class=\"active\"> {0} </a>",i);
                }
                else
                {
                    //加超链接
                    sb.AppendFormat("<a href='?pageindex={0}' class = 'pages'> {0} </a>", i);

                }
                
            }
            //添加末页，下一页
            if (pageindex == pagecount)
            {
                sb.Append("<span class=\"disabled_page\">下一页</span><span class=\"disabled_page\">末页</span>");

            }
            else if (pageindex >= 1)
            {
                sb.AppendFormat("<a href='?pageindex={0}' class = 'pages'> 下一页 </a><a href='?pageindex={1}' class = 'pages'> 末页 </a>", pageindex + 1 > pagecount ? pagecount : pageindex + 1, pagecount);

            }
            return sb.ToString();
        }

    }
}
