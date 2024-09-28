using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StageApp.Models;
using StageApp.Business;
using StageApp.DTO;

namespace StageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArchitecturesController : ControllerBase
    {
        private readonly IArchitecteService _architecteService;
        private readonly IAdresseService _adresseService;
        private readonly IContactService _contactService;

        public ArchitecturesController(IArchitecteService architecteService)
        {
            _architecteService = architecteService;
        }

        [HttpGet]


        public IEnumerable<Architecte> Get()
        {
            return _architecteService.GetAll();
        }
        [HttpPost]
        public IActionResult Post( ArchitecteDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var architecte = new Architecte
            {
                RasionSocial = dto.RaisonSocial,
                NomArchitecte = dto.NomArchitecte,
                PrenomArchitecte = dto.PrenomArchitecte,
                IdAdresse = dto.IdAdresse,
                SirenArchitecte = dto.SirenArchitecte,
                IdContact = dto.IdContact
            };
            var contact = _contactService.GetById(dto.IdContact);

            if (contact == null)
            {
                return NotFound("Contact not found.");
            }
            if (_adresseService.GetById(dto.IdAdresse) == null)
            {
                return BadRequest("Invalid Adresse ID. No matching record found.");
            }

            return Ok(_architecteService.Add(architecte));
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            
            return Ok(_architecteService.Update(id));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_architecteService.Delete(id));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var architecte = _architecteService.GetById(id);
            if (architecte == null)
            {
                return NotFound();
            }
            Console.WriteLine(_architecteService.GetById(id));

            return Ok(_architecteService.GetById(id));
        }


    }
}
