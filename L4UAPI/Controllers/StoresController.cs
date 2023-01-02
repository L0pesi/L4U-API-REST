using L4U_BAL_SERVICES.Logic;
using L4U_BOL_MODEL.Models;
using L4U_DAL_DATA.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace L4U_WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly StoresLogic _storeLogic;
        public StoresController()
        {
            _storeLogic = new StoresLogic();
        }


        //GET :api/LockerController
        [HttpGet]
        public IEnumerable<Store> Get()
        {
            return _storeLogic.GetAll;
        }

        [HttpPost]
        public void Post([FromBody] Store store)
        {

            _storeLogic.AddStores(store);
        }

        /*
        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
