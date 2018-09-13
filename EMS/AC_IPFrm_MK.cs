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
    public partial class AC_IPFrm_MK : Form
    {
        public AC_IPFrm_MK()
        {
            InitializeComponent();
        }

        private void AC_IPFrm_MK_Load(object sender, EventArgs e)
        {
            using (CCREntities db = new CCREntities())
            {
                dgvInfo.DataSource=
            }
        }
    }
}
