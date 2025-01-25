
namespace PointChecker.CustomControl
{
    partial class CustomCheckBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            checkBoxText = new System.Windows.Forms.RichTextBox();
            btnCheckBox = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // checkBoxText
            // 
            checkBoxText.BackColor = System.Drawing.SystemColors.ControlLight;
            checkBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            checkBoxText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            checkBoxText.ForeColor = System.Drawing.SystemColors.WindowText;
            checkBoxText.Location = new System.Drawing.Point(40, 4);
            checkBoxText.Margin = new System.Windows.Forms.Padding(4);
            checkBoxText.Name = "checkBoxText";
            checkBoxText.ReadOnly = true;
            checkBoxText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            checkBoxText.Size = new System.Drawing.Size(282, 27);
            checkBoxText.TabIndex = 1;
            checkBoxText.Text = "";
            checkBoxText.MouseHover += checkBoxText_MouseHover;
            // 
            // btnCheckBox
            // 
            btnCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCheckBox.Image = Properties.Resources.UncheckedPic;
            btnCheckBox.Location = new System.Drawing.Point(0, 0);
            btnCheckBox.Margin = new System.Windows.Forms.Padding(4);
            btnCheckBox.Name = "btnCheckBox";
            btnCheckBox.Size = new System.Drawing.Size(35, 35);
            btnCheckBox.TabIndex = 1;
            btnCheckBox.UseVisualStyleBackColor = true;
            btnCheckBox.Click += btnCheckBox_Click;
            // 
            // CustomCheckBox
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Window;
            Controls.Add(btnCheckBox);
            Controls.Add(checkBoxText);
            Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "CustomCheckBox";
            Size = new System.Drawing.Size(326, 35);
            MouseLeave += CustomCheckBox_MouseLeave;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.RichTextBox checkBoxText;
        private System.Windows.Forms.Button btnCheckBox;
    }
}
