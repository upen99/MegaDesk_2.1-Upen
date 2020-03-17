using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_Upen
{
    public partial class ViewAllQuotes : Form
    {
        private Form _mainMenu;
        public ViewAllQuotes(Form mainMenu)
        {
            InitializeComponent();

            _mainMenu = mainMenu;
            loadgrid();
        }



        public void loadgrid()
        {
            var quotesFile = @"quotes.json";

            using (var reader = new StreamReader(quotesFile))

                {

                // load existing quotes
                string quotes = reader.ReadToEnd();
                List<DeskQuote> deskQuotes = JsonConvert.DeserializeObject<List<DeskQuote>>(quotes);

                dataGridView1.DataSource = deskQuotes.Select(d => new

                {

                    Data = d.QuoteDate,
                    Customer = d.CustomerName,
                    Depth = d.Desk.Depth,
                    Width = d.Desk.Width,
                    Drawers = d.Desk.NumberOfDrawers,
                    SuraceMaterial = d.Desk.SurfaceMaterial,
                    ShippingType = d.ShippingType,
                    QuoteAmount = d.QuotePrice.ToString("c")

                }).ToList();

                }

                
        }


        private void ViewAllQuotes_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewAllQuotes_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
