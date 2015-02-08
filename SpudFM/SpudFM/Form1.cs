using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SpudFM
{
    public partial class mainForm : Form
    {
        private List<string> tabbedCDirs = new List<string>();
        private bool searchHighlighted = false;
        parser p;
        functions f;

        public mainForm()
        {
            InitializeComponent();

            this.searchBar.GotFocus += onSearchFocus;
            this.searchBar.LostFocus += offSearchFocus;

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            p = new parser();
            f = new functions(p.get_user_def);

            
            searchBar.Text = "Enter Search Here";
        }

        /*  KeyboardShortcutFunctions  */
        #region KeyboardShortcutFunctions
        private void mainForm_KeyDown(object sender, KeyEventArgs e)
        {
            string letterPressed = "";

            if (e.Control && !e.Shift && !e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("ctrl+" + letterPressed).ToLower());
            }
            else if (!e.Control && e.Shift && !e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("shift+" + letterPressed).ToLower());

            }
            else if (!e.Control && !e.Shift && e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("alt+" + letterPressed).ToLower());
            }
            else if (e.Control && e.Shift && !e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("ctrl+shift+" + letterPressed).ToLower());
            }

            else if (!e.Control && e.Shift && e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("alt+shift+" + letterPressed).ToLower());
            }
            else if (e.Control && !e.Shift && e.Alt && !IsModifierKey(e.KeyCode))
            {
                letterPressed = GetLetterOfKeyPress(e);
                MessageBox.Show(("ctrl+alt+" + letterPressed).ToLower());
            }
        }

        private string GetLetterOfKeyPress(KeyEventArgs e)
        {
            return e.KeyCode.ToString();
        }

        private bool IsModifierKey(Keys key)
        {
            bool status = false;
            string keyStr = key.ToString();
            if (keyStr == "ShiftKey" ||
                keyStr == "ControlKey" ||
                keyStr == "Menu")
            {
                status = true;
            }
            return status;
        }


        #endregion


        /*   Search Bar Functions     */
        #region SearchBarFunctions
        private void onSearchFocus(object sender, EventArgs e)
        {
            if (searchBar.Text == "Enter Search Here")
            {
                searchBar.Text = String.Empty;
            }
            if (!searchHighlighted)
            {
                searchBar.Select(0, 0);
                searchBar.SelectionLength = searchBar.Text.Length;
                searchHighlighted = true;
            }
        }
        private void offSearchFocus(object sender, EventArgs e)
        {
            searchHighlighted = false;
        }
        #endregion

        

        /*   End Search Bar Functions     */

        /*   Misc Functions           */
        #region MiscFunctions


        private void Form1_Load(object sender, EventArgs e)
        {
            tabbedCDirs.Add(@"C:\Users\Collier\Dropbox");
        }

        private void newTab()
        {
            TabPage createdTabPage = new TabPage();
            //create new page, change focus to new page
            tabControl1.TabPages.Insert(tabControl1.TabPages.Count, createdTabPage);
            tabControl1.SelectedTab = createdTabPage;

            //add new current dir for new 
            tabbedCDirs.Add(@"C:\Users\Collier");

            updateTab();
        }

        private void updateTab()
        {
            listView1.Items.Clear();
            int tabIndex = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
            if (Directory.Exists(tabbedCDirs.ElementAt(tabIndex)))
            {
                //Directory.SetCurrentDirectory(textBox1.Text.ToString());
                string[] fileEntries = Directory.GetDirectories(tabbedCDirs.ElementAt(tabIndex));
                foreach (var dir in fileEntries)
                {
                    string[] row = new string[1];
                    row[0] = dir.ToString();
                    ListViewItem item = new ListViewItem(row);
                    listView1.Items.Add(item);
                }
            }
        }

        private void closeCurrentTab()
        {
            int tabIndex = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
            if (tabControl1.TabCount > 1)
            {
                if (tabIndex >= tabControl1.TabPages.Count - 1)
                {
                    tabbedCDirs.RemoveAt(tabIndex);
                    tabIndex--;
                }
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                tabControl1.SelectedTab = tabControl1.TabPages[tabIndex];
                updateTab();
            }
        }

        private void nextTab()
        {
            int tabIndex = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
            if (tabIndex >= tabControl1.TabPages.Count - 1)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[0];
                updateTab();
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabIndex + 1];
                updateTab();
            }
        }

        private void lastTab()
        {
            int tabIndex = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
            if (tabIndex <= 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabPages.Count - 1];
                updateTab();
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabIndex - 1];
                updateTab();
            }
        }

        private void upADir()
        {
            string temp = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            searchBar.Text = temp;
            Directory.SetCurrentDirectory(temp);
            temp = Directory.GetCurrentDirectory();
        }

        private void printCurDir()
        {
            int tabIndex = tabControl1.TabPages.IndexOf(tabControl1.SelectedTab);
            if (Directory.Exists(tabbedCDirs.ElementAt(tabIndex)))
            {
                string[] fileEntries = Directory.GetDirectories(tabbedCDirs.ElementAt(tabIndex));
                foreach (var dir in fileEntries)
                {
                    string[] row = new string[1];
                    row[0] = dir.ToString();
                    ListViewItem item = new ListViewItem(row);
                    listView1.Items.Add(item);
                }
            }
        }


        #endregion

    }
}
