using PointChecker.DataRepository;
using PointChecker.DataStructure;
using PointChecker.Registry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PointChecker
{
    internal class MainMenuManager : Form
    {
        const string settingsItemName = "SettingsToolStripMenuItem";
        const string autoStartItemName = "AutoStartToolStripMenuItem";
        const string languageListItemName = "LanguageListToolStripMenuItem";
        const string languageItemName = "LanguageToolStripMenuItem";
        const string quitItemName = "QuitToolStripMenuItem";

        MainForm mainForm;
        ContextMenuStrip menuStrip;

        public MainMenuManager(MainForm form)
        {
            mainForm = form;
            menuStrip = form.ContextMenuStrip;
        }

        internal ContextMenuStrip UpdateMenu()
        {
            List<ToolStripItem> toolStripItemList = new List<ToolStripItem>();

            foreach (string section in SectionRepository.Context().SectionList)
            {
                toolStripItemList.Add(GetToolStripItem(section));
            }

            toolStripItemList.Add(GetToolStripSeparator("separator"));
            toolStripItemList.Add(GetSettingsStripItem());
            toolStripItemList.Add(GetToolStripSeparator("separator"));
            toolStripItemList.Add(GetQuitToolStripItem());
            menuStrip.Items.AddRange(toolStripItemList.ToArray());

            return menuStrip;
        }

        private ToolStripItem GetToolStripItem(string section)
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = section;
            menuItem.Text = section;
            menuItem.Click += new EventHandler(MenuStripItem_Click);
            return menuItem;
        }

        private ToolStripMenuItem GetSettingsStripItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.DropDownItems.AddRange(new ToolStripItem[] { GetAutoRunStripItem(), GetLanguageToolStripItem() });
            menuItem.Name = settingsItemName;
            menuItem.Text = SectionRepository.Context().GeneralMenuNames.Settings;
            return menuItem;
        }

        private ToolStripItem GetAutoRunStripItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = autoStartItemName;
            menuItem.Text = SectionRepository.Context().GeneralMenuNames.AutoStart;
            menuItem.Checked = RegistryManager.IsAutoRunOn();
            menuItem.Click += new EventHandler(ChangeRunStripItemValue);
            menuItem.CheckedChanged += new EventHandler(SetAutoRunToWinRegistry);
            return menuItem;
        }

        private ToolStripItem GetLanguageToolStripItem()
        {
            ToolStripComboBox languageListmenuItem = new ToolStripComboBox();
            languageListmenuItem.Items.AddRange(SectionRepository.Context().LanguageList.ToArray());
            languageListmenuItem.Name = languageListItemName;
            languageListmenuItem.Text = SectionRepository.Context().LanguageTitle;
            languageListmenuItem.DropDownClosed += new EventHandler(SetLanguage);
            languageListmenuItem.Size = new Size(46, 22);

            ToolStripMenuItem languageMenuItem = new ToolStripMenuItem();
            languageMenuItem.DropDownItems.AddRange(new ToolStripItem[] { languageListmenuItem });
            languageMenuItem.Name = languageItemName;
            languageMenuItem.Text = SectionRepository.Context().GeneralMenuNames.Language;

            return languageMenuItem;
        }

        private ToolStripItem GetQuitToolStripItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = quitItemName;
            menuItem.Text = SectionRepository.Context().GeneralMenuNames.Quit;
            menuItem.Click += new EventHandler(mainForm.CloseMainForm);
            return menuItem;
        }

        private ToolStripSeparator GetToolStripSeparator(string name)
        {
            ToolStripSeparator separator = new ToolStripSeparator();
            separator.Name = name;
            return separator;
        }

        private void MenuStripItem_Click(object sender, EventArgs e)
        {
            string selectedValue = ((ToolStripMenuItem)sender).Text;

            if (selectedValue.Length == 0) return;

            foreach (SectionContentTranslation section in SectionRepository.Context().GetTranslatedSections)
            {
                if (section.SectionTitle == selectedValue)
                {
                    CheckBoxForm checkBoxForm = new CheckBoxForm(section);
                    checkBoxForm.ShowInTaskbar = true;
                    checkBoxForm.WindowState = FormWindowState.Normal;
                    checkBoxForm.Text = section.SectionTitle;
                    checkBoxForm.Show();
                }
            }
        }

        private void SetAutoRunToWinRegistry(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;

            if (item.Checked)
            {
                RegistryManager.SetAutoRun(GetAppFullPath());
            }
            else
            {
                RegistryManager.RemoveAutoRun();
            }
        }

        private string GetAppFullPath()
        {
            string filePath = Process.GetCurrentProcess().MainModule.FileName;

            if (!File.Exists(filePath))
            {
                throw new Exception("Incorrect file name: " + filePath);
            }

            return filePath;
        }

        private void ChangeRunStripItemValue(object sender, EventArgs e)
        {
            RegistryManager registry = new RegistryManager();
            var item = (ToolStripMenuItem)sender;

            if (item.Checked)
            {
                item.CheckState = CheckState.Unchecked;
            }
            else
            {
                item.CheckState = CheckState.Checked;
            }
        }

        private void SetLanguage(object sender, EventArgs e)
        {
            for (int i = 0; i < menuStrip.Items.Count; i++)
            {
                if (menuStrip.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    if (((ToolStripMenuItem)menuStrip.Items[i]).Name == settingsItemName &&
                        ((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems.Count > 0)
                    {
                        for (int n = 0; n < ((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems.Count; n++)
                        {
                            if (((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems[n].Name == languageItemName)
                            {
                                for (int m = 0; m < ((ToolStripMenuItem)((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems[n]).DropDownItems.Count; m++)
                                {
                                    if (((ToolStripMenuItem)((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems[n]).DropDownItems[m].Name == languageListItemName)
                                    {
                                        SectionRepository.Context().UpdateActiveLanguage(((ToolStripMenuItem)((ToolStripMenuItem)menuStrip.Items[i]).DropDownItems[n]).DropDownItems[m].Text);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
