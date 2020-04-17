using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyFileTransfer.Utils;

namespace EasyFileTransfer
{
    public partial class FrmSettings : Form
    {
        List<Employee> Emp = new List<Employee>()
            {
                new Employee {Username = "Joe", },
                new Employee  {Username= "Misha" ,},
            };
        public FrmSettings()
        {
            InitializeComponent();
            
            var bindingList = new BindingList<Employee>(Emp);
            var source = new BindingSource(bindingList, null);
            grdValidUsers.DataSource = source;
            grdValidExtensions.DataSource = source;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
