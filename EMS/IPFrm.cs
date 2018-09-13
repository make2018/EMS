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
    public partial class IPFrm : Form
    {
        public IPFrm()
        {
            InitializeComponent();
        }
        string strID = "";
        private void IPFrm_Load(object sender, EventArgs e)
        {
            using (CCREntities db = new CCREntities())
            {
                dgvInfo.DataSource = db.Table_IP.ToList();
            }


        }
    }
}
