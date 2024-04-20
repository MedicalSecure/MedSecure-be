namespace Prescription.API.Endpoints.Symptoms
{
    //Get
    public record GetSymptomResponse(PaginatedResult<SymptomDto> Symptom);

    // Post
    public record CreateSymptomRequest(SymptomDto Symptom);
    public record CreateSymptomResponse(string Id);

    // Put
    public record UpdateSymptomRequest(SymptomDto Symptom);
    public record UpdateSymptomResponse(Guid Id);

    //Delete
    public record DeleteSymptomRequest(SymptomDto Symptom);
    public record DeleteSymptomResponse(Guid Id);
}