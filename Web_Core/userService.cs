using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web_Data;
using Web_Data.Model;
using Web_DataAccess;

namespace Web_Core_Service
{
    public class userService : IUserService
    {
        private readonly UserDbContext userDBContext;

        public userService(UserDbContext _userDbContext)
        {
            userDBContext = _userDbContext;
        }


        /// <summary>
        /// get all the  users data
        /// </summary>
        /// <returns>
        /// returns user data list
        /// </returns>
        public async Task<List<User>> GetUserDetails()
        {
            if (userDBContext != null)
            {
                return await userDBContext.Users.ToListAsync();
            }

            return null;
        }

        /// <summary>
        /// Save the user Details by passing user model
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// returns the saved userId
        /// </returns>
        public async Task<long> SaveUserDetails(User user)
        {
            if (userDBContext != null)
            {
                await userDBContext.Users.AddAsync(user);
                await userDBContext.SaveChangesAsync();

                return user.UserId;
            }

            return 0;
        }

        /// <summary>
        /// Update the  user Details by passing updated user model
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// returns the status
        /// </returns>
        public async Task UpdateUserDetails(User user)
        {
            if (userDBContext != null)
            {
                //Update that user
                userDBContext.Users.Update(user);

                //Commit the transaction
                await userDBContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete the user details based userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>
        /// returns the status
        /// </returns>
        public async  Task<int> DeleteUser(long? userId)
        {
            int result = 0;

            if (userDBContext != null)
            {
                //Find the user for specific user id
                var user = await userDBContext.Users.FirstOrDefaultAsync(x => x.UserId == userId);

                if (user != null)
                {
                    //Delete the user
                    userDBContext.Users.Remove(user);

                    //Commit the transaction
                    result = await userDBContext.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }       
     
       


       

       
    }
}
