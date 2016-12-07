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
	/// 数据访问类:UserInfo
	/// </summary>
	public partial class UserInfoDAL
	{
		public UserInfoDAL()
		{}
		

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
            string sql = "select max(UId) From UserInfo where isdel = 0 ";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
		}

	

		/// <summary>
		/// 增加一条数据------------
		/// </summary>
		public int Add(UserInfo model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("name,account,pwd,email,address,introduce,display,sex,birthday,addtime,isdel,question,answer)");
            strSql.Append(" values (");
            strSql.Append("@name,@account,@pwd,@email,@address,@introduce,@display,@sex,@birthday,@addtime,@isdel,@question,@answer)");
            //strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar),
					new SqlParameter("@account", SqlDbType.NVarChar),
					new SqlParameter("@pwd", SqlDbType.NVarChar),
					new SqlParameter("@email", SqlDbType.NVarChar),
					new SqlParameter("@address", SqlDbType.NVarChar),
					new SqlParameter("@introduce", SqlDbType.NVarChar),
					new SqlParameter("@display", SqlDbType.NVarChar),
					new SqlParameter("@sex", SqlDbType.Bit),
					new SqlParameter("@birthday", SqlDbType.NChar),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit),
					new SqlParameter("@question", SqlDbType.NVarChar),
					new SqlParameter("@answer", SqlDbType.NVarChar)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.account;
            parameters[2].Value = model.pwd;
            parameters[3].Value = model.email;
            parameters[4].Value = model.address;
            parameters[5].Value = model.introduce;
            parameters[6].Value = model.display;
            parameters[7].Value = model.sex;
            parameters[8].Value = model.birthday;
            parameters[9].Value = model.addtime;
            parameters[10].Value = model.isdel;
            parameters[11].Value = model.question;
            parameters[12].Value = model.answer;
			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserInfo model)
		{

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into UserInfo(");
            strSql.Append("name,account,pwd,email,address,introduce,display,sex,birthday,addtime,isdel,question,answer)");
            strSql.Append(" values (");
            strSql.Append("@name,@account,@pwd,@email,@address,@introduce,@display,@sex,@birthday,@addtime,@isdel,@question,@answer)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@account", SqlDbType.NVarChar,50),
					new SqlParameter("@pwd", SqlDbType.NVarChar,50),
					new SqlParameter("@email", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,50),
					new SqlParameter("@introduce", SqlDbType.NVarChar,150),
					new SqlParameter("@display", SqlDbType.NVarChar,100),
					new SqlParameter("@sex", SqlDbType.Bit,1),
					new SqlParameter("@birthday", SqlDbType.NChar,20),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@question", SqlDbType.NVarChar,50),
					new SqlParameter("@answer", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.account;
            parameters[2].Value = model.pwd;
            parameters[3].Value = model.email;
            parameters[4].Value = model.address;
            parameters[5].Value = model.introduce;
            parameters[6].Value = model.display;
            parameters[7].Value = model.sex;
            parameters[8].Value = model.birthday;
            parameters[9].Value = model.addtime;
            parameters[10].Value = model.isdel;
            parameters[11].Value = model.question;
            parameters[12].Value = model.answer;

		return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters) > 0;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UId=@UId");
			SqlParameter[] parameters = {
					new SqlParameter("@UId", SqlDbType.Int,4)
			};
			parameters[0].Value = UId;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) > 0;
		
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string UIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserInfo ");
			strSql.Append(" where UId in ("+UIdlist + ")  ");
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

        public UserInfo GetInfo(string account)
        {
            string sql = "select * from UserInfo where account = @account and isdel = 0";
            SqlParameter p = new SqlParameter("@account" , SqlDbType.NVarChar );
            p.Value = account;
            DataTable dt = DbHelperSQL.GetDataTable(sql, p);
            UserInfo info = new UserInfo();
            if(dt.Rows.Count >　0)
            {

                LoadInfo(info, dt.Rows[0]);
            }
            else
            {
                info = null;
            }

            return info;
        }


        /// <summary>
        /// 获取模糊查询用户数据列表（无分页
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserInfoList(string msg)
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "select * from UserInfo where isdel = 0 and ( name like '%"+msg+ "%' or introduce like '%" + msg + "%')";
          
            DataTable dt = DbHelperSQL.GetDataTable(sql);
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserInfo info = new UserInfo();
                    LoadInfo(info, dr);
                    list.Add(info);
                }
                
            }
            else
            {
               list = null;
            }

            return list;

        }

        /// <summary>
        /// 获取模糊查询用户数据列表（有分页
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public List<UserInfo> GetUserInfoList(int start , int end ,string msg)
        {
            List<UserInfo> list = new List<UserInfo>();
            string sql = "select * from (select * , row_number()over(order by UId) as num from UserInfo where isdel = 0 and ( name like '%@msg%' or introduce like '%@msg%') )as t where t.num >= @start and t.num <=@end";
            SqlParameter[] ps = {
                new SqlParameter("@msg", SqlDbType.NVarChar),
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int)
            };
            ps[0].Value = msg;
            ps[1].Value = start;
            ps[2].Value = end;
            DataTable dt = DbHelperSQL.GetDataTable(sql, ps);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserInfo info = new UserInfo();
                    LoadInfo(info, dr);
                    list.Add(info);
                }

            }
            else
            {
                list = null;
            }

            return list;

        }
        /// <summary>
        /// 根据id获取用户数据
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(int uid)
        {
            string sql = "select * from UserInfo where UId = @uid and isdel = 0";
            SqlParameter p = new SqlParameter("@uid", SqlDbType.NVarChar);
            p.Value = uid;
            DataTable dt = DbHelperSQL.GetDataTable(sql, p);
            UserInfo info = new UserInfo();
            if (dt.Rows.Count > 0)
            {

                LoadInfo(info, dt.Rows[0]);
            }
            else
            {
                info = null;
            }

            return info;

        }

        private UserInfo LoadInfo(UserInfo uinfo,DataRow dr)
        {
            uinfo.account =dr["account"] != DBNull.Value ? dr["account"].ToString() :string.Empty;
            uinfo.address = dr["address"] != DBNull.Value ?dr["address"] .ToString() : string.Empty;
            uinfo.addtime = Convert.ToDateTime(dr["addtime"]);
            uinfo.birthday = dr["birthday"] != DBNull.Value ?dr["birthday"].ToString() : string.Empty;
            uinfo.display = dr["display"] != DBNull.Value ? dr["display"].ToString() : string.Empty;
            uinfo.email = dr["email"] != DBNull.Value ? dr["email"].ToString() : string.Empty;
            uinfo.UId = Convert.ToInt32(dr["UId"]);
            uinfo.sex = Convert.ToBoolean(dr["sex"]);
            uinfo.pwd =  dr["pwd"] != DBNull.Value ?  dr["pwd"].ToString() : string.Empty;
            uinfo.name = dr["name"] != DBNull.Value ? dr["name"].ToString() : string.Empty;
            uinfo.introduce = dr["introduce"] != DBNull.Value ? dr["introduce"].ToString() : string.Empty;
            uinfo.question = dr["question"] != DBNull.Value ? dr["question"].ToString() : string.Empty;
            uinfo.answer = dr["answer"] != DBNull.Value ? dr["answer"].ToString() : string.Empty;
            uinfo.isdel = false;
            return uinfo;
        }
	}
}

