namespace Prescription.API.Endpoints.Prescription
{
    public class Records
    {
        //Get
        public record GetPrescriptionResponse(PaginatedResult<PrescriptionDto> Prescriptions);

        // Post
        public record CreatePrescriptionRequest(PrescriptionDto Prescription);
        public record CreatePrescriptionResponse(Guid Id);

        // Put
        public record UpdatePrescriptionRequest(PrescriptionDto Prescription);
        public record UpdatePrescriptionResponse(Guid Id);

        //Delete
        public record DeletePrescriptionRequest(PrescriptionDto Prescription);
        public record DeletePrescriptionResponse(Guid Id);
    }
}