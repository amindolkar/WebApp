using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Data;
using Web_Data.Model;

namespace Web_Core
{
    public class userService : IUserService
    {
        private readonly UserDbContext userDBContext;

        public userService(UserDbContext _userDbContext)
        {
            userDBContext = _userDbContext;
        }

        public async  Task<int> Delete(long? userId)
        {
            int result = 0;

            if (userDBContext != null)
            {
                //Find the post for specific post id
                var user = await userDBContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (user != null)
                {
                    //Delete that post
                    userDBContext.Users.Remove(user);

                    //Commit the transaction
                    result = await userDBContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }       
     
        public async Task<List<User>> GetAllUsers()
        {
            if (userDBContext != null)
            {
                return await userDBContext.Users.ToListAsync();
            }

            return null;
        }


        public async Task<long> SaveUser(User user)
        {
            if (userDBContext != null)
            {
                await userDBContext.Users.AddAsync(user);
                await userDBContext.SaveChangesAsync();

                return user.UserId;
            }

            return 0;
        }

        public async Task Edit(User user)
        {
            if (userDBContext != null)
            {
                //Delete that post
                userDBContext.Users.Update(user);

                //Commit the transaction
                await userDBContext.SaveChangesAsync();
            }
        }
    }
}
