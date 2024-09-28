using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StageApp.Models;
using StageApp.Business;
using StageApp.DTO;

namespace StageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatureController : ControllerBase
    {
        private readonly ICandidatureService _candidatureService;

        public CandidatureController(ICandidatureService candidatureService)
        {
            _candidatureService = candidatureService;
        }

        // Remove [HttpPost] annotation
        private Candidature MapDtoToEntity(CandidatureDto dto)
        {
            return new Candidature
            {
                IdCandidature = dto.IdCandidature,
                DateRendu = DateTime.Parse(dto.DateRendu),
                MtIndemnite = dto.MtIndemnite,
                MtHtTravaux = dto.MtHtTravaux,
                Stream = dto.Stream,
                Offre = dto.Offre,
                Dpi = dto.Dpi,
                IdStatut = dto.IdStatut,
                IdSalarie = dto.IdSalarie,
                IdPrestation = dto.IdPrestation,
                IdArchitecte = dto.IdArchitecte,
                IdStatutExclusivite = dto.IdStatutExclusivite,
                Commentaire = dto.Commentaire
            };
        }

        // Remove [HttpPost] annotation
        private CandidatureDto MapEntityToDto(Candidature entity)
        {
            return new CandidatureDto
            {
                IdCandidature = entity.IdCandidature,
                DateRendu = entity.DateRendu.ToString(),
                MtIndemnite = entity.MtIndemnite,
                MtHtTravaux = entity.MtHtTravaux,
                Stream = entity.Stream,
                Offre = entity.Offre,
                Dpi = entity.Dpi,
                IdStatut = entity.IdStatut,
                IdSalarie = entity.IdSalarie,
                IdPrestation = entity.IdPrestation,
                IdArchitecte = entity.IdArchitecte,
                IdStatutExclusivite = entity.IdStatutExclusivite,
                Commentaire = entity.Commentaire
            };
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var candidatures = _candidatureService.GetAll(); // or _candidatureRepository.GetAll();
            return Ok(candidatures);
        }
        [HttpGet("GetAllCan")]
        public JsonResult GetAllCan()
        {
            var candidatures = _candidatureService.GetAll(); // or _candidatureRepository.GetAll();
            return new JsonResult(candidatures);
        }
        [HttpGet("GetCandidatureById/{id}")]
        public IActionResult Get(int id)
        {
            var candidature = _candidatureService.GetById(id);
            if (candidature == null)
            {
                return NotFound();
            }
            Console.WriteLine(candidature);
            return Ok(_candidatureService.GetById(id));
        }
        [HttpPost("AddCandidature")]
        public IActionResult Post( CandidatureDto candidatureDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var candidature = MapDtoToEntity(candidatureDto);
             
            return Ok(_candidatureService.Add(candidature));
        }

        /*[HttpPost("AddCandidatureJson")]
        public JsonResult PostJson([FromBody] Candidature candidature)
        {
            if (candidature == null)
            {
                return new JsonResult("Candidature is null");
            }
            return new JsonResult(_candidatureService.Add(candidature));
        }*/
        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_candidatureService.Delete(id));
        }
        [HttpDelete("DeleteJson/{id}")]
        public JsonResult DeleteJson(int id)
        {

            return new JsonResult(_candidatureService.Delete(id));
        }

        [HttpPut("Update/{id}")]
        public IActionResult Put(int id, [FromBody] CandidatureDto dto)
        {
            return Ok(_candidatureService.Update(id)); 
        }
    }
}
