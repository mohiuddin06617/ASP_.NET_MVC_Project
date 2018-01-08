using PWEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PWRepository
{
    public class CustomInitializer : DropCreateDatabaseIfModelChanges<DataAccessContext>
    {
        protected override void Seed(DataAccessContext context)
        {
            UserDetail ud = new UserDetail
            {
                PhoneNumber = "null",
                FullName = "null",
                Email = "admin@gmail.com",
                Password = "admin123"
            };

            context.UserDetails.Add(ud);
            context.SaveChanges();
        }
    }
}
