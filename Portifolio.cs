using System;
using System.Collections.Generic;
using System.Text;

namespace CreditSuisse_WandersonCarvalho
{
    sealed class Portifolio
    {
        private DateTime DateReference { get; }
        private int NumberOfTrades { get; }
        private List<ITrade> Trades { get; }

        public Portifolio(DateTime _dateReference, int _NumberOfTrade, List<ITrade> _trades)
        {
            DateReference = _dateReference;
            NumberOfTrades = _NumberOfTrade;
            Trades = _trades;
        }

        public RISK[] CalculateRisk()
        {
            RISK[] riskClassification = new RISK[NumberOfTrades];

            for (int i = 0; i < NumberOfTrades; i++)
            {
                if (Trades[i].IsPoliticallyExposed)
                {
                    riskClassification[i] = RISK.PEP;
                    continue;
                }

                if (Trades[i].NextPaymentDate.AddDays(30) < DateReference)
                {
                    riskClassification[i] = RISK.EXPIRED;
                    continue;
                }

                if (Trades[i].Value > 1000000 && Trades[i].ClientSector.Equals("Private"))
                {
                    riskClassification[i] = RISK.HIGHRISK;
                    continue;
                }

                if (Trades[i].Value > 1000000 && Trades[i].ClientSector.Equals("Public"))
                {
                    riskClassification[i] = RISK.MEDIUMRISK;
                    continue;
                }

            }

            return riskClassification;
        }
    }
}
