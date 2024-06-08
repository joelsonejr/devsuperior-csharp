using System.Runtime.Versioning;

namespace Desafio
{
    class Bill
    {
        public char Gender;
        public int Beer, Barbecue, SoftDrink;


        double consumptionCost, ticketCost, coverCost;

        public double Cover()
        {
            if (consumptionCost < 30)
            {
                coverCost = 4.00;
            }
            else
            {
                coverCost = 0.00;
            }

            return coverCost;
        }

        public double Feeding()
        {
            int barbecuePrice = 7;
            int beerPrice = 5;
            int softdrinkPrice = 3;

            int barbecueTotal, beerTotal, softTotal;

            barbecueTotal = barbecuePrice * Barbecue;
            beerTotal = beerPrice * Beer;
            softTotal = softdrinkPrice * SoftDrink;

            consumptionCost = barbecueTotal + beerTotal + softTotal;

            return consumptionCost;
        }

        public double Ticket()
        {
            if (Gender == 'M')
            {
                ticketCost = 10.00;
            }
            else
            {
                ticketCost = 8.00;
            }

            return ticketCost;
        }

        public double Total()
        {

            return consumptionCost + coverCost + ticketCost;
        }

    }
}