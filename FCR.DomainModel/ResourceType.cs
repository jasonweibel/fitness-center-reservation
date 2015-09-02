using System.Collections.Generic;

namespace FCR.DomainModel
{
    public class ResourceType
    {
        public int Id { get; set; }

        public string ResourceTypeDescription { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }
    }
}
