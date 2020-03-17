using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Upen
{
    public partial class MainMenu : Form
    {
        
        public MainMenu()
        {
            InitializeComponent();
           
        }

        private void BtnAddNewQuote_Click(object sender, EventArgs e)
        {

            //create and show Add Quote form
            var addQuote = new AddNewQuote(this);
            addQuote.Tag = this;
            addQuote.Show();


            // hide main menue
            this.Hide();
        }

        private void BtnViewQuotes_Click(object sender, EventArgs e)
        {
            var viewAllQuotes = new ViewAllQuotes(this);
            viewAllQuotes.Show();
        }

        private void btnSearchQuote_Click(object sender, EventArgs e)
        {
            var searchQuotes = new SearchQuotes(this);
            searchQuotes.Show();
          
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
