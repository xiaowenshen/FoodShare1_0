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
		public bool Delete(int cid ,int uid)
		{
            string sql = "update CollectTable set isdel = 1 where CId= @cid and UId = @uid";
            SqlParameter[] ps = {
                new SqlParameter("@cid",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),
            };
            ps[0].Value = cid;
            ps[1].Value = uid;
            return DbHelperSQL.ExecuteSql(sql, ps) > 0;

		}

        public List<CookBook> GetCollection(int uid)
        {
            List<CookBook> list = new List<CookBook>();
            string sql = "select t2.*  from CollectTable as t1 left join CookBook as t2 on(t1.CId = t2.CId)  where t1.UId = @uid and t1.isdel = 0  order by t1.addtime desc";
            SqlParameter[] ps =
            {
                   new SqlParameter("@uid",SqlDbType.Int),
            };
            ps[0].Value = uid;
            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow dr  in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));

                }
            }
            else
            {
                list = null;

            }
            return list;
        
        }

        /// <summary>
        /// 得到COOKBOOK一个对象实体
        /// </summary>
        public CookBook DataRowToModel(DataRow row)
        {
            CookBook model = new CookBook();
            if (row != null)
            {
                if (row["CId"] != null && row["CId"].ToString() != "")
                {
                    model.CId = int.Parse(row["CId"].ToString());
                }
                if (row["CTitle"] != null)
                {
                    model.CTitle = row["CTitle"].ToString();
                }
                if (row["CIntroduce"] != null)
                {
                    model.CIntroduce = row["CIntroduce"].ToString();
                }
                if (row["CContent"] != null)
                {
                    model.CContent = row["CContent"].ToString();
                }
                if (row["stepcount"] != null && row["stepcount"].ToString() != "")
                {
                    model.stepcount = int.Parse(row["stepcount"].ToString());
                }
                if (row["isdel"] != null && row["isdel"].ToString() != "")
                {
                    if ((row["isdel"].ToString() == "1") || (row["isdel"].ToString().ToLower() == "true"))
                    {
                        model.isdel = true;
                    }
                    else
                    {
                        model.isdel = false;
                    }
                }
                if (row["addtime"] != null && row["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(row["addtime"].ToString());
                }
                if (row["UId"] != null && row["UId"].ToString() != "")
                {
                    model.UId = int.Parse(row["UId"].ToString());
                }
                if (row["path"].ToString() != "" && row["path"] != null)
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


        public bool IsExistCollectTable(int cid,int uid)
        {
            string sql = "select count(1) from CollectTable where isdel = 0 and CId= @cid and UId = @uid";
            SqlParameter[] ps = {
                new SqlParameter("@cid",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),
            };
            ps[0].Value = cid;
            ps[1].Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql, ps)) > 0;

        }

        public int GetMaxCount(int uid)
        {
            string sql = "select count(1) from CollectTable as t1 left join CookBook as t2 on(t1.CId = t2.CId)  where t1.UId = @uid and t1.isdel = 0 ";
            SqlParameter[] ps =
            {
                   new SqlParameter("@uid",SqlDbType.Int),
            };
            ps[0].Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql, ps));
        }

    }
}

