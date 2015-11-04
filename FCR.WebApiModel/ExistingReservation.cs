namespace FCR.WebApiModel
{
    public class ExistingReservation
    {
        public int Id { get; set; }
        public int FitnessCenterId { get; set; }
        public int DayId { get; set; }
        public string StartTime { get; set; }
        public int StartMinutesSinceMidnight { get; set; }
        //public string EndTime { get; set; }
        //public int EndMinutesSinceMidnight { get; set; }
        public int EquipmentId { get; set; }
        public string EquipmentName { get; set; }
        public string EquipmentTypeDescription { get; set; }
        public int EquipmentTypeId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int IntervalLength { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
    }
}
