using Microsoft.AspNetCore.Mvc;
using ProjetStage.Business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjetStage.Controlleurs
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {

        private ISalarieService _salarieService;

        public SalariesController(ISalarieService salarieService)
        {
            _salarieService = salarieService;
        }

        // GET: api/<SalariesController>
        [HttpGet("GetAll")]
        //[Route("GetAll")]
        

        // GET api/<SalariesController>/5
        [HttpGet("GetSalarieById/{id}")]
       
        public string Get(int id)
        {
            return _salarieService.GetById(id).ToString();
        }

        // POST api/<SalariesController>
        [HttpPost("AddUser")]
        
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SalariesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SalariesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
