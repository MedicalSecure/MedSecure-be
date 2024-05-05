namespace Pharmalink.Application.Medications.Queries.MedicationSearch;


public record MedicationSearchQuery(CreteriaDto creteria) : IQuery<MedicationSearchResult>;
public record MedicationSearchResult(IEnumerable<MedicationDto> Medications);
