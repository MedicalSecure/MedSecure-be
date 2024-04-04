namespace BacPatient.Application.BPModels.Queries.GetDietByPatientIdQuery
{
    public record GetBPByPatientIdQuery(Guid id) : IQuery<GetBPByPatientIdResult>;

    public record GetBPByPatientIdResult(IEnumerable<BPModelDto> bp);

}
