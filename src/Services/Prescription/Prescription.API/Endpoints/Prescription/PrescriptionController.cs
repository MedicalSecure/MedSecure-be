﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prescription.API.Endpoints.Prescription;
using Prescription.Application.Features.Prescription.Commands.CreatePrescription;

using Prescription.Application.Features.Prescription.Commands.UpdatePrescription;
using Prescription.Application.Features.Prescription.Queries.GetPrescription;
using static Prescription.API.Endpoints.Prescription.Records;

namespace Prescription.API.Endpoints.Prescription
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private readonly ISender _sender;

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
            var command = request.Adapt<CreatePrescriptionCommand>();
            var result = await _sender.Send(command);
            var response = result.Adapt<CreatePrescriptionResponse>();
            return CreatedAtRoute(
                routeName: null,
                routeValues: new { id = response.Id },
                value: response
            );
        }

        /*// PUT api/<PrescriptionsController>
        [HttpPut()]
        public async Task<IActionResult> UpdatePrescription([FromBody] UpdatePrescriptionRequest request)
        {
            var command = request.Adapt<UpdatePrescriptionCommand>();
            var result = await _sender.Send(command);
            var response = result.Adapt<UpdatePrescriptionResponse>();
            return Ok(response);
        }*/
    }
}