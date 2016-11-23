using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FoodShareDAL;
using FoodShareMODEL;
using System.Data.SqlClient;
using FoodShare.Model;

namespace FoodShareDAL
{
    //comment
    public partial class CommentDAL
    {


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into comment(");
            strSql.Append("UId1,U1path,U1name,UId2,U2name,U2path,addtime,isdel,comment");
            strSql.Append(") values (");
            strSql.Append("@UId1,@U1path,@U1name,@UId2,@U2name,@U2path,@addtime,@isdel,@comment");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                        new SqlParameter("@UId1", SqlDbType.Int,4) ,
                        new SqlParameter("@U1path", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@U1name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UId2", SqlDbType.Int,4) ,
                        new SqlParameter("@U2name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@U2path", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,
                        new SqlParameter("@isdel", SqlDbType.Bit,1) ,
                        new SqlParameter("@comment", SqlDbType.NVarChar,400)

            };

            parameters[0].Value = model.UId1;
            parameters[1].Value = model.U1path;
            parameters[2].Value = model.U1name;
            parameters[3].Value = model.UId2;
            parameters[4].Value = model.U2name;
            parameters[5].Value = model.U2path;
            parameters[6].Value = model.addtime;
            parameters[7].Value = model.isdel;
            parameters[8].Value = model.comment;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Comment model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update comment set ");

            strSql.Append(" UId1 = @UId1 , ");
            strSql.Append(" U1path = @U1path , ");
            strSql.Append(" U1name = @U1name , ");
            strSql.Append(" UId2 = @UId2 , ");
            strSql.Append(" U2name = @U2name , ");
            strSql.Append(" U2path = @U2path , ");
            strSql.Append(" addtime = @addtime , ");
            strSql.Append(" isdel = @isdel , ");
            strSql.Append(" comment = @comment  ");
            strSql.Append(" where mid=@mid ");

            SqlParameter[] parameters = {
                        new SqlParameter("@mid", SqlDbType.Int,4) ,
                        new SqlParameter("@UId1", SqlDbType.Int,4) ,
                        new SqlParameter("@U1path", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@U1name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@UId2", SqlDbType.Int,4) ,
                        new SqlParameter("@U2name", SqlDbType.NVarChar,50) ,
                        new SqlParameter("@U2path", SqlDbType.NVarChar,250) ,
                        new SqlParameter("@addtime", SqlDbType.DateTime) ,
                        new SqlParameter("@isdel", SqlDbType.Bit,1) ,
                        new SqlParameter("@comment", SqlDbType.NVarChar,400)

            };

            parameters[0].Value = model.mid;
            parameters[1].Value = model.UId1;
            parameters[2].Value = model.U1path;
            parameters[3].Value = model.U1name;
            parameters[4].Value = model.UId2;
            parameters[5].Value = model.U2name;
            parameters[6].Value = model.U2path;
            parameters[7].Value = model.addtime;
            parameters[8].Value = model.isdel;
            parameters[9].Value = model.comment;
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
        public bool Delete(int mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  comment set isdel = 1");
            strSql.Append(" where mid=@mid");
            SqlParameter[] parameters = {
                    new SqlParameter("@mid", SqlDbType.Int,4)
            };
            parameters[0].Value = mid;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string midlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from comment ");
            strSql.Append(" where ID in (" + midlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Comment GetModel(int mid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select mid, UId1, U1path, U1name, UId2, U2name, U2path, addtime, isdel, comment  ");
            strSql.Append("  from comment ");
            strSql.Append(" where mid=@mid");
            strSql.Append(" and isdel = 0");
            SqlParameter[] parameters = {
                    new SqlParameter("@mid", SqlDbType.Int,4)
            };
            parameters[0].Value = mid;


            Comment model = new Comment();
            DataTable dt = DbHelperSQL.GetDataTable(strSql.ToString(), parameters);
            LoadComment(dt,model);
            return model;

        }

        private Comment LoadComment(DataTable dt,Comment model)
        {

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["mid"].ToString() != "")
                {
                    model.mid = int.Parse(dt.Rows[0]["mid"].ToString());
                }
                if (dt.Rows[0]["UId1"].ToString() != "")
                {
                    model.UId1 = int.Parse(dt.Rows[0]["UId1"].ToString());
                }
                model.U1path = dt.Rows[0]["U1path"].ToString();
                model.U1name = dt.Rows[0]["U1name"].ToString();
                if (dt.Rows[0]["UId2"].ToString() != "")
                {
                    model.UId2 = int.Parse(dt.Rows[0]["UId2"].ToString());
                }
                model.U2name = dt.Rows[0]["U2name"].ToString();
                model.U2path = dt.Rows[0]["U2path"].ToString();
                if (dt.Rows[0]["addtime"].ToString() != "")
                {
                    model.addtime = DateTime.Parse(dt.Rows[0]["addtime"].ToString());
                }
                if (dt.Rows[0]["isdel"].ToString() != "")
                {
                    if ((dt.Rows[0]["isdel"].ToString() == "1") || (dt.Rows[0]["isdel"].ToString().ToLower() == "true"))
                    {
                        model.isdel = true;
                    }
                    else
                    {
                        model.isdel = false;
                    }
                }
                model.comment = dt.Rows[0]["comment"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
       /// <summary>
       /// 加载datarow对象中的数据到comment对象中
       /// </summary>
       /// <param name="dr"></param>
       /// <param name="model"></param>
       /// <returns></returns>
        private Comment LoadComment(DataRow dr ,Comment model)
        {
            if (dr["mid"].ToString() != "")
            {
                model.mid = int.Parse(dr["mid"].ToString());
            }
            if (dr["UId1"].ToString() != "")
            {
                model.UId1 = int.Parse(dr["UId1"].ToString());
            }
            model.U1path = dr["U1path"].ToString();
            model.U1name = dr["U1name"].ToString();
            if (dr["UId2"].ToString() != "")
            {
                model.UId2 = int.Parse(dr["UId2"].ToString());
            }
            model.U2name = dr["U2name"].ToString();
            model.U2path = dr["U2path"].ToString();
            if (dr["addtime"].ToString() != "")
            {
                model.addtime = DateTime.Parse(dr["addtime"].ToString());
            }
            if (dr["isdel"].ToString() != "")
            {
                if ((dr["isdel"].ToString() == "1") || (dr["isdel"].ToString().ToLower() == "true"))
                {
                    model.isdel = true;
                }
                else
                {
                    model.isdel = false;
                }
            }
            model.comment = dr["comment"].ToString();

            return model;

        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Comment> GetList(int uid ,int start ,int end)
        {
            List<Comment> list = new List<Comment>();
            string sql = "select * from (select * ,row_number() over(order by addtime desc) as num from Comment where isdel = 0 and UId2 = @uid) as t where t.num >=@start  and t.num <= @end";
            SqlParameter[] ps = {
                new SqlParameter("@uid",SqlDbType.Int),
                new SqlParameter("@start",SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int),
            };
            ps[0].Value = uid;
            ps[1].Value = start;
            ps[2].Value = end;
            DataTable dt = new DataTable();
            dt = DbHelperSQL.GetDataTable(sql, ps);
            if(dt.Rows.Count > 0)
            {
                foreach (DataRow  dr in dt.Rows)
                {
                    Comment model = new Comment();
                    LoadComment(dr, model);
                    if(model != null)
                    {
                        list.Add(model);
                    }
                    
                }
            }
            else
            {
                list = null;
            }
            return list;
        }
        /// <summary>
        /// 关注指定用户的记录数目
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int GetRecordCount(int uid)
        {
            string sql = "select count(1) from comment where UId2 = @uid and isdel = 0";
            SqlParameter p = new SqlParameter("@uid", SqlDbType.Int);
            p.Value = uid;
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql,p));
        }
    }
}

