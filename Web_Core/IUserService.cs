using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Data.Model;

namespace Web_Core_Service
{
   public interface IUserService
    {
       Task<long> SaveUserDetails(User user);    

        Task UpdateUserDetails(User user);

        Task<List<User>> GetUserDetails();


        Task<int> DeleteUser(long? userId);
       
    }
}
