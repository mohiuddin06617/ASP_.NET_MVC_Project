using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DataAccessContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Footer> FooterInfo { get; set; }
        public DbSet<Login> LoginInfo { get; set; }
        public DbSet<UserDetails> UserDetailsInfo { get; set; }

    }
}
