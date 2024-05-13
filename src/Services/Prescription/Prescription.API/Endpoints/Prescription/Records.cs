namespace Prescription.API.Endpoints.Prescription
{
    public class Records
    {
        //Get
        public record GetPrescriptionResponse(PaginatedResult<PrescriptionDto> Prescriptions);

        //Get By register Id List

        public record GetPrescriptionsByRegisterIdRequest(List<Guid> registerIds);
        public record GetPrescriptionsByRegisterIdResponse(Dictionary<Guid, List<PrescriptionDto>> PrescriptionsByRegisterId);

        // Post
        public record CreatePrescriptionRequest(PrescriptionCreateDto Prescription);
        public record CreatePrescriptionResponse(Guid Id);

        // Put
        public record UpdatePrescriptionRequest(PrescriptionDto Prescription);
        public record UpdatePrescriptionResponse(Guid Id);

        //Delete
        public record DeletePrescriptionRequest(PrescriptionDto Prescription);
        public record DeletePrescriptionResponse(Guid Id);
    }
}