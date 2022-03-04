using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CreditSuisse_WandersonCarvalho
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "MM/dd/yyyy";

            DateTime dateReference = DateTime.ParseExact("12/11/2020", "MM/dd/yyyy", CultureInfo.InvariantCulture);

            List<ITrade> trades = new List<ITrade>();

            trades.Add(new Trade(2000000, "Private", DateTime.ParseExact("12/29/2025", format, provider), false));
            trades.Add(new Trade(400000, "Public", DateTime.ParseExact("07/01/2020", format, provider), false));
            trades.Add(new Trade(5000000, "Public", DateTime.ParseExact("01/02/2024", format, provider), false));
            trades.Add(new Trade(3000000, "Public", DateTime.ParseExact("10/26/2023", format, provider), false));

            int numberOfTrades = trades.Count();

            Portifolio portifolio = new Portifolio(dateReference, numberOfTrades, trades);  
            
            portifolio.CalculateRisk().ToList().ForEach(i => Console.WriteLine("{0}", i));
        }
    }
}
