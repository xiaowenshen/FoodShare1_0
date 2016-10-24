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
	/// 数据访问类:FollowTable
	/// </summary>
	public partial class FollowTableDAL
	{
		public FollowTableDAL()
		{}
		



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FollowTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FollowTable(");
			strSql.Append("UId,CUId,isdel,addtime)");
			strSql.Append(" values (");
			strSql.Append("@UId,@CUId,@isdel,@addtime)");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@CUId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.UId;
			parameters[1].Value = model.CUId;
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
		/// 更新一条数据
		/// </summary>
		public bool Update(FollowTable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FollowTable set ");
			strSql.Append("UId=@UId,");
			strSql.Append("CUId=@CUId,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
					new SqlParameter("@CUId", SqlDbType.Int,4),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.UId;
			parameters[1].Value = model.CUId;
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
		public bool Delete(int uid,int cuid)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FollowTable set ");
            strSql.Append("isdel=1 ");
            strSql.Append(" where ");
            strSql.Append("UId=@UId,");
            strSql.Append("CUId=@CUId,");
            SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4),
                    new SqlParameter("@CUId", SqlDbType.Int,4),

                                        };
            parameters[0].Value = uid;
            parameters[1].Value = cuid;


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
}

