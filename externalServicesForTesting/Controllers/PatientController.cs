using Microsoft.AspNetCore.Mvc;
using Prescription.Domain.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace externalServicesForTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        public static readonly Guid patient1Id = new Guid("11111111-1111-1111-1111-111111111111");
        public static readonly Guid patient2Id = new Guid("22222222-2222-2222-2222-222222222222");

        // GET: api/<PatientController>
        [HttpGet]
        public IEnumerable<PatientDto> Get()
        {
            var patient1 = new PatientDto
            {
                Id = patient1Id,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 10, 15)
                // Add more properties as needed
            };

            var patient2 = new PatientDto
            {
                Id = patient2Id,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 5, 25)
                // Add more properties as needed
            };

            return new List<PatientDto> { patient1, patient2 };
        }

        // GET api/<PatientController>/5
        [HttpGet("{id}")]
        public PatientDto GetByID(Guid id)
        {
            var patient1 = new PatientDto
            {
                Id = patient1Id,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1985, 10, 15)
                // Add more properties as needed
            };

            var patient2 = new PatientDto
            {
                Id = patient2Id,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1990, 5, 25)
                // Add more properties as needed
            };
            if (id == patient1.Id) return patient1;
            else if (id == patient2.Id) return patient2;
            else return new PatientDto();
        }
    }
}