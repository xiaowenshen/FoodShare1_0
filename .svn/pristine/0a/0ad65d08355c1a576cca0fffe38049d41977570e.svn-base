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
    /// 数据访问类:FoodMenu
    /// </summary>
    public partial class FoodMenuDAL
    {
        public FoodMenuDAL()
        { }
       

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            string sql = "select max(FId) from FoodMenu where isdel = 0";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //public bool Exists(int FId)
        //{
        //    StringBuilder strSql=new StringBuilder();
        //    strSql.Append("select count(1) from FoodMenu");
        //    strSql.Append(" where FId=@FId");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@FId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = FId;

        //    return DbHelperSQL.Exists(strSql.ToString(),parameters);
        //}


        /// <summary>
        /// 增加一条数据------------------------------
        /// </summary>
        public int Add(FoodMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FoodMenu(");
            strSql.Append("FName,CId,CName)");
            strSql.Append(" values (");
            strSql.Append("@FName,@CId,@CName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.FName;
            parameters[1].Value = model.CId;
            parameters[2].Value = model.CName;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FoodMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FoodMenu set ");
            strSql.Append("FName=@FName,");
            strSql.Append("CId=@CId,");
            strSql.Append("CName=@CName");
            strSql.Append(" where FId=@FId");
            SqlParameter[] parameters = {
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.NVarChar,50),
					new SqlParameter("@FId", SqlDbType.Int,4)};
            parameters[0].Value = model.FName;
            parameters[1].Value = model.CId;
            parameters[2].Value = model.CName;
            parameters[3].Value = model.FId;

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
        public bool Delete(int FId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FoodMenu ");
            strSql.Append(" where FId=@FId");
            SqlParameter[] parameters = {
					new SqlParameter("@FId", SqlDbType.Int,4)
			};
            parameters[0].Value = FId;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
        }
    }



    /// <summary>

}