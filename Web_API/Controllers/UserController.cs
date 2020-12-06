using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web_Core_Service;
using Web_Data.Model;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _user)
        {
            userService = _user;
        }


        /// <summary>
        /// get the user details
        /// </summary>
        /// <returns>
        /// returns the All users data
        /// </returns>
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetUserDetails()
        {
            try
            {
                var users = await userService.GetUserDetails();
                if (users == null)
                {
                    return NotFound();
                }

                return Ok(users);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        /// <summary>
        /// add the user details by paasing user model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// returns the userId
        /// </returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddUserDetails([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = await userService.SaveUserDetails(model);
                    if (userId > 0)
                    {
                        return Ok(userId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }



        /// <summary>
        /// update the user details by passing updated user model
        /// </summary>
        /// <param name="model"></param>
        /// <returns>
        /// returns the status
        /// </returns>
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateUserDetails([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userService.UpdateUserDetails(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }


        /// <summary>
        /// Delete the user based on userId
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// returns the status
        /// </returns>
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            int result = 0;

            try
            {
                result = await userService.DeleteUser(id);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
