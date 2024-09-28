using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StageApp.Models;
using StageApp.Business;
using StageApp.DTO;

namespace StageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var contacts = _contactService.GetAll(); // or _contactRepository.GetAll();
            return Ok(contacts);
        }
        [HttpGet("GetContactById/{id}")]
        public IActionResult Get(int id)
        {
            var contact = _contactService.Get(id);
            Console.WriteLine(contact);
            return Ok(contact);
        }

        [HttpPost("AddContact")]
        
        public IActionResult Post( ContactDto contactDto)
        {
            if (contactDto == null)
            {
                return BadRequest();
            }

            var contact = new Contact
            {
                Nom = contactDto.Nom,
                Prenom = contactDto.Prenom,
                Tel1 = contactDto.Tel1,
                Tel2 = contactDto.Tel2,
                Mail = contactDto.Mail,
                ContactType = contactDto.ContactType,
                Fonction = contactDto.Fonction,
                SalariePrioriteContact = contactDto.SalariePrioriteContact,
                Commentaires = contactDto.Commentaires
            };

            return Ok(_contactService.Add(contact));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_contactService.Delete(id));
        }

        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            return Ok(_contactService.Update(id)); 
        }
        

        [HttpPost("add-sample-contact")]
        public IActionResult AddSampleContact()
        {
            // Create a sample ContactDto
            var contactDto = new ContactDto
            {
                Nom = "Sample Name",
                Prenom = "Sample Prenom",
                Tel1 = "12345678",
                Tel2 = "87654321",
                Mail = "sample@example.com",
                ContactType = "moa",
                Fonction = "engineer",
                SalariePrioriteContact = "01",
                Commentaires = "This is a sample contact"
            };

            // Log the contactDto
          
            // Map to Contact entity
            var contact = new Contact
            {
                Nom = contactDto.Nom,
                Prenom = contactDto.Prenom,
                Tel1 = contactDto.Tel1,
                Tel2 = contactDto.Tel2,
                Mail = contactDto.Mail,
                ContactType = contactDto.ContactType,
                Fonction = contactDto.Fonction,
                SalariePrioriteContact = contactDto.SalariePrioriteContact,
                Commentaires = contactDto.Commentaires
            };

            // Add the contact to the database
            var result = _contactService.Add(contact);
            return Ok(result);
        }
    }
}
