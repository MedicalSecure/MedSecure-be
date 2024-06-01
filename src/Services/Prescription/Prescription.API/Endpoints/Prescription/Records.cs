namespace Prescription.API.Endpoints.Prescription
{
    public class Records
    {
        //Get
        public record GetPrescriptionResponse(PaginatedResult<PrescriptionDTO> Prescriptions);

        //Get By register Id List

        public record GetPrescriptionsByRegisterIdRequest(List<Guid> registerIds);
        public record GetPrescriptionsByRegisterIdResponse(Dictionary<Guid, List<PrescriptionDTO>> PrescriptionsByRegisterId);

        // Post
        public record CreatePrescriptionRequest(PrescriptionCreateUpdateDto Prescription);
        public record CreatePrescriptionResponse(Guid Id);

        // Put
        public record UpdatePrescriptionRequest(PrescriptionCreateUpdateDto Prescription);
        public record UpdatePrescriptionResponse(Guid Id);

        // Put Status
        public record UpdatePrescriptionStatusRequest(PrescriptionDTO Prescription);
        public record UpdatePrescriptionStatusResponse(Guid Id);

        //Delete
        public record DeletePrescriptionRequest(PrescriptionDTO Prescription);
        public record DeletePrescriptionResponse(Guid Id);
    }
}