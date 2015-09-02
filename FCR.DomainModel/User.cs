using System.Collections.Generic;

namespace FCR.DomainModel
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public bool IsAdmin { get; set; }
    }
}
