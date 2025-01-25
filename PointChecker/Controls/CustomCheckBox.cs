using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PointChecker.DataRepository;
using static PointChecker.CustomControl.CustomCheckBox;

namespace PointChecker.CustomControl
{
    public partial class CustomCheckBox : UserControl
    {
        public delegate void FormOnStatusClosing();
        public delegate void ToolTipClosing();
        public FormClosedEventHandler frmToolTip_FormClosed;

        readonly int defaultHeightForEditMode = 560;
        bool IsToolTipIsClosed = true;       
        bool IsToolTipHolded = false;
        Point formPosition;
        CustomToolTipForm customToolTip;
        FormOnStatusClosing formOnStatusClosing;
        ToolTipClosing toolTipClosing;

        public CustomCheckBox(Point formPos)
        {
            formPosition = formPos;
            InitializeComponent();
            IsSelected = false;
            btnCheckBox.FlatAppearance.BorderSize = 0;
            customToolTip = new CustomToolTipForm(ToolTipValue, SetToolTipAsClosed, GetStartToolTipPoint(), this);
            customToolTip.FormClosed += frmToolTip_FormClosed;
        }

        public CustomToolTipForm GetCustomToolTipForm()
        { 
            return customToolTip;
        }

        private bool IsSelected { get; set; }

        private void btnCheckBox_Click(object sender, EventArgs e)
        {
            if (IsSelected)
            {
                this.btnCheckBox.Image = Properties.Resources.UncheckedPic;
                IsSelected = false;
            }
            else
            {
                this.btnCheckBox.Image = Properties.Resources.CheckedPic;
                IsSelected = true;
            }                
        }

        private void checkBoxText_MouseHover(object sender, EventArgs e)
        {
            if (IsToolTipIsClosed && !IsToolTipHolded)
            {
                CustomToolTipForm customToolTip = new CustomToolTipForm(ToolTipValue, SetToolTipAsClosed, GetStartToolTipPoint(), this);
                customToolTip.FormClosed += frmToolTip_FormClosed;
                formOnStatusClosing += customToolTip.CloseFormOnStatus;
                toolTipClosing += customToolTip.CloseToolTip;

                ToolTipRepository.Context.Add(this.Parent as CheckBoxForm, customToolTip);
                customToolTip.Show();
                IsToolTipIsClosed = false;
            }
        }

        private void SetToolTipAsClosed()
        {
            IsToolTipIsClosed= true;
        }

        public void SetToolTipAsHolded()
        {
            IsToolTipHolded = true;
        }

        public string Value 
        {
            set => checkBoxText.Text = value;
            private get => checkBoxText.Text;            
        }

        public string ToolTipValue { private get; set; }

        public Point GetStartToolTipPoint()
        {
            var x = formPosition.X + this.Location.X + this.Size.Width - 1;
            var y = formPosition.Y + this.Location.Y + 1;

            return new Point(x, y);
        }

        public void CloseRelatedToolTip()
        {
            if (formOnStatusClosing is not null)
            {
                IsToolTipHolded = false;
                toolTipClosing();
            }                
        }

        private void CustomCheckBox_MouseLeave(object sender, EventArgs e)
        {
            if (formOnStatusClosing is not null) 
                formOnStatusClosing();
        }
    }
}
