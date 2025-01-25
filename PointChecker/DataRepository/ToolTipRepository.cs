using System.Linq;
using System.Collections.Generic;

using PointChecker.CustomControl;
using PointChecker.DataRepository.ToolTips;

namespace PointChecker.DataRepository
{
    class ToolTipRepository
    {
        private static readonly ToolTipRepository instance = new ToolTipRepository();
        private List<ToolTipList> checkBoxFormList = new List<ToolTipList>();

        private ToolTipRepository() { }

        public static ToolTipRepository Context
        {
            get => instance;
        }

        public void Add(CheckBoxForm checkBoxForm)
        {
            if (!IsCheckBoxFormAdded(checkBoxForm))
            {
                checkBoxFormList.Add(new ToolTipList() { CheckBoxForm = checkBoxForm });
            }
        }

        private bool IsCheckBoxFormAdded(CheckBoxForm checkBoxForm)
        {
            return checkBoxFormList.Contains(new ToolTipList(checkBoxForm));
        }

        public void Add(CheckBoxForm checkBoxForm, CustomToolTipForm customToolTipForm)
        {
            Add(checkBoxForm);

            foreach (ToolTipList item in checkBoxFormList)
            {
                if (item.CheckBoxForm.Equals(checkBoxForm))
                {
                    if (item.IsCustomToolTipFormAdded(customToolTipForm))
                    {
                        return;
                    }
                    else
                    {
                        item.Add(customToolTipForm);
                    }
                }
            }
        }

        public List<CustomToolTipForm> GetAllToolTipForms(CheckBoxForm checkBoxForm)
        {
            foreach (ToolTipList item in checkBoxFormList)
            {
                if (item.CheckBoxForm.Equals(checkBoxForm))
                {
                    return item.GetCustomToolTips();
                }
            }

            return null;
        }

        public void Remove(CheckBoxForm checkBoxForm)
        {
            foreach (ToolTipList item in checkBoxFormList)
            {
                if (item.CheckBoxForm.Equals(checkBoxForm))
                {
                    checkBoxFormList.Remove(item);
                }
            }
        }
    }
}
