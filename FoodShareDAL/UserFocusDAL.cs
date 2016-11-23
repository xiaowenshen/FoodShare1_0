﻿using System;
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
	/// 数据访问类:UserFocus
	/// </summary>
	public partial class UserFocusDAL
	{
		public UserFocusDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		//public int GetMaxId()
		//{
		//return DbHelperSQL.GetMaxID("FocusId", "UserFocus"); 
		//}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		//public bool Exists(int FocusId)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("select count(1) from UserFocus");
		//	strSql.Append(" where FocusId=@FocusId");
		//	SqlParameter[] parameters = {
		//			new SqlParameter("@FocusId", SqlDbType.Int,4)
		//	};
		//	parameters[0].Value = FocusId;

		//	return DbHelperSQL.Exists(strSql.ToString(),parameters);
		//}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(UserFocus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserFocus(");
			strSql.Append("UId1,U1name,UId2,U2name,U2path,U2Introduce,isdel,addtime)");
			strSql.Append(" values (");
			strSql.Append("@UId1,@U1name,@UId2,@U2name,@U2path,@U2Introduce,@isdel,@addtime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UId1", SqlDbType.Int,4),
					new SqlParameter("@U1name", SqlDbType.NVarChar,150),
					new SqlParameter("@UId2", SqlDbType.Int,4),
					new SqlParameter("@U2name", SqlDbType.NVarChar,150),
					new SqlParameter("@U2path", SqlDbType.NVarChar,250),
					new SqlParameter("@U2Introduce", SqlDbType.NVarChar,250),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime)};
			parameters[0].Value = model.UId1;
			parameters[1].Value = model.U1name;
			parameters[2].Value = model.UId2;
			parameters[3].Value = model.U2name;
			parameters[4].Value = model.U2path;
			parameters[5].Value = model.U2Introduce;
			parameters[6].Value = model.isdel;
			parameters[7].Value = model.addtime;

			return DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(UserFocus model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserFocus set ");
			strSql.Append("UId1=@UId1,");
			strSql.Append("U1name=@U1name,");
			strSql.Append("UId2=@UId2,");
			strSql.Append("U2name=@U2name,");
			strSql.Append("U2path=@U2path,");
			strSql.Append("U2Introduce=@U2Introduce,");
			strSql.Append("isdel=@isdel,");
			strSql.Append("addtime=@addtime");
			strSql.Append(" where FocusId=@FocusId");
			SqlParameter[] parameters = {
					new SqlParameter("@UId1", SqlDbType.Int,4),
					new SqlParameter("@U1name", SqlDbType.NVarChar,150),
					new SqlParameter("@UId2", SqlDbType.Int,4),
					new SqlParameter("@U2name", SqlDbType.NVarChar,150),
					new SqlParameter("@U2path", SqlDbType.NVarChar,250),
					new SqlParameter("@U2Introduce", SqlDbType.NVarChar,250),
					new SqlParameter("@isdel", SqlDbType.Bit,1),
					new SqlParameter("@addtime", SqlDbType.DateTime),
					new SqlParameter("@FocusId", SqlDbType.Int,4)};
			parameters[0].Value = model.UId1;
			parameters[1].Value = model.U1name;
			parameters[2].Value = model.UId2;
			parameters[3].Value = model.U2name;
			parameters[4].Value = model.U2path;
			parameters[5].Value = model.U2Introduce;
			parameters[6].Value = model.isdel;
			parameters[7].Value = model.addtime;
			parameters[8].Value = model.FocusId;

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
		public bool Delete(int FocusId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserFocus set isdel = 1");
			strSql.Append(" where FocusId=@FocusId");
			SqlParameter[] parameters = {
					new SqlParameter("@FocusId", SqlDbType.Int,4)
			};
			parameters[0].Value = FocusId;

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
		public bool DeleteList(string FocusIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserFocus ");
			strSql.Append(" where FocusId in ("+FocusIdlist + ")  ");
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
		public UserFocus GetModel(int FocusId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 FocusId,UId1,U1name,UId2,U2name,U2path,U2Introduce,isdel,addtime from UserFocus ");
			strSql.Append(" where FocusId=@FocusId");
			SqlParameter[] parameters = {
					new SqlParameter("@FocusId", SqlDbType.Int,4)
			};
			parameters[0].Value = FocusId;

			UserFocus model=new UserFocus();
			DataTable  dt =DbHelperSQL.GetDataTable(strSql.ToString(),parameters);
			if(dt.Rows.Count>0)
			{
				return DataRowToModel(dt.Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public UserFocus DataRowToModel(DataRow row)
		{
			 UserFocus model=new  UserFocus();
			if (row != null)
			{
				if(row["FocusId"]!=null && row["FocusId"].ToString()!="")
				{
					model.FocusId=int.Parse(row["FocusId"].ToString());
				}
				if(row["UId1"]!=null && row["UId1"].ToString()!="")
				{
					model.UId1=int.Parse(row["UId1"].ToString());
				}
				if(row["U1name"]!=null)
				{
					model.U1name=row["U1name"].ToString();
				}
				if(row["UId2"]!=null && row["UId2"].ToString()!="")
				{
					model.UId2=int.Parse(row["UId2"].ToString());
				}
				if(row["U2name"]!=null)
				{
					model.U2name=row["U2name"].ToString();
				}
				if(row["U2path"]!=null)
				{
					model.U2path=row["U2path"].ToString();
				}
				if(row["U2Introduce"]!=null)
				{
					model.U2Introduce=row["U2Introduce"].ToString();
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
				if(row["addtime"]!=null && row["addtime"].ToString()!="")
				{
					model.addtime=DateTime.Parse(row["addtime"].ToString());
				}
			}
			return model;
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<UserFocus> GetList(int start,int end, int uid)
		{
            List<UserFocus> list = new List<UserFocus>();
            string sql = "select * from (select *,row_number() over(order by FocusId desc) as num from (select * from UserFocus where UId1 = @uid and isdel = 0) as m ) as t where t.num >= @start and t.num <= @end ";
            SqlParameter[] ps = {
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),
            };
            ps[0].Value = start;
            ps[1].Value = end;
            ps[2].Value = uid;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if(dt.Rows.Count >0)
            {
                foreach (DataRow dr in dt.Rows)
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

		///// <summary>
		///// 获得前几行数据
		///// </summary>
		//public DataSet GetList(int Top,string strWhere)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("select ");
		//	if(Top>0)
		//	{
		//		strSql.Append(" top "+Top.ToString());
		//	}
		//	strSql.Append(" FocusId,UId1,U1name,UId2,U2name,U2path,U2Introduce,isdel,addtime ");
		//	strSql.Append(" FROM UserFocus ");
		//	if(strWhere.Trim()!="")
		//	{
		//		strSql.Append(" where "+strWhere);
		//	}
		//	strSql.Append(" order by addtime");
		//	return DbHelperSQL.Query(strSql.ToString());
		//}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(int uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM UserFocus where isdel = 0 and UId1 = @uid");
            SqlParameter p = new SqlParameter("@uid", SqlDbType.Int);
            p.Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(strSql.ToString(),p));
			
		}
		///// <summary>
		///// 分页获取数据列表
		///// </summary>
		//public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		//{
		//	StringBuilder strSql=new StringBuilder();
		//	strSql.Append("SELECT * FROM ( ");
		//	strSql.Append(" SELECT ROW_NUMBER() OVER (");
		//	if (!string.IsNullOrEmpty(orderby.Trim()))
		//	{
		//		strSql.Append("order by T." + orderby );
		//	}
		//	else
		//	{
		//		strSql.Append("order by T.FocusId desc");
		//	}
		//	strSql.Append(")AS Row, T.*  from UserFocus T ");
		//	if (!string.IsNullOrEmpty(strWhere.Trim()))
		//	{
		//		strSql.Append(" WHERE " + strWhere);
		//	}
		//	strSql.Append(" ) TT");
		//	strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
		//	return DbHelperSQL.Query(strSql.ToString());
		//}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "UserFocus";
			parameters[1].Value = "FocusId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

