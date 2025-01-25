using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointChecker.CustomControl
{
    public delegate void ToolTipClose();
    public delegate void ToolTipHoldingStatusForCheckBox();

    public partial class CustomToolTipForm : Form
    {
        Point mouseLocation;       
        ToolTipClose toolTipClose;
        ToolTipHoldingStatusForCheckBox toolTipHolding;

        public CustomToolTipForm(string val, ToolTipClose tTClose, Point startPoint, CustomCheckBox parentCheckBox)
        {
            InitializeComponent();
            Location = startPoint;
            txtBox.Rtf = val;
            toolTipClose = tTClose;
            IsClosableForm = true;
            toolTipHolding += parentCheckBox.SetToolTipAsHolded;
        }

        public void autoHideButton_Click(object sender, EventArgs e)
        {
            btnAutoHide.Visible = false;
            btnClose.Visible = true;
            IsClosableForm = false;
            toolTipHolding();
        }

        private void pnlHead_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void pnlHead_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void frmToolTip_Deactivate(object sender, EventArgs e)
        {
            if (IsClosableForm) CloseToolTip();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseToolTip();
        }
         
        public void CloseToolTip()
        {
            toolTipClose();
            this.Close();
        }

        public void CloseFormOnStatus()
        {
            if (!this.Focused && IsClosableForm)
            {
                CloseToolTip();
            }
        }

        public bool IsClosableForm { get; set; }
    }
}
