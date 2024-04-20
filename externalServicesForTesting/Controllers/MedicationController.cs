using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prescription.Domain.DTOs;

namespace externalServicesForTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationController : ControllerBase
    {
        public static readonly Guid medication1Id = new Guid("55555555-5555-5555-5555-555555555555");
        public static readonly Guid medication2Id = new Guid("66666666-6666-6666-6666-666666666666");

        // GET: api/<MedicationController>
        [HttpGet]
        public IEnumerable<MedicationDto> Get()
        {
            var medication1 = new MedicationDto
            {
                Id = medication1Id,
                Name = "Aspirin",
                DCI = "Acetylsalicylic acid"
                // Add more properties as needed
            };

            var medication2 = new MedicationDto
            {
                Id = medication2Id,
                Name = "Paracetamol",
                DCI = "Acetaminophen"
                // Add more properties as needed
            };

            return new List<MedicationDto> { medication1, medication2 };
        }

        // GET api/<MedicationController>/5
        [HttpGet("{id}")]
        public MedicationDto GetByID(Guid id)
        {
            var medication1 = new MedicationDto
            {
                Id = medication1Id,
                Name = "Aspirin",
                DCI = "Acetylsalicylic acid"
                // Add more properties as needed
            };

            var medication2 = new MedicationDto
            {
                Id = medication2Id,
                Name = "Paracetamol",
                DCI = "Acetaminophen"
                // Add more properties as needed
            };

            if (id == medication1.Id) return medication1;
            else if (id == medication2.Id) return medication2;
            else return new MedicationDto();
        }
    }
}