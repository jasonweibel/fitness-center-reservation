using System.Data.Entity;
using FCR.DomainModel;

namespace FCR.DAL
{
    public interface IFCRContext
    {
        IDbSet<FitnessCenter> FitnessCenters { get; set; }
        IDbSet<CalendarEvent> CalendarEvents { get; set; }
        IDbSet<Client> Clients { get; set; }
        IDbSet<Reservation> Reservations { get; set; }
        IDbSet<Resource> Resources { get; set; }
        IDbSet<ResourceType> ResourceTypes { get; set; }
        IDbSet<Site> Sites { get; set; }
        IDbSet<User> User { get; set; }

        int SaveChanges();
    }
}