using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DOTNET2.Services.UniversitiesService;
using Microsoft.AspNetCore.Mvc;


namespace Uni.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniController : ControllerBase
    {
        private static List<Universities> universities  = new List<Universities>{
          new  Universities(),
          new Universities { Id = 1, Country = "Italy", UniName = "University of Rome", UniWebpage = "https://www.uniroma.it" },

        };
        private readonly IUniversitiesService _universitiesService;

        public UniController(IUniversitiesService universitiesService)
        {
            _universitiesService = universitiesService; // Dependency injection

            if (universitiesService is null)
            {
                throw new ArgumentNullException(nameof(universitiesService));
            }

        }

        [HttpGet("GetAll")] 
        public async Task<ActionResult<ServiceResponse<List<Universities>>>> Get()
        {
            return Ok(await _universitiesService.GetUniversities());
        }
    
        [HttpGet("GetSingle/{Country}")]
        public async Task<ActionResult<ServiceResponse<Universities>>> GetSingle(string Country)
        {
            return Ok(await _universitiesService.GetSingleUniversity(Country)); // Return the first uni with the country of the uni
        }

        [HttpPost("AddUni")]
        public async Task<ActionResult<ServiceResponse<List<Universities>>>> AddUni(Universities uni)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://raw.githubusercontent.com/Hipo/university-domains-list/master/world_universities_and_domains.json");
            universities.Add(uni);
            return Ok(await _universitiesService.AddUni(uni)); // Return the list of universities
        }
    }
}
