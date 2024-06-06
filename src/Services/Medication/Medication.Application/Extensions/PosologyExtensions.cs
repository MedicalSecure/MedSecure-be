namespace Medication.Application.Extensions;

public static class PosologyExtensions
{
    public static ICollection<PosologyDto> ToPosologiesDto(this IReadOnlyCollection<Domain.Models.Posology> posologies)
    {
        return posologies.Select(s => s.ToPosologyDto()).ToList();
    }

    public static PosologyDto ToPosologyDto(this Posology posology)
    {
        return new PosologyDto(
            Id: posology.Id.Value,
            DrugId: posology.DrugId.Value,
            Drug: posology.Drug?.ToDrugDto(),
            Comments: posology.Comments.ToCommentsDto().ToList(),
            Dispenses: posology.Dispenses.ToDispensesDto().ToList()
        );
    }
}