using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;

namespace PWRepository
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext()
        {
            Database.SetInitializer<DataAccessContext>(new CreateDatabaseIfNotExists<DataAccessContext>());
            Database.SetInitializer<DataAccessContext>(new DropCreateDatabaseIfModelChanges<DataAccessContext>());
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Orders { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
    }
}
