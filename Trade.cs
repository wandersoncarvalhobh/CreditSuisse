using System;

namespace CreditSuisse_WandersonCarvalho
{
    class Trade : ITrade
    {
        public double Value { get; }
        public string ClientSector { get; }
        public DateTime NextPaymentDate { get; }
        public bool IsPoliticallyExposed { get; }
 
        public Trade(double _Value, string _ClientSector, DateTime _NextPaymentDate, bool _IsPoliticallyExposed) 
        {
            Value = _Value;
            ClientSector = _ClientSector;
            NextPaymentDate = _NextPaymentDate;
            IsPoliticallyExposed = _IsPoliticallyExposed;
        }
    }
}
