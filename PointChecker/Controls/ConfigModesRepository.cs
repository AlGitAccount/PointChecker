namespace PointChecker.CustomControl
{
    public enum Mode { Short, Normal, Edit }

    public class ConfigModesRepository
    {
        const int ALControl_Short = 0;
        const int ALControl_Normal = 560;
        const int ALControl_Edit = 633;

        const int StringField_Short = 0;
        const int StringField_Normal = 438;
        const int StringField_Edit = 438;

        const int CheckBox_Short_x1 = 1;
        const int TestField_Short_x1 = 38;
        const int CheckBox_Normal_x1 = 1;
        const int TestField_Normal_x1 = 38;
        const int CheckBox_Edit_x1 = 1;
        const int TestField_Edit_x1 = 38;

        private readonly Mode mode;

        public ConfigModesRepository(Mode m)
        {
            mode = m;
        }

        public int GetALControlWidth()
        {
            int res = 0;

            switch (mode)
            {
                case Mode.Short:
                    res = ALControl_Short;
                    break;
                case Mode.Normal:
                    res = ALControl_Normal;
                    break;
                case Mode.Edit:
                    res = ALControl_Edit;
                    break;
            }

            return res;
        }

        public int GetTextFildWidth()
        {
            int res = 0;

            switch (mode)
            {
                case Mode.Short:
                    res = StringField_Short;
                    break;
                case Mode.Normal:
                    res = StringField_Normal;
                    break;
                case Mode.Edit:
                    res = StringField_Edit;
                    break;
            }

            return res;
        }
    }
}
