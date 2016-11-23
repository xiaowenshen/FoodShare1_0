using FoodShare.Model;
using FoodShareDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShareBLL
{
   public partial  class CommentBLL
    {
        /// <summary>
        /// 获取分页页码数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize,int uid)
        {
            CommentDAL cdal = new CommentDAL();
            int totalcount = cdal.GetRecordCount(uid);
            return pagesize > 0 && totalcount > 0 ? Convert.ToInt32(Math.Ceiling(1.0 * totalcount / pagesize )) : 0;
        }
        /// <summary>
        /// 获取分页列表
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="index"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<Comment> GetList(int uid,int index , int pagesize)
        {

            CommentDAL cdal = new CommentDAL();
            int start = (index - 1) * pagesize + 1;
            int end = pagesize * index;
            return cdal.GetList(uid, start, end);
        }

        /// <summary>
        /// 添加留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        public bool Add(Comment model)
        {

            CommentDAL cdal = new CommentDAL();
            return cdal.Add(model) > 0;
        }
        /// <summary>
        /// 修改留言
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Comment model )
        {
            CommentDAL cdal = new CommentDAL();
            return cdal.Update(model);
        }
        /// <summary>
        /// 删除留言
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public bool Delete(int mid)
        {

            CommentDAL cdal = new CommentDAL();
            return cdal.Delete(mid);
        }
    }
}
