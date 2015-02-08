using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpudFM
{
    public partial class mainForm : Form
    {
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
        

        
        #endregion

    }
}
