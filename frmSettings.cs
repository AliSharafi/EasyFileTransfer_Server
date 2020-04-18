using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using EasyFileTransfer.Utils;

namespace EasyFileTransfer
{
    public partial class FrmSettings : Form
    {

        BindingList<Employee> bindingList;
        public FrmSettings()
        {
            InitializeComponent();
            AppConfigs conf = AppConfigs.Load();

            if (conf != null)
            {
                bindingList = new BindingList<Employee>(conf.Employees);
                var source = new BindingSource(bindingList, null);
                grdValidUsers.DataSource = source;
                grdValidExtensions.DataSource = source;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfigs conf = new AppConfigs();
            int MaxSize = 1;
            if (int.TryParse(txtMaxSize.Text, out MaxSize))
            {
                conf.MaxSize = MaxSize;
            }
            conf.Employees = bindingList.ToList<Employee>();

            AppConfigs.Save(conf);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
