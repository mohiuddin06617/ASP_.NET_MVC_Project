using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
using System.Security.Cryptography;

namespace PWRepository
{
    public class UserDetailRepository : Repository<UserDetail>, IUserDetailRepository
    {
        private DataAccessContext dataAccessContext = new DataAccessContext();
        //public bool Login(string email,string password)
        //{
        //    bool status = false;

        //    var x = dataAccessContext.UserDetails.Where(y => y.Email==email).FirstOrDefault();
        //    //.Equals(email) && y.Password.Equals(password)
        //    if (x != null)
        //    {
        //        //password = this.HasherFunc(password);
        //        if (string.Compare(password, x.Password) == 0)
        //        {
        //            status = true;
        //        }
        //        status = true;

        //    }
        //    return status;
        //}
        public int Login(string email, string password)
        {
            int UserId = 0;
            var x = dataAccessContext.UserDetails.Where(y => y.Email == email).FirstOrDefault();
            //.Equals(email) && y.Password.Equals(password)
            if (x != null)
            {
                //password = this.HasherFunc(password);
                if (string.Compare(password, x.Password) == 0)
                {
                    UserId = x.Id;
                }

            }
            return UserId;
        }
        public bool IsEmailExist(string email)
        {
            bool status = false;
            var v = dataAccessContext.UserDetails.Where(e => e.Email == email).FirstOrDefault();
            if (v != null)
            {
                status = true;
            }
            return status;
        }
        public string HasherFunc(string password)
        {
            string hashedPassword = Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password)));
            return hashedPassword;
        }

        public int UserIdByApiKey(string key)
        {
            int UserId = 0;
            var x = dataAccessContext.UserDetails.Where(y => y.ApiAccessUserName == key).FirstOrDefault();
            if (x != null)
            {
                UserId = x.Id;
            }
            return UserId;
        }
    }

}
