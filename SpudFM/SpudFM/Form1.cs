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
        public mainForm()
        {
            InitializeComponent();
            this.searchBar.GotFocus += onSearchFocus;
            this.searchBar.LostFocus += offSearchFocus;

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            searchBar.Text = "Enter Search Here";
        }

        /*   Misc Functions           */

        /*   End Misc Functions       */

        /*   Search Bar Functions     */
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

        /*   End Search Bar Functions     */


    }
}
