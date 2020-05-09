namespace EasyFileTransfer
{
    partial class FrmClipboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendToClient = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtClipboard = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSendToClient
            // 
            this.btnSendToClient.BackColor = System.Drawing.Color.Salmon;
            this.btnSendToClient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSendToClient.FlatAppearance.BorderSize = 0;
            this.btnSendToClient.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToClient.Location = new System.Drawing.Point(188, 122);
            this.btnSendToClient.Name = "btnSendToClient";
            this.btnSendToClient.Size = new System.Drawing.Size(162, 31);
            this.btnSendToClient.TabIndex = 1;
            this.btnSendToClient.Text = "Send To Client";
            this.btnSendToClient.UseVisualStyleBackColor = false;
            this.btnSendToClient.Click += new System.EventHandler(this.btnSendToClient_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(326, -1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtClipboard
            // 
            this.txtClipboard.BackColor = System.Drawing.Color.Salmon;
            this.txtClipboard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtClipboard.Location = new System.Drawing.Point(0, 21);
            this.txtClipboard.Name = "txtClipboard";
            this.txtClipboard.Size = new System.Drawing.Size(349, 102);
            this.txtClipboard.TabIndex = 3;
            this.txtClipboard.Text = "";
            // 
            // btnCopy
            // 
            this.btnCopy.BackColor = System.Drawing.Color.Salmon;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Location = new System.Drawing.Point(0, 122);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(182, 31);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = false;
            this.btnCopy.Visible = false;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // FrmClipboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Salmon;
            this.ClientSize = new System.Drawing.Size(349, 153);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtClipboard);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSendToClient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClipboard";
            this.Opacity = 0.75D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Clipboard";
            this.TopMost = true;
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button btnSendToClient;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox txtClipboard;
        private System.Windows.Forms.Button btnCopy;
    }
}