using System;

namespace FCR.DomainModel
{
    public class Reservation
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime ReservationDate { get; set; }

        public int ReservationTimeUnitStart { get; set; }

        public int ReservationTimeUnitLength { get; set; }

        public bool Validated { get; set; }

        public virtual Resource Resource { get; set; }

        public virtual User User { get; set; }
    }
}
