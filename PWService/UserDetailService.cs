using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PWEntity;
using PWRepository;

namespace PWService
{
    public class UserDetailService : Service<UserDetail>, IUserDetailService
    {
        private UserDetailRepository userRepo = new UserDetailRepository();
        //public bool Login(string email,string password)
        //{
        //    bool stat=userRepo.Login(email, password);
        //    return stat;
        //}
        public int Login(string email, string password)
        {
            int UserId = userRepo.Login(email, password);
            return UserId;
        }
        public bool IsEmailExist(string email)
        {
            bool stat = userRepo.IsEmailExist(email);
            return stat;
        }
        public string HasherFunc(string password)
        {
            return userRepo.HasherFunc(password);
        }
        public int UserIdByApiKey(string key)
        {
            int UserId = userRepo.UserIdByApiKey(key);
            return UserId;
        }
        
    }

}
