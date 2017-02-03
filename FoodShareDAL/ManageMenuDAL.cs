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
    /// 数据访问类:ManageMenu
    /// </summary>
    public partial class ManageMenuDAL
	{
		public ManageMenuDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            return 1;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(ManageMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ManageMenu(");
			strSql.Append("MenuName,UId,MenuIntroduce,addtime,isdel,path)");
			strSql.Append(" values (");
			strSql.Append("@MenuName,@UId,@MenuIntroduce,@addtime,@isdel,@path)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@MenuIntroduce", SqlDbType.NVarChar,150),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@path", SqlDbType.NVarChar,150)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.MenuIntroduce;
			parameters[3].Value = model.addtime;
			parameters[4].Value = model.isdel;
			parameters[5].Value = model.path;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters) ;
	
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ManageMenu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ManageMenu set ");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("UId=@UId,");
			strSql.Append("MenuIntroduce=@MenuIntroduce,");
			strSql.Append("addtime=@addtime,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("path=@path");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuName", SqlDbType.NVarChar,150),
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@MenuIntroduce", SqlDbType.NVarChar,150),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@path", SqlDbType.NVarChar,150),
					new SqlParameter("@MenuId", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuName;
			parameters[1].Value = model.UId;
			parameters[2].Value = model.MenuIntroduce;
			parameters[3].Value = model.addtime;
			parameters[4].Value = model.isdel;
			parameters[5].Value = model.path;
			parameters[6].Value = model.MenuId;

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
		public bool Delete(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ManageMenu set ");
            strSql.Append("isdel = 0");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuId;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string MenuIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ManageMenu ");
			strSql.Append(" where MenuId in ("+MenuIdlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public ManageMenu GetModelById(int MenuId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MenuId,MenuName,UId,MenuIntroduce,addtime,isdel,path from ManageMenu ");
			strSql.Append(" where MenuId=@MenuId");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
			parameters[0].Value = MenuId;

			ManageMenu model=new ManageMenu();
            DataTable dt = DbHelperSQL.GetDataTable(strSql.ToString(), parameters);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    model = DataRowToModel(dr);
                }
            }
            else
            {
                model = null;
            }
            return model ;
            
		}
        ///得到对象实体
        //private void LoadMenu(DataRow dr, ManageMenu mm)
        //{
        //    mm.addtime = Convert.ToDateTime(dr["addtime"]);
        //    mm.isdel = Convert.ToBoolean(dr["isdel"]);
        //    mm.MenuId = Convert.ToInt32(dr["MenuId"]);
        //    mm.UId = Convert.ToInt32(dr["UId"]);
        //    mm.path = dr["path"] != DBNull.Value ? dr["path"].ToString() : string.Empty;
        //    mm.MenuName = dr["MenuName"] != DBNull.Value ? dr["MenuName"].ToString() : string.Empty;
        //    mm.MenuIntroduce = dr["MenuIntroduce"] != DBNull.Value ? dr["MenuIntroduce"].ToString() : string.Empty;

        //}
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ManageMenu DataRowToModel(DataRow row)
		{
			ManageMenu model=new ManageMenu();
			if (row != null)
			{
				if(row["MenuId"]!=null && row["MenuId"].ToString()!="")
				{
					model.MenuId=int.Parse(row["MenuId"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["UId"]!=null && row["UId"].ToString()!="")
				{
					model.UId=int.Parse(row["UId"].ToString());
				}
				if(row["MenuIntroduce"]!=null)
				{
					model.MenuIntroduce=row["MenuIntroduce"].ToString();
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
				if(row["path"]!=null)
				{
					model.path=row["path"].ToString();
				}
			}
			return model;
		}

        public List<ManageMenu> GetList(int uid)
        {
            string sql = "select * from ManageMenu where UId = @uid and isdel = 0 order by addtime desc";
            List<ManageMenu> list = new List<ManageMenu>();
            SqlParameter[] ps = {
                new SqlParameter("@uid",SqlDbType.Int),

            };
          
            ps[0].Value = uid;

            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ManageMenu mm = new ManageMenu();
                    mm = DataRowToModel(dr);
                    list.Add(mm);
                }
            }
            else
            {

                list = null;

            }
            return list;
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<ManageMenu> GetList(int start, int end, int uid)
        {
            string sql = "select * from (select * ,row_number() over(order by addtime desc ) as num from ManageMenu where UId = @uid ) as t where t.num >= @start and t.num <= @end  ";
            List<ManageMenu> list = new List<ManageMenu>();
            SqlParameter[] ps = {
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),

            };
            ps[0].Value = start;
            ps[1].Value = end;
            ps[2].Value = uid;

            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ManageMenu mm = new ManageMenu();
                    mm = DataRowToModel(dr);
                    list.Add(mm);
                }
            }
            else
            {

                list = null;

            }
            return list;
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ManageMenu> GetList(int start, int end)
        {
            string sql = "select * from (select * ,row_number() over(order by addtime desc ) as num from ManageMenu ) as t where t.num >= @start and t.num <= @end  ";
            List<ManageMenu> list = new List<ManageMenu>();
            SqlParameter[] ps = {
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int),

            };
            ps[0].Value = start;
            ps[1].Value = end;

            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ManageMenu mm = new ManageMenu();
                    mm = DataRowToModel(dr);
                    list.Add(mm);
                }
            }
            else
            {

                list = null;

            }
            return list;
        }




        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(int uid)
        {
            string sql = "select count(1) from ManageMenu where isdel = 0 and UId = @uid";
            SqlParameter p = new SqlParameter("@uid", SqlDbType.Int);
            p.Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql, p));
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount()
        {
            string sql = "select count(1) from ManageMenu where isdel = 0 ";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
        }





        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

