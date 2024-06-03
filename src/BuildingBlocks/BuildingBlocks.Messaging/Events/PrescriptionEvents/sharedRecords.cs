using BuildingBlocks.Messaging.Events.Drugs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.PrescriptionEvents
{
    public record PosologySharedEvent(Guid Id,
    Guid PrescriptionId,
    Guid MedicationId,
    DrugSharedEvent Medication,
    DateTime StartDate,
    DateTime? EndDate,
    bool IsPermanent,
    ICollection<CommentSharedEvent> Comments,
    ICollection<DispenseSharedEvent> Dispenses);

    public record CommentSharedEvent(
    Guid Id,
    Guid PosologyId,
    string Label,
    string Content
    );
    public record DispenseSharedEvent(
    Guid Id,
    Guid PosologyId,
    int Hour,
    DoseSharedEvent? BeforeMeal,
    DoseSharedEvent? AfterMeal
    );

    public record DoseSharedEvent(
        int Quantity,
        bool IsValid,
        bool IsPostValid
    );

    public record SymptomSharedEvent(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
    public record DiagnosesSharedEvent(Guid Id, string Code, string Name, string ShortDescription, string LongDescription);
    public record DietForPrescriptionSharedEvent(Guid Id,
    DateTime StartDate,
    DateTime EndDate,
    List<Guid> DietsId
    );
}