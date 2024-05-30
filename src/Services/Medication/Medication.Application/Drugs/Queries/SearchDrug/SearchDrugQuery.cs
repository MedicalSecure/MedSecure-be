namespace Medication.Application.Drugs.Queries.SearchDrug;


public record SearchDrugQuery(CreteriaDto creteria) : IQuery<SearchDrugResult>;
public record SearchDrugResult(IEnumerable<DrugDto> Drugs);
