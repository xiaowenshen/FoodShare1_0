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
	/// 数据访问类:MyStrategy
	/// </summary>
	public partial class MyStrategyDAL
	{
		public MyStrategyDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            string sql = "select max(SId) from MyStrategy ";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql)); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		//public bool Exists(int SId)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("select count(1) from MyStrategy");
		//	strSql.Append(" where SId=@SId ");
		//	SqlParameter[] parameters = {
		//			new SqlParameter("@SId", SqlDbType.Int,4)			};
		//	parameters[0].Value = SId;

		//	return DbHelperSQL.Exists(strSql.ToString(),parameters);
		//}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(MyStrategy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into MyStrategy(");
			strSql.Append("addtime,isdel,STitle,SContent,UId,Path)");
			strSql.Append(" values (");
			strSql.Append("@addtime,@isdel,@STitle,@SContent,@UId,@Path)");
			SqlParameter[] parameters = {
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@STitle", SqlDbType.NVarChar,50),
					new SqlParameter("@SContent", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,150)};
			parameters[0].Value = model.addtime;
			parameters[1].Value = model.isdel;
			parameters[2].Value = model.STitle;
			parameters[3].Value = model.SContent;
			parameters[4].Value = model.UId;
			parameters[5].Value = model.Path;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(MyStrategy model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update MyStrategy set ");
			strSql.Append("addtime=@addtime,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("STitle=@STitle,");
			strSql.Append("SContent=@SContent,");
			strSql.Append("UId=@UId,");
			strSql.Append("Path=@Path");
			strSql.Append(" where SId=@SId ");
			SqlParameter[] parameters = {
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@STitle", SqlDbType.NVarChar,50),
					new SqlParameter("@SContent", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@Path", SqlDbType.NVarChar,150),
					new SqlParameter("@SId", SqlDbType.Int,4)};
			parameters[0].Value = model.addtime;
			parameters[1].Value = model.isdel;
			parameters[2].Value = model.STitle;
			parameters[3].Value = model.SContent;
			parameters[4].Value = model.UId;
			parameters[5].Value = model.Path;
			parameters[6].Value = model.SId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int SId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("UPDATE  MyStrategy SET ISDEL = 1  ");
			strSql.Append(" where SId=@SId ");
			SqlParameter[] parameters = {
					new SqlParameter("@SId", SqlDbType.Int,4)			};
			parameters[0].Value = SId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 通过id获取对象
        /// </summary>
        /// <param name="SId"></param>
        /// <returns></returns>
        public MyStrategy GetMyStrategyById(int SId)
        {
            MyStrategy ms = new MyStrategy();
            //-------------
            string sql = "select * from (select t2.name as Uname, t1.* from MyStrategy as t1 inner join UserInfo as t2 on(t1.UId = t2.UId and t1.isdel = 0 and t2.isdel = 0) ) as t where t.SId = @sid";
            SqlParameter p = new SqlParameter("@sid", SqlDbType.Int);
            p.Value = SId;
            DataTable dt = DbHelperSQL.GetDataTable(sql, p);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    LoadMyStrategy(ms, dr);
                    
                }
            }
            else
            {
                ms = null;
            }
            return ms;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MyStrategy DataRowToModel(DataRow row)
		{
			MyStrategy model=new MyStrategy();
			if (row != null)
			{
				if(row["SId"]!=null && row["SId"].ToString()!="")
				{
					model.SId=int.Parse(row["SId"].ToString());
				}
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
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
				if(row["STitle"]!=null)
				{
					model.STitle=row["STitle"].ToString();
				}
				if(row["SContent"]!=null)
				{
					model.SContent=row["SContent"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=int.Parse(row["UId"].ToString());
				}
				if(row["Path"]!=null)
				{
					model.Path=row["Path"].ToString();
				}
			}
			return model;
		}


        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount()
        {
            string sql = "select count(SId) from MyStrategy where isdel = 0 ";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql.ToString()));
        }

        /// <summary>
		/// 获取指定用户记录总数
		/// </summary>
		public int GetRecordCount(int uid)
        {
            string sql = "select count(SId) from MyStrategy where isdel = 0 and UId = @uid";
            SqlParameter p = new SqlParameter("@uid", SqlDbType.Int);
            p.Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql.ToString(),p));
        }

        /// <summary>
        /// 获取分页数据（指定UID）
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="start">开始序列</param>
        /// <param name="end">结束序列</param>
        /// <returns></returns>
        public List<MyStrategy> GetList(int uid,int start,int end)
        {
            string sql = "select * from "
               + "(select ROW_NUMBER()over(order by t1.addtime DESC) AS num , t2.name as Uname, t1.* from MyStrategy as t1 inner join UserInfo as t2 on (t1.UId=t2.UId and t1.isdel=0 and t2.isdel = 0) where  t1.UId = @uid ) as t "
               + "where t.num >=@start and t.num <=@end  ";
            SqlParameter[] ps = {
                    new SqlParameter("@uid",SqlDbType.Int),
                    new SqlParameter("@start",SqlDbType.Int),
                    new SqlParameter("@end",SqlDbType.Int),
            };
            ps[0].Value = uid;
            ps[1].Value = start;
            ps[2].Value = end;
            List<MyStrategy> list = new List<MyStrategy>();
            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if(dt.Rows.Count>0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyStrategy ms = new MyStrategy();
                    LoadMyStrategy(ms, dr);
                    list.Add(ms);
                }
            }
            else
            {
                list = null;

            }
            return list;

        }
        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="start">开始序列</param>
        /// <param name="end">结束序列</param>
        /// <returns></returns>
        public List<MyStrategy> GetList(int start, int end)
        {
            string sql = "select * from "
               + "(select ROW_NUMBER()over(order by t1.addtime DESC) AS num , t2.name as Uname, t1.* from MyStrategy as t1 inner join UserInfo as t2 on (t1.UId=t2.UId and t1.isdel=0 and t2.isdel = 0) ) as t "
               + "where  t.num >=@start and t.num <=@end  ";
            SqlParameter[] ps = {
                    new SqlParameter("@start",SqlDbType.Int),
                    new SqlParameter("@end",SqlDbType.Int),

            };
            ps[0].Value = start;
            ps[1].Value = end;
            List<MyStrategy> list = new List<MyStrategy>();
            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyStrategy ms = new MyStrategy();
                    LoadMyStrategy(ms, dr);
                    list.Add(ms);
                }
            }
            else
            {
                list = null;

            }
            return list;

        }
        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <returns></returns>
        public List<MyStrategy> GetList()
        {
            string sql = "select t1.name as Uname, t2.* from UserInfo as t1 inner join MyStrategy as t2 on (t1.UId=t2.UId) where t1.isdel=0 and t2.isdel=0  ";
            
            List<MyStrategy> list = new List<MyStrategy>();
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    MyStrategy ms = new MyStrategy();
                    LoadMyStrategy(ms, dr);
                    list.Add(ms);
                }
            }
            else
            {
                list = null;

            }
            return list;

        }

        /// <summary>
        /// 把dr数据加载到ms对象中
        /// </summary>
        /// <param name="ms">MyStrategy对象</param>
        /// <param name="dr">datarow对象</param>
        private void LoadMyStrategy(MyStrategy ms, DataRow dr)
        {
            ms.addtime = DateTime.Now;
            ms.isdel = false;
            ms.UId =Convert.ToInt32( dr["UId"]);
            ms.Uname = dr["Uname"] == DBNull.Value ? string.Empty : dr["Uname"].ToString();
            ms.STitle = dr["STitle"]==DBNull.Value ?string.Empty: dr["STitle"].ToString();
            ms.Path =dr["Path"] == DBNull.Value ? string.Empty : dr["Path"].ToString();
            ms.SContent = dr["SContent"] == DBNull.Value ? string.Empty : dr["SContent"].ToString();
            ms.SId = Convert.ToInt32(dr["SId"]);
        }
        
        #endregion  BasicMethod
    
    }
}

