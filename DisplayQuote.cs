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
    public partial class DisplayQuote : Form
    {
        private Form _mainMenu;
        private DeskQuote _deskQuote;
        public DisplayQuote(Form mainMenu, DeskQuote deskQuote)
        {
            InitializeComponent();

            _mainMenu = mainMenu;
            _deskQuote = deskQuote;
            display_price.Text = _deskQuote.QuotePrice.ToString();
            customer_name.Text = _deskQuote.CustomerName;
            desk_width.Text = _deskQuote.Desk.Width.ToString();
            desk_depth.Text = _deskQuote.Desk.Depth.ToString();
            no_of_drawers.Text = _deskQuote.Desk.NumberOfDrawers.ToString();
            surface_material.Text = _deskQuote.Desk.SurfaceMaterial.ToString();
            rush_order.Text = _deskQuote.ShippingType.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void Display_Quote_FormClosed(object sender, FormClosedEventArgs e)
        {
            _mainMenu.Show();
        }

        private void display_price_Click(object sender, EventArgs e)
        {

        }
    }
}
