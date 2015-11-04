using System;

namespace FCR.WebApiModel
{
    public class AllCalendarEvent
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int FitnessCenterId { get; set; }
        public Nullable<int> SiteIdFk { get; set; }
        public string FitnessCenterDescription { get; set; }
        public int CalendarEventId { get; set; }
        public Nullable<int> FitnessCenterFk { get; set; }
        public string EventDescription { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
    }
}
