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
            string sql = "select max(ClassID) from FoodMenu ";
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
        public FoodMenu GetFoodMenuById(int fid)
        {

            string sql = "select t1.*,t2.CTitle,t2.CIntroduce,t2.path  from FoodMenu as t1 left join CookBook as t2 on(t2.CId = t1.CId) where FId = @fid";
            SqlParameter p = new SqlParameter("@fid", SqlDbType.Int);
            p.Value = fid;
            DataTable dt = DbHelperSQL.GetDataTable(sql, p);
            FoodMenu fm = new FoodMenu();
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow  dr in dt.Rows)
                {
                    LoadFoodMenu(fm, dr);
                }
            }
            else
            {
                fm = null;
            }
            return fm;
        }

        /// <summary>
        /// 增加一条数据------------------------------
        /// </summary>
        public int Add(FoodMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FoodMenu(");
            strSql.Append("FName,CId,CName,ClassID,UId,FIntroduce)");
            strSql.Append(" values (");
            strSql.Append("@FName,@CId,@CName,@classid,@uid,@introduce)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.NVarChar,50),
                    new SqlParameter("@classid", SqlDbType.Int,4),
                    new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@introduce", SqlDbType.NVarChar,150)
            };
            parameters[0].Value = model.FName;
            parameters[1].Value = model.CId;
            parameters[2].Value = model.CName;
            parameters[3].Value = model.ClassID;
            parameters[4].Value = model.UId;
            parameters[5].Value = model.FIntroduce;

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
            strSql.Append("UId=@uid");
            strSql.Append("FIntroduce=@introduce");
            strSql.Append(" where FId=@FId");
            SqlParameter[] parameters = {
					new SqlParameter("@FName", SqlDbType.NVarChar,50),
					new SqlParameter("@CId", SqlDbType.Int,4),
					new SqlParameter("@CName", SqlDbType.NVarChar,50),
                    new SqlParameter("@uid", SqlDbType.Int,4),
                    new SqlParameter("@introduce", SqlDbType.NVarChar,150),
                    new SqlParameter("@FId", SqlDbType.Int,4)};
            parameters[0].Value = model.FName;
            parameters[1].Value = model.CId;
            parameters[2].Value = model.CName;
            parameters[3].Value = model.UId;
            parameters[4].Value = model.FIntroduce;
            parameters[5].Value = model.FId;

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
        /// 删除整个菜单
        /// </summary>
        public bool Delete(int classid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FoodMenu set isdel = 0 ");
            strSql.Append(" where ClassID = @classid");
            SqlParameter[] parameters = {
					new SqlParameter("@classid", SqlDbType.Int,4)
			};
            parameters[0].Value = classid;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteAnItem(int fid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FoodMenu ");
            strSql.Append(" where FId = @fid");
            SqlParameter[] parameters = {
                    new SqlParameter("@fid", SqlDbType.Int,4)
            };
            parameters[0].Value = fid;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
        }

        public List<FoodMenu> GetList(int start , int end)
        {
            string sql = "select * from (select * ,row_number() over(order by FId desc) as num from FoodMenu ) as t where t.num >=@start and t.num <= @end";
            List<FoodMenu> list = new List<FoodMenu>();
            SqlParameter[] ps =
            {
                new SqlParameter("@start" ,SqlDbType.Int ),
                new SqlParameter("@end" ,SqlDbType.Int)

            };
            ps[0].Value = start;
            ps[1].Value = end;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FoodMenu fm = new FoodMenu();
                    LoadFoodMenu(fm, dr);
                    list.Add(fm);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 获取指定用户的菜单
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<FoodMenu> GetList(int start, int end ,int classid)
        {
            string sql = "select * from (select * ,row_number() over(order by FId desc) as num from FoodMenu) as t where t.num >=@start and t.num <= @end and t.ClassID =  @classid ";
            List<FoodMenu> list = new List<FoodMenu>();
            SqlParameter[] ps =
            {
                new SqlParameter("@start" ,SqlDbType.Int ),
                new SqlParameter("@end" ,SqlDbType.Int),
                new SqlParameter("@classid",SqlDbType.Int),

            };
            ps[0].Value = start;
            ps[1].Value = end;
            ps[2].Value = classid;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FoodMenu fm = new FoodMenu();
                    LoadFoodMenu(fm, dr);
                    list.Add(fm);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }


        public List<FoodMenu> GetList(int classid)
        {
            string sql = "select * from (select t1.*,t2.CTitle,t2.CIntroduce,t2.path  from FoodMenu as t1 left join CookBook as t2 on(t2.CId = t1.CId) ) as t where t.ClassID =  @classid  order by FId desc ";
            List<FoodMenu> list = new List<FoodMenu>();
            SqlParameter p = new SqlParameter("@classid", SqlDbType.Int);
            p.Value = classid;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, p);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    FoodMenu fm = new FoodMenu();
                    LoadFoodMenu(fm, dr);
                    list.Add(fm);
                }
            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 获取所有数据数目
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
    //            int RecordCount = 0;
            string sql = "selecet count(1) from FoodMenu ";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));

        }
        /// <summary>
        /// 获取指定用户的数据数目
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetRecordCount(int classid)
        {
            //            int RecordCount = 0;
            string sql = "select count(1) from FoodMenu where  ClassID = @classid ";
            SqlParameter P = new SqlParameter();
            P.Value = classid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql,P));

        }

        private  void LoadFoodMenu(FoodMenu fm, DataRow dr)
        {
            fm.CId = Convert.ToInt32(dr["CId"]);
            fm.ClassID = Convert.ToInt32(dr["ClassID"]);
            fm.CName = dr["CName"] != DBNull.Value ? dr["CName"].ToString() : string.Empty;
            fm.FId = Convert.ToInt32(dr["FId"]);
            fm.FIntroduce = dr["FIntroduce"] != DBNull.Value ? dr["FIntroduce"].ToString() : string.Empty;
            fm.FName = dr["FName"] != DBNull.Value ? dr["FName"].ToString() : string.Empty;
            fm.UId = Convert.ToInt32(dr["UId"]);
            fm.CIntroduce = dr["CIntroduce"] != DBNull.Value ? dr["CIntroduce"].ToString() : string.Empty;
            fm.CTitle = dr["CTitle"] != DBNull.Value ? dr["CTitle"].ToString() : string.Empty;
            fm.Path = dr["Path"] != DBNull.Value ? dr["Path"].ToString() : string.Empty;

        }

    }



    /// <summary>

}