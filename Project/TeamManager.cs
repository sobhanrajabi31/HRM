using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Project
{
    public partial class TeamManager : DevExpress.XtraEditors.XtraForm
    {
        public TeamManager()
        {
            InitializeComponent();
        }

        private void TeamManager_Load(object sender, EventArgs e)
        {
            TeamManagerPage.SelectedTabPage = tabcontrol_profile;
        }
    }
}