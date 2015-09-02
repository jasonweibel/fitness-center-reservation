using System.Collections.Generic;

namespace FCR.DomainModel
{
    public class FitnessCenter
    {
        public int Id { get; set; }

        public string CenterDescription { get; set; }

        public int UnitIntervalMinutes { get; set; }

        public int MaxConcurrentUnits { get; set; }

        public int OperationTimeUnitStart { get; set; }

        public int OperationTimeUnitLength { get; set; }

        public int MaxDaysOutForReservation { get; set; }
    }
}
