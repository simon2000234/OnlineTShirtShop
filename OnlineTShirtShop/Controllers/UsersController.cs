using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTSSCore.ApplicationServices;
using OTSSCore.Entities;

namespace OnlineTShirtShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/pets
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery] Filter filter)
        {
            try
            {
                if (filter.CurrentPage == 0 || filter.ItemsPrPage == 0)
                {
                    return _userService.GetAllUsers();
                }
                else
                {
                    return _userService.GetFilteredUsers(filter);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/owners
        [HttpPost]
        public ActionResult<TShirt> Post([FromBody] UserLogin user)
        {
            try
            {
                return Ok(_userService.CreateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        public ActionResult<TShirt> Get(int id)
        {
            try
            {
                return Ok(_userService.GetUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/owners/5
        [HttpPut("{id}")]
        public ActionResult<TShirt> Put(int id, [FromBody] UserLogin user)
        {
            try
            {
                return Ok(_userService.UpdateUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/owenrs/5
        [HttpDelete("{id}")]
        public ActionResult<TShirt> Delete(int id)
        {
            try
            {
                return Ok(_userService.DeleteUser(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}