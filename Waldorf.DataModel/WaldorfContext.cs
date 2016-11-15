using System.Data.Entity;
using Waldorf.Domain;

namespace Waldorf.DataModel
{
    public class WaldorfContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
    }
}
