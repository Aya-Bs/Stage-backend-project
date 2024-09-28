using Microsoft.AspNetCore.Mvc;
using StageApp.Models;
using StageApp.Business;
using StageApp.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IAdresseService _adresseService;

        public AdressesController(IAdresseService adresseService)
        {
            _adresseService = adresseService;
        }

        // GET: api/<AdressesController>
        [HttpGet]
        public IActionResult Get()
        {
            var adresses = _adresseService.GetAll(); // or _adresseRepository.GetAll();
            return Ok(adresses);
        }

        // GET api/<AdressesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var adresse = _adresseService.GetById(id);
            if (adresse == null)
            {
                return NotFound();
            }
            Console.WriteLine(adresse);
            return Ok(_adresseService.GetById(id));
        }

        // POST api/<AdressesController>
        [HttpPost]
        public IActionResult Post(AdresseDto adresseDto)
        {
            if (adresseDto == null ) //_adresseService.GetById(adresse.IdAdresse) != null)
            {
                return BadRequest();
            }
            var adresse = new Adresse
            {
                Adresse1 = adresseDto.Adresse1,
                CodePostal = adresseDto.CodePostal,
                Ville = adresseDto.Ville
            };

            return Ok(_adresseService.Add(adresse));
        }

        // PUT api/<AdressesController>/5
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AdresseDto dto)
        {
            var result = await _adresseService.Update(id, dto);

            if (result)
            {
                return Ok("Update successful");
            }
            else
            {
                return NotFound("Adresse not found");
            }
        }



        // DELETE api/<AdressesController>/5
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_adresseService.Delete(id));
        }
    }
}
