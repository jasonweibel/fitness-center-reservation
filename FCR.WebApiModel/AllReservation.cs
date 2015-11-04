namespace FCR.WebApiModel
{
    public class AllReservation
    {
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int FitnessCenterId { get; set; }
        public int SiteIdFk { get; set; }
        public string FitnessCenterDescription { get; set; }
        public int UnitIntervalMinutes { get; set; }
        public int MaxConcurrentUnits { get; set; }
        public int ReservationId { get; set; }
        public string ReservationDescription { get; set; }
        public int UserFk { get; set; }
        public int ResourceFk { get; set; }
        public System.DateTime ReservationDate { get; set; }
        public int ReservationTimeUnitStart { get; set; }
        public int ReservationTimeUnitLength { get; set; }
        public int ResourceId { get; set; }
        public int FitnessCenterFk { get; set; }
        public int ResourceTypeFk { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public int ResourceTypeId { get; set; }
        public string ResourceTypeDescription { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool Validated { get; set; }
    }
}
