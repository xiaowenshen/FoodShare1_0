﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodShareCOMMON;
using FoodShareDAL;
using FoodShareMODEL;

namespace FoodShareBLL
{
    public partial class MyWorksBLL
    {
        MyWorksDAL mdal = new MyWorksDAL();
        /// <summary>
        /// 获取指定范围
        /// </summary>
        /// <param name="uid">用户的id</param>
        /// <param name="pagesize">每页显示量</param>
        /// <param name="pageindex">当前页码数</param>
        /// <returns></returns>
        public List<MyWorks> GetList(int uid , int pagesize, int pageindex)
        {
            int start = (pageindex - 1) * pagesize + 1 ;
            int end = pagesize * pageindex ;
            return mdal.GetList(uid, start, end);
        }
        /// <summary>
        /// 获取指定范围
        /// </summary>
        /// <param name="pagesize">每页显示量</param>
        /// <param name="pageindex">当前页码数</param>
        /// <returns></returns>
        public List<MyWorks> GetList(int pagesize, int pageindex)
        {
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mdal.GetList(start, end);
        }
        /// <summary>
        /// 获取所有的作品
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<MyWorks> GetList()
        {
            return mdal.GetList();
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<MyWorks> GetList(int pagesize, int pageindex,string msg)
        {
            int start = (pageindex - 1) * pagesize + 1;
            int end = pagesize * pageindex;
            return mdal.GetList(start , end, msg);
        }

        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<MyWorks> GetList(string msg)
        {
            
            return mdal.GetList( msg);
        }
        /// <summary>
        /// 获取页码数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize)
        {
            int works = mdal.GetMaxCount();
            return works % pagesize == 0 ? works / pagesize : works / pagesize + 1;
        }
        /// <summary>
        /// 获取页码数
        /// </summary>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public int GetPageCount(int pagesize,int uid)
        {
            int works = mdal.GetMaxCount(uid);
            return works % pagesize == 0 ? works / pagesize : works / pagesize + 1;
        }

        //编辑作品
        public Boolean UploadWork(MyWorks model)
        {
            return mdal.Add(model) > 0;
        }

        //删除作品
        public bool Delete(int wid)
        {
            return mdal.Delete(wid);
        }
    }
}
