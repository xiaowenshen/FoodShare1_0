using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace FoodShareDAL
{
    public class DbHelperSQL
    {
        //获取连接字符串
        private static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //获得数据表,此方法可以执行sql语句，也可以执行存储过程
        public static DataTable GetDataTable(string sql,params SqlParameter[] ps)
        {
            using(SqlConnection conn=new SqlConnection(constr))
            {
                //声明数据表
                DataTable dt = new DataTable();
                using (SqlDataAdapter adt = new SqlDataAdapter(sql, conn))
                {
                    if(ps!=null)
                    {
                      //添加参数
                        adt.SelectCommand.Parameters.AddRange(ps);
                    }
                    //确定类型，如果是普通的sql语句，就用commandType.Text,如果是存储过程，就应该是commandType.storeprocedure,此处默认sql语句
                    adt.SelectCommand.CommandType = CommandType.Text;
                    adt.Fill(dt);
                    return dt;

                }
            }

        }

        //执行增删查改 获取受影响行数
        public static int ExecuteSql(string sql, params SqlParameter[] ps)
        {
            using(SqlConnection conn=new SqlConnection(constr))
            {
                using(SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if(ps!=null)
                    {
                        //如果有参数，就添加参数
                        cmd.Parameters.AddRange(ps);

                    }
                    //指定命令的类型
                    cmd.CommandType = CommandType.Text;
                    //打开数据库连接
                    conn.Open();
                    return cmd.ExecuteNonQuery();
                }

            }

        }

        //返回首行首列
        public static object ExecuteScalar(string sql ,params SqlParameter[] ps)
        {
            using(SqlConnection conn=new SqlConnection(constr))
            {
                using(SqlCommand cmd=new SqlCommand(sql,conn))
                {
                    if(ps!=null)
                    {
                        cmd.Parameters.AddRange(ps);
                    }
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    return cmd.ExecuteScalar();

                }


            }

        }

         
    }
}
