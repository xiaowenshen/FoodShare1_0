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
	/// 数据访问类:MyWorks
	/// </summary>
	public partial class  MyWorksDAL
	{
        public MyWorksDAL()
		{}
        /// <summary>
        /// 判断是否为该用户的作品
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="wid"></param>
        /// <returns></returns>
        public bool IsUserWork(int uid, int wid)
        {
            string sql = "select count(1) from MyWorks where  isdel = 0 and WId = @wid and UId =@uid";
            SqlParameter[] ps = 
            {
                new SqlParameter("@uid", SqlDbType.Int),
                new SqlParameter("@wid",SqlDbType.Int),
            };
            ps[0].Value = uid;
            ps[1].Value = wid;
            int res = Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql, ps));
            return res > 0;

        }

        public MyWorks GetWorkById(int wid)
        {
            string sql = "select * from MyWorks where isdel = 0 and WId = @wid";
            SqlParameter p = new SqlParameter("@wid", SqlDbType.Int);
            p.Value = wid;
            MyWorks work = new MyWorks();
            DataTable dt =  DbHelperSQL.GetDataTable(sql, p);
            if (dt.Rows.Count > 0)
                LoadMyWorks(dt.Rows[0], work);
            else
                work = null;
            return work;
               
        }
        /// <summary>
        /// 增加一条数据-------------
        /// </summary>
        public int Add(MyWorks model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MyWorks(");
			strSql.Append("WTitle,introduce,UId,isdel,addtime,path)");
			strSql.Append(" values (");
			strSql.Append("@WTitle,@introduce,@UId,@isdel,@addtime,@path)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@introduce", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
                    new SqlParameter("@path", SqlDbType.NVarChar,150)
                                        };
			parameters[0].Value = model.WTitle;
			parameters[1].Value = model.introduce;
			parameters[2].Value = model.UId;
			parameters[3].Value = model.isdel;
			parameters[4].Value = model.addtime;
            parameters[5].Value = model.path;
            ///----
	        return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MyWorks model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MyWorks set ");
            strSql.Append("WTitle=@WTitle,");
            strSql.Append("path=@path,");
			strSql.Append("introduce=@introduce,");
			strSql.Append("UId=@UId,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where WId=@WId");
			SqlParameter[] parameters = {
					new SqlParameter("@WTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@introduce", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@WId", SqlDbType.Int,4),
                    new SqlParameter("@path", SqlDbType.NVarChar,150)
                                        };
			parameters[0].Value = model.WTitle;
			parameters[1].Value = model.introduce;
			parameters[2].Value = model.UId;
			parameters[3].Value = model.isdel;
			parameters[4].Value = model.addtime;
			parameters[5].Value = model.WId;
            parameters[6].Value = model.path;
	return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int WId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update  MyWorks set isdel = 1");
			strSql.Append(" where WId=@WId");
			SqlParameter[] parameters = {
					new SqlParameter("@WId", SqlDbType.Int,4)
			};
			parameters[0].Value = WId;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters) > 0;
	
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string WIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from MyWorks ");
			strSql.Append(" where WId in ("+WIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
        /// 获取制定用户作品的最大数值
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetMaxCount(int uid)
        {
            string sql = "select count(WId) from MyWorks where isdel = 0 and UId = @uid";
                SqlParameter p = new SqlParameter("@uid",SqlDbType.Int);
            p.Value = uid ;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql,p));

        }
        /// <summary>
        /// 获取所有作品的最大数值
        /// </summary>
        /// <returns></returns>
        public int GetMaxCount()
        {
            string sql = "select count(WId) from MyWorks where isdel = 0 ";
          

            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
        }
        /// <summary>
        /// 获取指定范围的list
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<MyWorks> GetList(int uid, int start, int end)
        {
            string sql = "select * from (select *,row_number() over(order by addtime DESC) as num from MyWorks where UId = @uid and isdel = 0) as t where  t.num >= @start and t.num <= @end";
            SqlParameter[] ps = {
                                new SqlParameter("@uid",SqlDbType.Int),
                                new SqlParameter("@start" , SqlDbType.Int),
                                new SqlParameter("@end" , SqlDbType.Int),
                                };
            ps[0].Value = uid;
            ps[1].Value = start;
            ps[2].Value = end;
            List<MyWorks> list = new List<MyWorks>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyWorks work = new MyWorks();
                    LoadMyWorks(dr, work);
                    list.Add(work);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }

        /// <summary>
        /// 获取指定范围的list
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<MyWorks> GetList( int start, int end)
        {
            string sql = "select * from (select *,row_number() over(order by addtime DESC) as num from MyWorks where isdel = 0) as t where  t.num >= @start and t.num <= @end";
            SqlParameter[] ps = {
                          
                                new SqlParameter("@start" , SqlDbType.Int),
                                new SqlParameter("@end" , SqlDbType.Int),
                                };
           
            ps[0].Value = start;
            ps[1].Value = end;
            List<MyWorks> list = new List<MyWorks>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyWorks work = new MyWorks();
                    LoadMyWorks(dr, work);
                    list.Add(work);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }


        public List<MyWorks> GetList(int start, int end, string msg)
        {
            string sql = "select * from (select *,row_number() over(order by addtime DESC) as num from MyWorks where isdel = 0 and  WTitle like '%@msg%' or introduce like '%@msg%'  ) as t where  and  t.num >= @start and t.num <= @end";
            SqlParameter[] ps = {

                                new SqlParameter("@start" , SqlDbType.Int),
                                new SqlParameter("@end" , SqlDbType.Int),
                                new SqlParameter("@msg" , SqlDbType.NVarChar)
                                };

            ps[0].Value = start;
            ps[1].Value = end;
            ps[2].Value = msg;

            List<MyWorks> list = new List<MyWorks>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyWorks work = new MyWorks();
                    LoadMyWorks(dr, work);
                    list.Add(work);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }

        public List<MyWorks> GetList(string msg)
        {
            string sql = "select * from (select *,row_number() over(order by addtime DESC) as num from MyWorks where WTitle like '%"+msg+ "%' or introduce like '%" + msg + "%' ) as t where t.isdel = 0 ";
            //SqlParameter[] ps = {

            //                  new SqlParameter("@msg" , SqlDbType.NVarChar),
            //                    new SqlParameter("@msg1" , SqlDbType.NVarChar)
            //                    };

            
            //ps[0].Value = msg;
            //ps[1].Value = msg;
            List<MyWorks> list = new List<MyWorks>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyWorks work = new MyWorks();
                    LoadMyWorks(dr, work);
                    list.Add(work);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 获取所有的作品
        /// </summary>
        /// <returns></returns>
        public List<MyWorks> GetList()
        {
            string sql = "select * from MyWorks where isdel = 0 ";
            
            List<MyWorks> list = new List<MyWorks>();
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyWorks work = new MyWorks();
                    LoadMyWorks(dr, work);
                    list.Add(work);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 加载myworks对象
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="works"></param>
        private void LoadMyWorks(DataRow dr , MyWorks works)
        {
            works.WId = dr["WId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["WId"].ToString());
            works.WTitle = dr["WTitle"] == DBNull.Value ? string.Empty : dr["WTitle"].ToString();
            works.path = dr["path"] == DBNull.Value ? string.Empty : dr["path"].ToString();
            works.isdel = false;
            works.introduce = dr["introduce"] == DBNull.Value ? string.Empty : dr["introduce"].ToString();
            works.UId = dr["UId"] == DBNull.Value ? -1 : Convert.ToInt32(dr["UId"].ToString());
            works.addtime = Convert.ToDateTime(dr["addtime"]);

        }
	}
}

