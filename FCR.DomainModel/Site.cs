using System.Collections.Generic;

namespace FCR.DomainModel
{
    public class Site
    {
        public int Id { get; set; }

        public string SiteName { get; set; }

        public string SiteCode { get; set; }

        public virtual ICollection<FitnessCenter> FitnessCenters { get; set; }
    }
}
