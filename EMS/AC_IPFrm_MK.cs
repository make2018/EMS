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
    }
}
