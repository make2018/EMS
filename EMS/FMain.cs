using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EMS
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }


        //定义子窗口对象
        private ChildFrm myChildFrm = null;
        private void 主数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //myChildFrm = new ChildFrm();//创建子窗口对象
            //myChildFrm.Show();//显示子窗口
            //myChildFrm.Focus();//使子窗口获得焦点




            if (myChildFrm == null || myChildFrm.IsDisposed)
            {
                myChildFrm = new ChildFrm();
            }
            myChildFrm.MdiParent = this; //建立父子关系
            myChildFrm.Show(); //显示子窗口
            myChildFrm.Focus();  //子窗口获得焦点



        }
        private AC_IPFrm_MK Frm = null;
        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm==null || Frm.IsDisposed)
            {
                Frm = new AC_IPFrm_MK();
            }
            Frm.MdiParent = this;
            Frm.Show();
            Frm.Focus();
        }

        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm == null || Frm.IsDisposed)
            {
                Frm = new AC_IPFrm_MK();
            }
            Frm.MdiParent = this;
            Frm.Show();
            Frm.Focus();
        }
    }
}
