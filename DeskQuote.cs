using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MegaDesk_Upen
{ 
    public enum Shipping
    {
        Rush3Day,
        Rush5Day,
        Rush7Day,
        NoRush
    }

   public class DeskQuote
    {
        int[,] rushOrderPrices;
        public DeskQuote()
        {
            //TODO: load rush order shipping costs from rushOrderPrices.txt file into _rushOrderPrices
            GetRushOrderPrices();
        }

        // declare const
        const decimal BASE_PRICE = 200.00M;
        const decimal SURFACE_AREA_COST = 1.00M;
        const decimal DRAWER_COST = 50.00M;
        const decimal OAK_COST = 200.00M;
        const decimal LAMINATE_COST = 100.00M;
        const decimal PINE_COST = 50.00M;
        const decimal ROSEWOOD_COST = 300.00M;
        const decimal VENEER_COST = 125.00M;

        public string CustomerName { get; set; }

        public DateTime QuoteDate { get; set; }

        public Shipping ShippingType { get; set; }

        public decimal QuotePrice { get; set; }

        public Desk Desk { get; set; }


        // methods
        public decimal GetQuotePrice()
        {
            decimal runningTotal = 0;

            // add base price
            runningTotal = BASE_PRICE;

            
            // add surface area
            decimal surfaceArea = this.Desk.Width * this.Desk.Depth;
            
            var surfaceArePrice = 0M;
            if (surfaceArea > 1000)
            {
                surfaceArePrice = (surfaceArea - 1000) * SURFACE_AREA_COST; //declare the const
            }

            runningTotal += surfaceArePrice;


            // add drawers
            var drawerCost = this.Desk.NumberOfDrawers * DRAWER_COST; //declare the const

            runningTotal += drawerCost;

            // add surface material
            var surfaceMaterialCost = 0m;

            switch (this.Desk.SurfaceMaterial)
            {
                case Surface.Oak:
                    surfaceMaterialCost = OAK_COST; //declare the const
                    break;

                case Surface.Laminate:
                    surfaceMaterialCost = LAMINATE_COST; //declare the const
                    break;

                case Surface.Pine:
                    surfaceMaterialCost = PINE_COST; //declare the const
                    break;

                case Surface.Rosewood:
                    surfaceMaterialCost = ROSEWOOD_COST; //declare the const
                    break;

                case Surface.Veneer:
                    surfaceMaterialCost = VENEER_COST; //declare the const
                    break;
            }

            runningTotal += surfaceMaterialCost;

            decimal rushOrderPrice = 0M;
            //TODO: calculate shipping cost from rushOrderPrices.txt file
            switch(this.ShippingType)
            {
                case Shipping.Rush3Day:
                    //TODO: add rush3day price based on size to running total
                    if (surfaceArea < 1000)
                        rushOrderPrice = rushOrderPrices[0,0];
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                        rushOrderPrice = rushOrderPrices[0, 1];
                    else if (surfaceArea > 2000)
                        rushOrderPrice = rushOrderPrices[0, 2];
                    //EXAMPLE: add _rushOrderPrices[0,0] to runningTotal variable
                    break;

                case Shipping.Rush5Day:
                    if (surfaceArea < 1000)
                        rushOrderPrice = rushOrderPrices[1, 0];
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                        rushOrderPrice = rushOrderPrices[1, 1];
                    else if (surfaceArea > 2000)
                        rushOrderPrice = rushOrderPrices[1, 2];
                    break;

                case Shipping.Rush7Day:
                    if (surfaceArea < 1000)
                        rushOrderPrice = rushOrderPrices[2, 0];
                    else if (surfaceArea >= 1000 && surfaceArea <= 2000)
                        rushOrderPrice = rushOrderPrices[2, 1];
                    else if (surfaceArea > 2000)
                        rushOrderPrice = rushOrderPrices[2, 2];
                    break;
            }

            runningTotal += rushOrderPrice;

            // TODO: add logic to calculate price

            return runningTotal;

        }

        private void GetRushOrderPrices()
        {
            try
            {
                string[] rushAmount = File.ReadAllLines(@"rushOrderPrices.txt");

                rushOrderPrices = new int[3, 3];
                int count = 0;

                for (int s = 0; s < 3; s++)
                {
                    for (int t = 0; t < 3; t++)
                    {
                        rushOrderPrices[s, t] = int.Parse(rushAmount[count]);
                        count++;
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
