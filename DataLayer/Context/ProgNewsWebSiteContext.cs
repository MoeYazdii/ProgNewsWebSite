using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProgNewsWebSiteContext:DbContext
    {
        public ProgNewsWebSiteContext()
            : base("Data Source=.;Initial Catalog=ProgNewsWebSite;MultipleActiveResultSets=true;Integrated Security=True") // Use your connection string name
        {
        }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<NewsPage> NewsPage { get; set; }
        public DbSet<PageComment> PageComments { get; set; }

    }
}
