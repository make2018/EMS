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
        string strCon = "Server=10.228.141.253;User Id=sa;Pwd=p@ssw0rd;DataBase=CCR";//定义数据库连接字符串
        SqlConnection sqlcon;//声明数据库连接对象
        SqlDataAdapter sqlda;//声明数据库桥接器对象
        DataSet myds;//声明数据集对象
        private void AC_IPFrm_MK_Load(object sender, EventArgs e)
        {
            dgvInfo.AllowUserToAddRows = false;
            dgvInfo.AllowUserToDeleteRows = false;
            sqlcon = new SqlConnection(strCon);
            sqlda = new SqlDataAdapter("select * from Table_IP", sqlcon);
            //myds = new DataSet();
            DataSet myds = new DataSet();
            //sqlda.Fill(myds);
            sqlda.Fill(myds, "IPTable");
            dgvInfo.DataSource = myds.Tables["IPTable"];

            //禁用DataGridView控件的排序功能
            for (int i = 0; i < dgvInfo.Columns.Count; i++)
                dgvInfo.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //设置SelectionMode属性为FullRowSelect使控件能够整行选择
            dgvInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //设置DataGridView控件中的数据以各行换色的形式显示
            foreach (DataGridViewRow dgvRow in dgvInfo.Rows)//遍历所有行
            {
                if (dgvRow.Index % 2 == 0)//判断是否是偶数行
                {
                    //设置偶数行颜色
                    dgvInfo.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                else//奇数行
                {
                    //设置奇数行颜色
                    dgvInfo.Rows[dgvRow.Index].DefaultCellStyle.BackColor = Color.LightPink;
                }
            }
            dgvInfo.ReadOnly = true;//设置dgvInfo控件的ReadOnly属性，使其为只读
            //设置dgvInfo控件的DefaultCellStyle.SelectionBackColor属性，使选中行颜色变色
            dgvInfo.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;


        }

        private void dgvInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //@DName varchar(20),
        	//@IP varchar(20),
	        //@mask varchar(20),
	        //@place varchar(50),
	        //@Anno varchar(200)
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlcon;
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = "proc_AddData";
            sqlcmd.Parameters.Add("@DName", SqlDbType.VarChar, 20).Value = textBox1.Text;
            sqlcmd.Parameters.Add("@IP", SqlDbType.VarChar, 20).Value = textBox2.Text;
            sqlcmd.Parameters.Add("@mask", SqlDbType.VarChar, 20).Value = textBox3.Text;
            sqlcmd.Parameters.Add("@place", SqlDbType.VarChar, 50).Value = textBox4.Text;
            sqlcmd.Parameters.Add("@Anno", SqlDbType.VarChar, 200).Value = textBox5.Text;
            if (sqlcon.State==ConnectionState.Closed)
            { sqlcon.Open();}
            if (Convert.ToInt32(sqlcmd.ExecuteNonQuery ())>0)
            {
                label6.Text = "添加成功";
            }
            else
            {
                label6.Text = "添加失败";
            }

            sqlcon = new SqlConnection(strCon);
            sqlda = new SqlDataAdapter("select * from Table_IP", sqlcon);
            myds = new DataSet();
          //  DataSet myds = new DataSet();
            sqlda.Fill(myds);
            //sqlda.Fill(myds, "IPTable");
            dgvInfo.DataSource = myds.Tables[0];
            sqlcon.Close();
        }
    }
}
