using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasyFileTransfer.Utils;
using WK.Libraries.SharpClipboardNS;

namespace EasyFileTransfer
{
    public partial class FrmClipboard : Form
    {
        #region Singleton Form
        private static FrmClipboard inst;

        public static FrmClipboard GetForm(string Text)
        {
            if (inst == null || inst.IsDisposed)
            {
                inst = new FrmClipboard();
            }
            inst.TextToShow = Text;
            return inst;
        }
        #endregion

        public string TextToShow
        {
            get
            {
                return txtClipboard.Text;
            }
            set
            {
                txtClipboard.Invoke(new Action(() => txtClipboard.Text = value)) ;
            }
        }


        public FrmClipboard()
        {
            InitializeComponent();

            // Place th form bottom right
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height - 80);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            inst.Dispose();
            Close();
        }

        
        private void btnSendToClient_Click(object sender, EventArgs e)
        {
            try
            {
                string path = string.Concat(Directory.GetCurrentDirectory() + "\\clipboard_ServerToClient.txt");
                File.Delete(path);
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(txtClipboard.Text);
                }

                FileTransfer _ft = new FileTransfer();
                _ft.Send(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {

        }
    }
}
