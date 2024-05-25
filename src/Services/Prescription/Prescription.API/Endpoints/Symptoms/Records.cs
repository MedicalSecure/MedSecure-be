namespace Prescription.API.Endpoints.Symptoms
{
    //Get
    public record GetSymptomResponse(PaginatedResult<SymptomDTO> Symptom);

    // Post
    public record CreateSymptomRequest(SymptomDTO Symptom);
    public record CreateSymptomResponse(string Id);

    // Put
    public record UpdateSymptomRequest(SymptomDTO Symptom);
    public record UpdateSymptomResponse(Guid Id);

    //Delete
    public record DeleteSymptomRequest(SymptomDTO Symptom);
    public record DeleteSymptomResponse(Guid Id);

    // Predict
    public record PredictFromSymptomsRequest(List<SymptomDTO> Symptoms);
    public record PredictFromSymptomsResponse(DiagnosisDTO PredictedDiagnosis);
}