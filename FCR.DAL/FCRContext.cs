using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using FCR.DomainModel;

namespace FCR.DAL
{
    public class FCRContext : DbContext, IFCRContext
    {
        public IDbSet<FitnessCenter> FitnessCenters { get; set; }
        public IDbSet<CalendarEvent> CalendarEvents { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Reservation> Reservations { get; set; }
        public IDbSet<Resource> Resources { get; set; }
        public IDbSet<ResourceType> ResourceTypes { get; set; }
        public IDbSet<Site> Sites { get; set; }
        public IDbSet<User> User { get; set; }


        public FCRContext()
            : base("name=FCRContext")
        {
        }

        //private readonly ICreateAuditingRecord auditer;
        //public FCRContext(ICreateAuditingRecord auditer)
        //        : base()
        //{
        //    // Get the ObjectContext related to this DbContext
        //    var objectContext = (this as IObjectContextAdapter).ObjectContext;

        //    // Sets the command timeout for all the commands
        //    objectContext.CommandTimeout = 6000;

        //    this.auditer = auditer;
        //}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            new DbModelConfigurationBuilder().LoadConfigurations<FCRContext>(modelBuilder);
        }

        // DbEntityValidationException Approach via: http://stackoverflow.com/questions/15820505/dbentityvalidationexception-how-can-i-easily-tell-what-caused-the-error
        public override int SaveChanges()
        {
            //this.ApplyRules();

            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        //// Approach via @julielerman: http://bit.ly/123661P
        //private void ApplyRules()
        //{
        //    var changes = this.ChangeTracker.Entries<IAuditable>()
        //        .Where(
        //            e =>
        //                e.State == EntityState.Added || e.State == EntityState.Modified ||
        //                e.State == EntityState.Deleted);

        //    if (!changes.Any())
        //        return;

        //    foreach (var entry in changes)
        //    {
        //        var item = auditer.CreateAuditRecord(entry.Entity);
        //        this.Set(item.GetType()).Add(item);
        //    }
        //}


    }


}