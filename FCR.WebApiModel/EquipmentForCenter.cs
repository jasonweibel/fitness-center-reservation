namespace FCR.WebApiModel
{
    public class EquipmentForCenter
    {
        public int Id { get; set; }
        public int FitnessCenterId { get; set; }
        public int TypeId { get; set; }
        public string TypeDesc { get; set; }
        public string Name { get; set; }
        public string FullName { get; set; }

    }
}
