using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PointChecker.DataStructure;
using PointChecker.CustomControl;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace PointChecker
{
    public delegate void CustomToolTipFormClosing();
    public delegate void RelatedCustomToolTipFormClosing();

    public partial class CheckBoxForm : Form
    {
        CustomToolTipFormClosing customToolTipFormClosing;
        RelatedCustomToolTipFormClosing relatedToolTipClosing;

        public CheckBoxForm(SectionContentTranslation section)
        {
            InitializeComponent();
            AddCheckBoxesOnForm(section);
        }

        private void AddCheckBoxesOnForm(SectionContentTranslation section)
        { 
            int checkBoxCount = section.CheckPoints.Count;

            for (int i = 0; i < checkBoxCount; i++) 
            {
                string name = "checkBox" + i.ToString();
                this.Controls.Add(AddCheckBoxesToForm(section.CheckPoints[i], i));
            }
        }

        private CustomCheckBox AddCheckBoxesToForm(CheckPointItem item, int iterator)
        {
            int y = iterator * 36;

            CustomCheckBox checkBox = new CustomCheckBox(this.Location);
            checkBox.BackColor = SystemColors.ControlLight;
            checkBox.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox.Location = new Point(0, y);
            checkBox.Margin = new Padding(4);
            checkBox.Name = "checkBox" + iterator.ToString();
            checkBox.Size = new Size(325, 35);
            checkBox.TabIndex = iterator;
            checkBox.Value = item.CheckPointTitle;
            checkBox.ToolTipValue = item.ToolTipValue;

            customToolTipFormClosing += checkBox.GetCustomToolTipForm().CloseToolTip;
            relatedToolTipClosing += checkBox.CloseRelatedToolTip;

            return checkBox;
        }

        private void CheckBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            relatedToolTipClosing();
        }
    }
}
