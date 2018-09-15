using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Snap7;


namespace EMS
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
            Client = new S7Client();
            if (IntPtr.Size == 4)
                this.Text = this.Text + " - Running 32 bit Code";
            else
                this.Text = this.Text + " - Running 64 bit Code";
        }

        private S7Client Client;
        private byte[] Buffer = new byte[65536];

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
        private Form1 Frm = null;
        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Frm==null || Frm.IsDisposed)
            {
                Frm = new Form1();
            }
            Frm.MdiParent = this;
            Frm.Show();
            Frm.Focus();
        }
        private AC_IPFrm_MK IPFrm = null;
        private void iPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IPFrm == null || IPFrm.IsDisposed)
            {
                IPFrm = new AC_IPFrm_MK();
            }
            IPFrm.MdiParent = this;
            IPFrm.Show();
            IPFrm.Focus();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void vTIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AD_VT_IP_ethan frm1_ethan = new AD_VT_IP_ethan();
            frm1_ethan.Show();
            frm1_ethan.MdiParent = this;

        }

        private void 访问PLCBAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BA_Read_PLC_ethan frm2_ethan = new BA_Read_PLC_ethan();
            frm2_ethan.Show();
            frm2_ethan.MdiParent = this;
        }

        public static void connect_plc()
        {

        }


        private void FMain_Load(object sender, EventArgs e)
        {
          
        }
    }
}

