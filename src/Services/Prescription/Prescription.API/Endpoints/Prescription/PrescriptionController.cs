namespace Prescription.API.Endpoints.Prescription
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ISender _sender;
        //private readonly ILogger _logger;

        public PrescriptionController(ISender sender)
        {
            _sender = sender;
        }

        // GET: api/<PrescriptionsController>
        [HttpGet]
        public async Task<IActionResult> GetPrescriptions([FromQuery] PaginationRequest paginationRequest)
        {
            var query = new GetPrescriptionsQuery(paginationRequest);
            var result = await _sender.Send(query);
            var response = result.Adapt<GetPrescriptionResponse>();

            return Ok(response);
        }

        // GET api/<PrescriptionsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(Guid id)
        {
            var command = new GetPrescriptionByIdQuery(id);
            var result = await _sender.Send(command);
            GetPrescriptionResponse response = result.Adapt<GetPrescriptionResponse>();

            // If the Prescription is not found, return a 404 Not Found response
            if (response == null || response.Prescriptions.Data.Count() == 0)
            {
                return NotFound();
            }

            // Return an appropriate HTTP response with the adapted response object
            return Ok(response);
        }

        // POST api/<PrescriptionsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePrescriptionRequest request)
        {
            try
            {
                var command = request.Adapt<CreatePrescriptionCommand>();
                var result = await _sender.Send(command);
                var response = result.Adapt<CreatePrescriptionResponse>();

                return CreatedAtRoute(
                    routeName: "",
                    value: response
                );
            }
            catch (CreatePrescriptionException ex)
            {
                // Log the exception for debugging purposes
                // _logger.LogError(ex, "An error occurred while creating a prescription.");

                // Return an appropriate error response to the client
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Failed to create prescription",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                //_logger.LogError(ex, "An unexpected error occurred while creating a prescription.");

                // Return a generic error response to the client
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "An unexpected error occurred",
                    Message = $"An unexpected error occurred while processing your request. : {ex.Message}"
                });
            }
        }

        // PUT api/<PrescriptionsController>
        [HttpPut()]
        public async Task<IActionResult> UpdatePrescription([FromBody] UpdatePrescriptionRequest request)
        {
            try
            {
                var command = request.Adapt<UpdatePrescriptionCommand>();
                var result = await _sender.Send(command);
                var response = result.Adapt<UpdatePrescriptionResponse>();
                return Ok(response);
            }
            catch (UpdatePrescriptionException ex)
            {
                // Log the exception for debugging purposes
                // _logger.LogError(ex, "An error occurred while creating a prescription.");

                // Return an appropriate error response to the client
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "Failed to update prescription",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                //_logger.LogError(ex, "An unexpected error occurred while creating a prescription.");

                // Return a generic error response to the client
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Error = "An unexpected error occurred",
                    Message = $"An unexpected error occurred while processing your request. : {ex.Message}"
                });
            }
        }

        [HttpGet("Register/{id}")]
        public async Task<IActionResult> GetPrescriptionsByRegisterId(Guid id)
        {
            var command = new GetPrescriptionByRegisterIdQuery(id);
            var result = await _sender.Send(command);
            GetPrescriptionResponse response = result.Adapt<GetPrescriptionResponse>();

            // If the Prescription is not found, return a 404 Not Found response
            if (response == null || response.Prescriptions.Data.Count() == 0)
            {
                return NotFound();
            }

            // Return an appropriate HTTP response with the adapted response object
            return Ok(response);
        }

        [HttpGet("Register")]
        public async Task<IActionResult> GetPrescriptionsByRegisterIdList([FromQuery] GetPrescriptionsByRegisterIdRequest request)
        {
            var query = new GetPrescriptionsByRegisterIdsQuery(request.registerIds);
            //var query = request.Adapt<GetPrescriptionsByRegisterIdsQuery>();

            var result = await _sender.Send(query);
            var response = result.Adapt<GetPrescriptionsByRegisterIdResponse>();

            // Return an appropriate HTTP response with the adapted response object
            return Ok(response);
        }
    }
}