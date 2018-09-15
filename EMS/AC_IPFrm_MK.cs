using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EMS
{
    public partial class AC_IPFrm_MK : Form
    {
        public AC_IPFrm_MK()
        {
            InitializeComponent();
        }

     

        Basic_DataBase_Operate operate = new Basic_DataBase_Operate();

        private void AC_IPFrm_MK_Load(object sender, EventArgs e)
        {
            
     
   
         
            string str_sqlstr= "select * from Table_IP";

            string str_sqlTable = "Table_IP";


            DataSet myds = operate.getds(str_sqlstr, str_sqlTable);
   
            dgvInfo.DataSource = myds.Tables[str_sqlTable];

          //dgvInfo.DataSource = operate.getds(str_sqlstr, str_sqlTable).Tables[str_sqlTable];

        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   //@DName varchar(20),
        	////@IP varchar(20),
	        ////@mask varchar(20),
	        ////@place varchar(50),
	        ////@Anno varchar(200)
         //   SqlCommand sqlcmd = new SqlCommand();
         //   sqlcmd.Connection = sqlcon;
         //   sqlcmd.CommandType = CommandType.StoredProcedure;
         //   sqlcmd.CommandText = "proc_AddData";
         //   sqlcmd.Parameters.Add("@DName", SqlDbType.VarChar, 20).Value = textBox1.Text;
         //   sqlcmd.Parameters.Add("@IP", SqlDbType.VarChar, 20).Value = textBox2.Text;
         //   sqlcmd.Parameters.Add("@mask", SqlDbType.VarChar, 20).Value = textBox3.Text;
         //   sqlcmd.Parameters.Add("@place", SqlDbType.VarChar, 50).Value = textBox4.Text;
         //   sqlcmd.Parameters.Add("@Anno", SqlDbType.VarChar, 200).Value = textBox5.Text;
         //   if (sqlcon.State==ConnectionState.Closed)
         //   { sqlcon.Open();}
         //   if (Convert.ToInt32(sqlcmd.ExecuteNonQuery ())>0)
         //   {
         //       label6.Text = "添加成功";
         //   }
         //   else
         //   {
         //       label6.Text = "添加失败";
         //   }

         //   sqlcon = new SqlConnection(strCon);
         //   sqlda = new SqlDataAdapter("select * from Table_IP", sqlcon);
         //   myds = new DataSet();
         // //  DataSet myds = new DataSet();
         //   sqlda.Fill(myds);
         //   //sqlda.Fill(myds, "IPTable");
         //   dgvInfo.DataSource = myds.Tables[0];
         //   sqlcon.Close();
        }
    }
}
