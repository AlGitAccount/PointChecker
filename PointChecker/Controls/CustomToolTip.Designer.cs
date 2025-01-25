
namespace PointChecker.CustomControl
{
    partial class CustomToolTipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomToolTipForm));
            txtBox = new System.Windows.Forms.RichTextBox();
            btnAutoHide = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            pnlHead = new System.Windows.Forms.Panel();
            SuspendLayout();
            // 
            // txtBox
            // 
            txtBox.BackColor = System.Drawing.SystemColors.Info;
            txtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            txtBox.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            txtBox.Location = new System.Drawing.Point(9, 19);
            txtBox.Name = "txtBox";
            txtBox.ReadOnly = true;
            txtBox.Size = new System.Drawing.Size(510, 579);
            txtBox.TabIndex = 0;
            txtBox.Text = "";
            // 
            // btnAutoHide
            // 
            btnAutoHide.Image = Properties.Resources.AutoHideButton2;
            btnAutoHide.Location = new System.Drawing.Point(501, 0);
            btnAutoHide.Name = "btnAutoHide";
            btnAutoHide.Size = new System.Drawing.Size(18, 18);
            btnAutoHide.TabIndex = 1;
            btnAutoHide.UseVisualStyleBackColor = true;
            btnAutoHide.Click += autoHideButton_Click;
            // 
            // btnClose
            // 
            btnClose.Image = Properties.Resources.CloseButton2;
            btnClose.Location = new System.Drawing.Point(501, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(18, 18);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Visible = false;
            btnClose.Click += btnClose_Click;
            // 
            // pnlHead
            // 
            pnlHead.Location = new System.Drawing.Point(0, 0);
            pnlHead.Name = "pnlHead";
            pnlHead.Size = new System.Drawing.Size(495, 18);
            pnlHead.TabIndex = 3;
            pnlHead.MouseDown += pnlHead_MouseDown;
            pnlHead.MouseMove += pnlHead_MouseMove;
            // 
            // CustomToolTipForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Info;
            ClientSize = new System.Drawing.Size(520, 643);
            Controls.Add(pnlHead);
            Controls.Add(btnClose);
            Controls.Add(btnAutoHide);
            Controls.Add(txtBox);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "CustomToolTipForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "CustomToolTip";
            Deactivate += frmToolTip_Deactivate;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox txtBox;
        private System.Windows.Forms.Button btnAutoHide;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlHead;
    }
}