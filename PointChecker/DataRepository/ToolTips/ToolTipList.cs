using System.Collections.Generic;
using PointChecker.CustomControl;

namespace PointChecker.DataRepository.ToolTips
{
    class ToolTipList
    {
        private List<CustomToolTipForm> checkBoxeList = new List<CustomToolTipForm>();

        public ToolTipList() { }
        public ToolTipList(CheckBoxForm checkBoxForm)
        {
            CheckBoxForm = checkBoxForm;
        }

        public CheckBoxForm CheckBoxForm { get; set; }

        public void Add(CustomToolTipForm customToolTip)
        {
            checkBoxeList.Add(customToolTip);
        }

        public List<CustomToolTipForm> GetCustomToolTips()
        {
            return checkBoxeList;
        }

        public bool IsCustomToolTipFormAdded(CustomToolTipForm customToolTipForm)
        {
            foreach (CustomToolTipForm item in checkBoxeList)
            {
                if (item.Equals(customToolTipForm)) return true;
            }

            return false;
        }
    }
}
