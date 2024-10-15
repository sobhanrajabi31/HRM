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
    public partial class ProjectManager : DevExpress.XtraEditors.XtraForm
    {
        public ProjectManager()
        {
            InitializeComponent();
        }

        private void ProjectManager_Load(object sender, EventArgs e)
        {
            ProjectManagerPage.SelectedTabPage = tabcontrol_profile;
        }
    }
}