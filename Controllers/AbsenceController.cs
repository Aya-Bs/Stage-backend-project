using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StageApp.Business;

namespace StageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceController : ControllerBase
    {
        private readonly IAbsenceService _absenceService;

        public AbsenceController(IAbsenceService absenceService)
        {
            _absenceService = absenceService;
        }
        
        
    }
}
