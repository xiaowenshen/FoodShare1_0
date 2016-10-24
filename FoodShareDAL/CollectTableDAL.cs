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
	/// 数据访问类:CollectTableDAL
	/// </summary>
	public partial class CollectTableDAL
	{
		public CollectTableDAL()
		{}
	
		/// <summary>
		/// 增加一条数据
		/// </summary>
        public bool Add(CollectTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CollectTable(");
			strSql.Append("UId,CId,isdel,addtime)");
			strSql.Append(" values (");
			strSql.Append("@UId,@CId,@isdel,@addtime)");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.UId;
			parameters[1].Value = model.CId;
			parameters[2].Value = model.isdel;
			parameters[3].Value = model.addtime;

			int rows= DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        public bool Update(CollectTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CollectTable set ");
			strSql.Append("UId=@UId,");
			strSql.Append("CId=@CId,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.UId;
			parameters[1].Value = model.CId;
			parameters[2].Value = model.isdel;
			parameters[3].Value = model.addtime;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CollectTable ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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


		
	}
}

