using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prescription.Domain.DTOs;

namespace externalServicesForTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        public static readonly Guid doctor1Id = new Guid("33333333-3333-3333-3333-333333333333");
        public static readonly Guid doctor2Id = new Guid("44444444-4444-4444-4444-444444444444");

        // GET: api/<DoctorController>
        [HttpGet]
        public IEnumerable<DoctorDto> Get()
        {
            var doctor1 = new DoctorDto
            {
                Id = doctor1Id,
                FirstName = "Michael",
                LastName = "Smith",
                Specialty = "Cardiologist"
                // Add more properties as needed
            };

            var doctor2 = new DoctorDto
            {
                Id = doctor2Id,
                FirstName = "Emily",
                LastName = "Johnson",
                Specialty = "Neurologist"
                // Add more properties as needed
            };

            return new List<DoctorDto> { doctor1, doctor2 };
        }

        // GET api/<DoctorController>/5
        [HttpGet("{id}")]
        public DoctorDto GetByID(Guid id)
        {
            var doctor1 = new DoctorDto
            {
                Id = doctor1Id,
                FirstName = "Michael",
                LastName = "Smith",
                Specialty = "Cardiologist"
                // Add more properties as needed
            };

            var doctor2 = new DoctorDto
            {
                Id = doctor2Id,
                FirstName = "Emily",
                LastName = "Johnson",
                Specialty = "Neurologist"
                // Add more properties as needed
            };

            if (id == doctor1.Id) return doctor1;
            else if (id == doctor2.Id) return doctor2;
            else return new DoctorDto();
        }
    }
}