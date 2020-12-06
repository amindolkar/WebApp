using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Core;
using Web_Data.Model;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class HomeController : ControllerBase
    {
        private readonly IUserService userService;

        public HomeController(IUserService _user)
        {
            userService = _user;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var categories = await userService.GetAllUsers(); 
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var postId = await userService.SaveUser(model);
                    if (postId > 0)
                    {
                        return Ok(postId);
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

        
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit([FromBody] User model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await userService.Edit(model);

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


        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(long? userId)
        {
            int result = 0;

            if (userId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await userService.Delete(userId);
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
