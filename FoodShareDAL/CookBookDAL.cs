using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FoodShareDAL;
using FoodShareMODEL;
using System.Data.SqlClient;
namespace FoodShareDAL
{
    /// <summary>
    /// 数据访问类:CookBook
    /// </summary>
    public partial class CookBookDAL
    {
        public CookBookDAL()
        { }


        public CookBook  GetCookBookById(int cid)
        {
            CookBook cb = new CookBook();
            string sql = "select * from CookBook where isdel = 0 and CId =@cid";
            SqlParameter p = new SqlParameter("@cid", SqlDbType.Int);
            p.Value = cid;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql , p);
            if(dt.Rows.Count > 0)
            {
                cb = DataRowToModel(dt.Rows[0]);
            }
            else
            {
                cb = null;
            }
            return cb;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(CookBook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CookBook(");
            strSql.Append("CTitle,CIntroduce,CContent,stepcount,isdel,addtime,UId,path)");
            strSql.Append(" values (");
            strSql.Append("@CTitle,@CIntroduce,@CContent,@stepcount,@isdel,@addtime,@UId,@path)");
            SqlParameter[] parameters = {
					new SqlParameter("@CTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CIntroduce", SqlDbType.NVarChar,150),
					new SqlParameter("@CContent", SqlDbType.NVarChar,150),
					new SqlParameter("@stepcount", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@path",SqlDbType.NVarChar)
                                        };      
            parameters[0].Value = model.CTitle;
            parameters[1].Value = model.CIntroduce;
            parameters[2].Value = model.CContent;
            parameters[3].Value = model.stepcount;
            parameters[4].Value = model.isdel;
            parameters[5].Value = model.addtime;
            parameters[6].Value = model.UId;
            parameters[7].Value = model.path;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(CookBook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CookBook set ");
            strSql.Append("CTitle=@CTitle,");
            strSql.Append("CIntroduce=@CIntroduce,");
            strSql.Append("CContent=@CContent,");
            strSql.Append("stepcount=@stepcount,");
            strSql.Append("isdel=@isdel,");
            strSql.Append("path=@path,");
            strSql.Append("addtime=@addtime,");
            strSql.Append("UId=@UId");
            strSql.Append(" where isdel = 0");
            SqlParameter[] parameters = {
					
					new SqlParameter("@CTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@CIntroduce", SqlDbType.NVarChar,150),
					new SqlParameter("@CContent", SqlDbType.NVarChar,150),
					new SqlParameter("@stepcount", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@path", SqlDbType.NVarChar)};
            parameters[0].Value = model.CTitle;
            parameters[1].Value = model.CIntroduce;
            parameters[2].Value = model.CContent;
            parameters[3].Value = model.stepcount;
            parameters[4].Value = model.isdel;
            parameters[5].Value = model.addtime;
            parameters[6].Value = model.UId;
            parameters[7].Value = model.path;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int uid, int cid)
        {
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update FollowTable set ");
                strSql.Append("isdel=1 ");
                strSql.Append(" where ");
                strSql.Append("UId=@UId,");
                strSql.Append("CId=@CId,");
                SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@CId", SqlDbType.Int,4),

                                        };
                parameters[0].Value = uid;
                parameters[1].Value = cid;
                int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
                if (rows > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
            /// <summary>
            /// 得到一个对象实体
            /// </summary>
            public CookBook DataRowToModel(DataRow row)
            {
                CookBook model=new CookBook();
                if (row != null)
                {
                    if(row["CId"]!=null && row["CId"].ToString()!="")
                    {
                        model.CId=int.Parse(row["CId"].ToString());
                    }
                    if(row["CTitle"]!=null)
                    {
                        model.CTitle=row["CTitle"].ToString();
                    }
                    if(row["CIntroduce"]!=null)
                    {
                        model.CIntroduce=row["CIntroduce"].ToString();
                    }
                    if(row["CContent"]!=null)
                    {
                        model.CContent=row["CContent"].ToString();
                    }
                    if(row["stepcount"]!=null && row["stepcount"].ToString()!="")
                    {
                        model.stepcount=int.Parse(row["stepcount"].ToString());
                    }
                    if(row["isdel"]!=null && row["isdel"].ToString()!="")
                    {
                        if((row["isdel"].ToString()=="1")||(row["isdel"].ToString().ToLower()=="true"))
                        {
                            model.isdel=true;
                        }
                        else
                        {
                            model.isdel=false;
                        }
                    }
                    if(row["addtime"]!=null && row["addtime"].ToString()!="")
                    {
                        model.addtime=DateTime.Parse(row["addtime"].ToString());
                    }
                    if(row["UId"]!=null && row["UId"].ToString()!="")
                    {
                        model.UId=int.Parse(row["UId"].ToString());
                    }
                    if(row["path"].ToString()!="" && row["path"] != null)
                    {
                        model.path = row["path"].ToString();
                    }
                    else
                    {
                        model.path = string.Empty;
                    }
                }
                return model;
            }



        /// <summary>
        /// 获取所有人的全部菜谱
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetCookBook()
        {
            string sql = "select * from CookBook where isdel = 0 order by addtime DESC";
            List<CookBook> list = new List<CookBook>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CookBook cb = new CookBook();
                    LoadCookBook(dr, cb);
                    list.Add(cb);
                }

            }
            else
            {
                list = null;
            }
            return list;
        }

        /// <summary>
        /// 获取所有人的全部模糊查询菜谱（无分页）
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetCookBook(string msg)
        {
            string sql = "select * from CookBook where isdel = 0 and CTitle like '%" + msg + "%' or CIntroduce like '%" + msg + "%' or CContent like '%" + msg + "%' order by addtime DESC ";
       
            List<CookBook> list = new List<CookBook>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CookBook cb = new CookBook();
                    LoadCookBook(dr, cb);
                    list.Add(cb);
                }

            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 获取个人的全部菜谱
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetCookBook(int start, int end, int uid)
            {
                string sql = "select * from(select * , row_number() over( order by addtime DESC) as num  from CookBook where UId = @uid )as t  where t.isdel = 0 and t.num >= @start and t.num <= @end  ";
                SqlParameter[] ps = {
                                    new SqlParameter("@start",SqlDbType.Int),
                                    new SqlParameter("@end",SqlDbType.Int),
                                    new SqlParameter("@uid",SqlDbType.Int)
                                    
                                    };
                ps[0].Value = start;
                ps[1].Value = end;
                ps[2].Value = uid;

                List<CookBook> list = new List<CookBook>();
                DataTable dt = new DataTable();
                dt = DbHelperSQL.GetDataTable(sql, ps);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        CookBook cb = new CookBook();
                        LoadCookBook(dr, cb);
                        list.Add(cb);
                    }

                }
                else
                {
                    list = null;
                }
                return list;
            }
        /// <summary>
        /// 获取所有人的全部菜谱
        /// </summary>
        /// <returns></returns>
        public List<CookBook> GetCookBook(int start, int end)
        {
            string sql = "select * from(select * , row_number() over( order by addtime DESC) as num  from CookBook )as t  where t.isdel = 0 and t.num >= @start and t.num <= @end";
            SqlParameter[] ps = {
                                    new SqlParameter("@start",SqlDbType.Int),
                                    new SqlParameter("@end",SqlDbType.Int),

                                    };
            ps[0].Value = start;
            ps[1].Value = end;


            List<CookBook> list = new List<CookBook>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CookBook cb = new CookBook();
                    LoadCookBook(dr, cb);
                    list.Add(cb);
                }

            }
            else
            {
                list = null;
            }
            return list;
        }  /// <summary>
           /// 获取所有人的全部模糊查询菜谱(有分页）
           /// </summary>
           /// <returns></returns>
        public List<CookBook> GetCookBook(int start, int end,string msg)
        {
            string sql = "select * from(select * , row_number() over( order by addtime DESC) as num  from CookBook where CTitle like '%@msg%' or CIntroduce like '%@msg%' or CContent like '%@msg%' )as t  where t.isdel = 0 and t.num >= @start and t.num <= @end";
            SqlParameter[] ps = {
                                    new SqlParameter("@start",SqlDbType.Int),
                                    new SqlParameter("@end",SqlDbType.Int),
                                    new SqlParameter("@msg",SqlDbType.NVarChar)
                                    };
            ps[0].Value = start;
            ps[1].Value = end;
            ps[2].Value = msg;

            List<CookBook> list = new List<CookBook>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CookBook cb = new CookBook();
                    LoadCookBook(dr, cb);
                    list.Add(cb);
                }

            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 加载菜谱对象
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="cb"></param>
        private void LoadCookBook(DataRow dr,CookBook cb)
            {

                cb.CId = Convert.ToInt32(dr["CId"]);
                cb.CTitle = dr["CTitle"] == DBNull.Value ? string.Empty : dr["CTitle"].ToString();
                cb.CIntroduce = dr["CIntroduce"] == DBNull.Value ? string.Empty : dr["CIntroduce"].ToString();
                cb.CContent = dr["CContent"] == DBNull.Value ? string.Empty : dr["CContent"].ToString();
                cb.addtime = Convert.ToDateTime(dr["addtime"] );
                cb.UId = Convert.ToInt32(dr["UId"]);
                cb.isdel = Convert.ToBoolean(dr["isdel"]);
                cb.stepcount = Convert.ToInt32(dr["stepcount"]);
                cb.path = dr["path"] == DBNull.Value ? string.Empty : dr["path"].ToString();
            

            }
            /// <summary>
            /// 获取个人数据条数
            /// </summary>
            /// <param name="uid"></param>
            /// <returns></returns>
            public int GetMaxCount(int uid)
            {
                string sql = "select count(CId) from CookBook where isdel = 0 and UId = @uid ";
                SqlParameter p = new SqlParameter("@uid", SqlDbType.Int);
                p.Value = uid;
                return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql, p));
            }
            /// <summary>
            /// 获取全部数据条数
            /// </summary>
            /// <param name="uid"></param>
            /// <returns></returns>
            public int GetMaxCount()
            {
                string sql = "select count(CId) from CookBook where isdel = 0 ";
                return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
            }


    }
}


        