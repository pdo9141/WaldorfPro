using System.Data.Entity;
using Waldorf.Domain;

namespace Waldorf.DataModel
{
    public class WaldorfContext : DbContext
    {
        public WaldorfContext() : base("WaldorfPro")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Party> Parties { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<PostedJobPosition> PostedJobPositions { get; set; }
    }
}
