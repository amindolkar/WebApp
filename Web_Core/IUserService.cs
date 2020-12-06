using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web_Data.Model;

namespace Web_Core
{
   public interface IUserService
    {
       Task<long> SaveUser(User user);    

        Task Edit(User user);

        Task<List<User>> GetAllUsers();


        Task<int> Delete(long? userId);
       
    }
}
