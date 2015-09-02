using System.Data.Entity.ModelConfiguration;
using FCR.DomainModel;

namespace FCR.DAL.Configurations
{


    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.IsAdmin).IsRequired();
            Property(p => p.FirstName).IsRequired().HasMaxLength(250);
            Property(p => p.LastName).IsRequired().HasMaxLength(250);
        }
    }

}
