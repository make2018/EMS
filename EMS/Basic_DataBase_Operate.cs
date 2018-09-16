using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Oracle.DataAccess.Client;
namespace EMS
{
    class Basic_DataBase_Operate
    {
        //连接数据库
        public SqlConnection getcon()
        {
            // string M_str_sqlcon = "Server=10.228.141.253;User Id=sa;Pwd=p@ssw0rd;DataBase=CCR";//定义数据库连接字符串
            string M_str_sqlcon = ConfigurationManager.ConnectionStrings["SqlConnection String"].ConnectionString;
            SqlConnection myCon = new SqlConnection(M_str_sqlcon);
            return myCon;
        }


        //连接SqlConnection,执行SQL
        public void getcom(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcom.ExecuteNonQuery();
            sqlcom.Dispose();
            sqlcon.Close();
            sqlcon.Dispose();
        }


        //创建DataSet对象
        public DataSet getds(string M_str_sqlstr, string M_str_table)
        {
            SqlConnection sqlcon = this.getcon();
            SqlDataAdapter sqlda = new SqlDataAdapter(M_str_sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlda.Fill(myds, M_str_table);
            return myds;
        }


        //创建SqlDataReader对象
        public SqlDataReader getread(string M_str_sqlstr)
        {
            SqlConnection sqlcon = this.getcon();
            SqlCommand sqlcom = new SqlCommand(M_str_sqlstr, sqlcon);
            sqlcon.Open();
            SqlDataReader sqlread = sqlcom.ExecuteReader(CommandBehavior.CloseConnection);
            return sqlread;
        }


       //连接Oracle数据库的方法by ethan  20180916
    
        //连接数据库
        public OracleConnection OrcGetCon()
        {
            // string M_str_sqlcon = "Data Source=10.228.141.253/ORCL;User Id=WEBKF;Password=WEBKF";//定义数据库连接字符串
            string M_str_sqlcon = ConfigurationManager.ConnectionStrings["OracleDbContext"].ConnectionString;
           OracleConnection myCon = new OracleConnection(M_str_sqlcon);
            return myCon;
        }


        //连接OracleConnection,执行SQL
        public void OrcGetCom(string M_str_sqlstr)
        {
            OracleConnection orccon = this.OrcGetCon();
            orccon.Open();
            OracleCommand orccom = new OracleCommand(M_str_sqlstr, orccon);
            orccom.ExecuteNonQuery();
            orccom.Dispose();
            orccon.Close();
            orccon.Dispose();
        }


        //创建DataSet对象
        public DataSet OrcGetDs(string M_str_sqlstr, string M_str_table)
        {
            OracleConnection orccon = this.OrcGetCon();
            OracleDataAdapter orcda = new OracleDataAdapter(M_str_sqlstr, orccon);
            DataSet myds = new DataSet();
            orcda.Fill(myds, M_str_table);
            return myds;
        }


        //创建OracleDataReader对象
        public OracleDataReader OrcGetRead(string M_str_sqlstr)
        {
            OracleConnection orccon = this.OrcGetCon();
            OracleCommand orccom = new OracleCommand(M_str_sqlstr, orccon);
            orccon.Open();
            OracleDataReader orcread = orccom.ExecuteReader(CommandBehavior.CloseConnection);
            return orcread;
        }
    }
}
