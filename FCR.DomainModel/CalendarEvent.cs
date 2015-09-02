using System;

namespace FCR.DomainModel
{
    public  class CalendarEvent
    {
        public int Id { get; set; }

        public string eventDescription { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        public bool? isAvailable { get; set; }

        public virtual FitnessCenter FitnessCenter { get; set; }
    }
}
