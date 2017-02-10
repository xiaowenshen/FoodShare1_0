using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShareDAL;
using FoodShareMODEL;
namespace FoodShareBLL
{
    public partial class CookBookBLL
    {
        CookBookDAL cdal = new CookBookDAL();
        /// <summary>
        /// 获取所有人的菜谱总数
        /// </summary>
        /// <returns></returns>
        public int GetMaxCount()
        {
            return cdal.GetMaxCount();
        }
        /// <summary>
        /// 获取个人的菜谱总数
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetMaxCount(int uid)
        {
            return cdal.GetMaxCount(uid);
        }
        /// <summary>
        /// 获取全部菜谱
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetList(int pageindex , int pagesize)
        {
            int start;
            int end;
            start = (pageindex - 1) * pagesize + 1;
            end = pageindex * pagesize;
            return cdal.GetCookBook(start, end);
        }
        /// <summary>
        /// 获取全部模糊查询菜谱（无分页）
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetList(string msg)
        {
            return cdal.GetCookBook(msg);
        }

        /// <summary>
        /// 获取全部模糊查询菜谱(有分页)
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetList(int pageindex, int pagesize, string msg)
        {
            int start;
            int end;
            start = (pageindex - 1) * pagesize + 1;
            end = pageindex * pagesize;
            return cdal.GetCookBook(start, end,msg);
        }
        /// <summary>
        /// 获取个人所有菜谱
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagecount"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<CookBook> GetList(int pageindex , int pagesize,int uid)
        {
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return cdal.GetCookBook(start, end, uid);
        }

        /// <summary>
        /// 获取页码数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize)
        {
            int works = cdal.GetMaxCount();
            return works % pagesize == 0 ? works / pagesize : works / pagesize + 1;
        }
        /// <summary>
        /// 获取页码数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize,int uid)
        {
            int works = cdal.GetMaxCount(uid);
            return Convert.ToInt32(Math.Ceiling(works * 1.0 / pagesize));
        }
        /// <summary>
        /// 添加菜谱
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public bool AddCookBook(CookBook cb)
        {
            return cdal.Add(cb);
        }
        /// <summary>
        /// 通过id获取菜谱
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public CookBook GetCookBookById(int cid)
        {
           return  cdal.GetCookBookById(cid);
        }
        /// <summary>
        /// 删除菜谱
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cid"></param>
        /// <returns></returns>
        public bool deleteCookBook(int uid ,int cid)
        {
            return cdal.DeleteCookBook(cid);
        }

        public bool EditCookBook(CookBook model)
        {
            return cdal.Update(model);
        }
    }
}
