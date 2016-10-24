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
	/// 数据访问类:PhotoCollection
	/// </summary>
	public partial class PhotoCollectionDAL
	{
		public PhotoCollectionDAL()
		{}
		/// <summary>
		/// 增加一条数据-----
		/// </summary>
		public int Add(PhotoCollection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into PhotoCollection(");
			strSql.Append("path,isdel,addtime,PTitle)");
			strSql.Append(" values (");
			strSql.Append("@path,@isdel,@addtime,@PTitle)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@path", SqlDbType.NVarChar,50),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@PTitle", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.path;
			parameters[1].Value = model.isdel;
			parameters[2].Value = model.addtime;
			parameters[3].Value = model.PTitle;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(PhotoCollection model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update PhotoCollection set ");
			strSql.Append("path=@path,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("addtime=@addtime,");
			strSql.Append("PTitle=@PTitle");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@path", SqlDbType.NVarChar,50),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@PTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@PId", SqlDbType.Int,4)};
			parameters[0].Value = model.path;
			parameters[1].Value = model.isdel;
			parameters[2].Value = model.addtime;
			parameters[3].Value = model.PTitle;
			parameters[4].Value = model.PId;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) >　0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PhotoCollection ");
			strSql.Append(" where PId=@PId");
			SqlParameter[] parameters = {
					new SqlParameter("@PId", SqlDbType.Int,4)
			};
			parameters[0].Value = PId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters) > 0;
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string PIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from PhotoCollection ");
			strSql.Append(" where PId in ("+PIdlist + ")  ");
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


	}
}

