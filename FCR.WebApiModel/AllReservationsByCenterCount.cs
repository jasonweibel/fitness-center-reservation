using System;

namespace FCR.WebApiModel
{
    public class AllReservationsByCenterCount
    {
        private int? _totalUnits;
        public System.DateTime ReservationDate { get; set; }
        public int FitnessCenterFk { get; set; }

        public Nullable<int> TotalUnits
        {
            get { return _totalUnits; }
            set { _totalUnits = value; }
        }
    }
}
