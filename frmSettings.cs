using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using EasyFileTransfer.Utils;

namespace EasyFileTransfer
{
    public partial class FrmSettings : Form
    {

        BindingList<Employee>   ValidUsers_bindingList;
        BindingList<FileExtensions>     ValidExtensions_bindingList;
        public FrmSettings()
        {
            InitializeComponent();
            AppConfigs conf = AppConfigs.Load();

            if (conf != null)
            {
                ValidUsers_bindingList = new BindingList<Employee>(conf.Employees);
                var sourceUsers = new BindingSource(ValidUsers_bindingList, null);
                grdValidUsers.DataSource = sourceUsers;

                ValidExtensions_bindingList = new BindingList<FileExtensions>(conf.ValidExtensions);
                var sourceExtensions = new BindingSource(ValidExtensions_bindingList, null);
                grdValidExtensions.DataSource = sourceExtensions;
            }

            ServiceState st = ServiceHelper.GetServiceStatus("EFTService");
            lblServicestatus.Text = Enum.GetName(typeof(ServiceState), st);

            btnUninstall.Visible = new[] { 1, 4, 7 }.Contains((int)st);

            lblCurrentUsername.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToLower();

            CheckUserAccess();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppConfigs conf = new AppConfigs();
            int MaxSize = 1;
            if (int.TryParse(txtMaxSize.Text, out MaxSize))
            {
                conf.MaxSize = MaxSize;
            }
            conf.Employees       = ValidUsers_bindingList.ToList<Employee>();
            conf.ValidExtensions = ValidExtensions_bindingList.ToList<FileExtensions>();

            AppConfigs.Save(conf);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnTestConnectivity_Click(object sender, EventArgs e)
        {
            try
            {
                Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSock.Connect(txtIPAddress.Text, Convert.ToInt32(txtPort.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Connected Succesfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CheckUserAccess()
        {
            if (!Helper.IsAdministrator())
            {
                ((Control)tabControl1.TabPages["tabPage2"]).Enabled = false;
                ((Control)tabControl1.TabPages["tabPage3"]).Enabled = false;
                btnUninstall.Enabled = false;
            }
            else
            {
                lblCurrentUsername.Text += " (Admin)";
            }
        }

        private void btnUninstall_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceHelper.Uninstall("EFTService");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Service uninstalled successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

