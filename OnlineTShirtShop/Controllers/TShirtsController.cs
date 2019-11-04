using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OTSSCore.ApplicationServices;
using OTSSCore.Entities;

namespace OnlineTShirtShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TShirtsController : ControllerBase
    {
        private ITShirtService _tShirtService;

        public TShirtsController(ITShirtService tShirtService)
        {
            _tShirtService = tShirtService;
        }

        // GET api/pets
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<TShirt>> Get([FromQuery] Filter filter)
        {
            try
            {
                if(filter.CurrentPage==0 || filter.ItemsPrPage ==0)
                {
                    return _tShirtService.GetAllTshirts();
                }
                else
                {
                    return _tShirtService.GetFilteredTShirts(filter);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/owners
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult<TShirt> Post([FromBody] TShirt tShirt)
        {
            try
            {
                return Ok(_tShirtService.CreateTshirt(tShirt));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/owners/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<TShirt> Get(int id)
        {
            try
            {
                return _tShirtService.GetTShirt(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/owners/5
        [Authorize(Roles = "Administrator")]
        [HttpPut("{id}")]
        public ActionResult<TShirt> Put(int id, [FromBody] TShirt tShirt)
        {
            try
            {
                return _tShirtService.UpdateTshirt(tShirt);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/owenrs/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<TShirt> Delete(int id)
        {
            try
            {
                return _tShirtService.DeleteTShirt(id);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}