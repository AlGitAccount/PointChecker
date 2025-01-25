using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

using PointChecker.DataStructure;
using PointChecker.DataRepository;
using PointChecker.CustomControl;
using PointChecker.Registry;

namespace PointChecker
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            GenerateToolStripItems();
            IsShowInSystemTray = true;
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            notifyIcon.BalloonTipTitle = "";
            notifyIcon.BalloonTipText = "";
            notifyIcon.Text = "";
        }

        private void GenerateToolStripItems()
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
            contextMenuStrip.Items.AddRange(toolStripItemList.ToArray());
        }

        public bool IsShowInSystemTray { get; set; }

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
            menuItem.Name = "SettingsToolStripMenuItem";
            menuItem.Text = SectionRepository.Context().GeneralMenuNames.Settings;
            return menuItem;
        }

        private ToolStripItem GetAutoRunStripItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = "AutoStartToolStripMenuItem";
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
            languageListmenuItem.Name = "LanguageListToolStripMenuItem";
            languageListmenuItem.Text = SectionRepository.Context().LanguageTitle;
            languageListmenuItem.DropDownClosed += new EventHandler(SetLanguage);
            languageListmenuItem.Size = new Size(46, 22);

            ToolStripMenuItem languageMenuItem = new ToolStripMenuItem();
            languageMenuItem.DropDownItems.AddRange(new ToolStripItem[] { languageListmenuItem });
            languageMenuItem.Name = "languageToolStripMenuItem";            
            languageMenuItem.Text = SectionRepository.Context().GeneralMenuNames.Language;

            return languageMenuItem;
        }

        private ToolStripItem GetQuitToolStripItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Name = "QuitToolStripMenuItem";
            menuItem.Text = SectionRepository.Context().GeneralMenuNames.Quit;
            menuItem.Click += new EventHandler(CloseMainForm);
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

        public void CloseMainForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetLanguage(object sender, EventArgs e)
        {
            //foreach (ToolStripMenuItem mainmenu in contextMenuStrip.Items)
            //{
            //    foreach (ToolStripItem item in mainmenu.DropDownItems)
            //    {
            //        var x = item.Text;
            //    }
            //}

            for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            { 
                if (contextMenuStrip.Items[i].GetType() == typeof(ToolStripMenuItem))
                {
                    if (((ToolStripMenuItem)contextMenuStrip.Items[i]).Name == "SettingsToolStripMenuItem" && 
                        ((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems.Count > 0)
                    { 
                        for (int n = 0; n < ((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems.Count; n++)
                        {
                            if (((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems[n].Name == "languageToolStripMenuItem")
                            {
                                for (int m = 0; m < ((ToolStripMenuItem)((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems[n]).DropDownItems.Count; m++)
                                {
                                    if (((ToolStripMenuItem)((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems[n]).DropDownItems[m].Name == "LanguageListToolStripMenuItem")
                                    {
                                        SectionRepository.Context().UpdateActiveLanguage(((ToolStripMenuItem)((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems[n]).DropDownItems[m].Text);                                        
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }


            //var mnm = SectionRepository.Context().ActiveLanguage;
            //var dfe = 1;
            

            //'System.Windows.Forms.ToolStripSeparator' to type 'System.Windows.Forms.ToolStripMenuItem'.'


            //var x1 = contextMenuStrip;
            //var currentLanguageValue = contextMenuStrip.Items[3]; //("LanguageListToolStripMenuItem").Text;





            //for (int i = 0; i < contextMenuStrip.Items.Count; i++)
            //{
            //    var y1 = ((ToolStripMenuItem)contextMenuStrip.Items[i]).DropDownItems;

            //    var y2 = y1[0];
            //    var y3 = y1[0].Text;
            //    var y4 = y1[0].Name;

            //    var x = 4;
            //}



            //contextMenuStrip.
            //SectionRepository.Context().UpdateActiveLanguage(currentLanguageValue);
            var x2 = 1;
        }

        private void FMain_MinimumSizeChanged(object sender, EventArgs e)
        {
            if (IsShowInSystemTray)
            { 
                this.notifyIcon.Visible = true;
            }
            else 
            {
                this.notifyIcon.Visible = false;
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
    }
}
