namespace FCR.WebApiModel
{
    public class AllResource
    {
        public int FitnessCenterId { get; set; }
        public int SiteIdFk { get; set; }
        public string FitnessCenterDescription { get; set; }
        public int UnitIntervalMinutes { get; set; }
        public int MaxConcurrentUnits { get; set; }
        public int OperationTimeUnitStart { get; set; }
        public int OperationTimeUnitLength { get; set; }
        public int SiteId { get; set; }
        public string SiteName { get; set; }
        public string SiteCode { get; set; }
        public int ResourceTypeId { get; set; }
        public string ResourceTypeDescription { get; set; }
        public int ResourceId { get; set; }
        public int FitnessCenterFk { get; set; }
        public int ResourceTypeFk { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
    }
}
