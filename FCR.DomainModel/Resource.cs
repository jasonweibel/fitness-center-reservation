using System.Collections.Generic;

namespace FCR.DomainModel
{
    public class Resource
    {

        public int Id { get; set; }

        public string ResourceName { get; set; }

        public string ResourceDescription { get; set; }

        public virtual FitnessCenter FitnessCenter { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual ResourceType ResourceType { get; set; }
    }
}
