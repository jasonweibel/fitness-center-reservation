using System.Data.Entity.ModelConfiguration;
using FCR.DomainModel;

namespace FCR.DAL.Configurations
{
    public class FitnessCentersConfiguration : EntityTypeConfiguration<FitnessCenter>
    {
        public FitnessCentersConfiguration()
        {
            Property(p => p.CenterDescription).HasMaxLength(250);
        }
    }
}
