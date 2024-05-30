using BuildingBlocks.Pagination;
using Prescription.Application.Features.Symptom.Commands.CreateSymptom;
using Prescription.Application.Features.Symptom.Commands.DeleteSymptom;
using Prescription.Application.Features.Symptom.Commands.UpdateSymptom;
using Prescription.Application.Features.Symptom.Queries.GetSymptom;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Prescription.API.Endpoints.Symptoms
{
    [Route("api/v1/Prescription/[controller]")]
    [ApiController]
    public class SymptomsController : ControllerBase
    {
        private readonly ISender _sender;

        public SymptomsController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/<SymptomsController>
        [HttpGet]
        public async Task<IActionResult> GetSymptoms([FromQuery] PaginationRequest paginationRequest)
        {
            var query = new GetSymptomQuery(paginationRequest);
            var result = await _sender.Send(query);
            var response = result.Adapt<GetSymptomResponse>();

            return Ok(response);
        }

        // GET api/<SymptomsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSymptom(Guid id)
        {
            var command = new GetSymptomByIdQuery(id);
            var result = await _sender.Send(command);
            GetSymptomResponse response = result.Adapt<GetSymptomResponse>();

            // If the symptom is not found, return a 404 Not Found response
            if (response == null || response.Symptom.Data.Count() == 0)
            {
                return NotFound();
            }

            // Return an appropriate HTTP response with the adapted response object
            return Ok(response);
        }

        // POST api/<SymptomsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSymptomRequest request)
        {
            var command = request.Adapt<CreateSymptomCommand>();
            var result = await _sender.Send(command);
            var response = result.Adapt<CreateSymptomResponse>();
            return CreatedAtRoute(
                routeName: null,
                routeValues: new { id = response.Id },
                value: response
            );
        }

        // PUT api/<SymptomsController>
        [HttpPut()]
        public async Task<IActionResult> UpdateSymptom([FromBody] UpdateSymptomRequest request)
        {
            var command = request.Adapt<UpdateSymptomCommand>();
            var result = await _sender.Send(command);
            var response = result.Adapt<UpdateSymptomResponse>();
            return Ok(response);
        }

        // DELETE api/<SymptomsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSymptom(Guid id)
        {
            var command = new DeleteSymptomCommand(new SymptomDTO(id, "", "", "", ""));
            var result = await _sender.Send(command);
            var response = result.Adapt<DeleteSymptomResponse>();

            // Return appropriate HTTP response
            return Ok(response);
        }

        [HttpPost("Predict")]
        public async Task<IActionResult> Predict([FromBody] PredictFromSymptomsRequest request)
        {
            var query = new PredictFromSymptomsQuery(request.Symptoms);
            var result = await _sender.Send(query);
            var response = result.Adapt<PredictFromSymptomsResponse>();

            //Return appropriate HTTP response
            return Ok(response);
        }
    }
}