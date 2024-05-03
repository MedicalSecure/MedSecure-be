using rescription.Application.DTOs;
using Prescription.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prescription.Application.DTOs
{
    public record PrescriptionDto(
    Guid Id,
    Guid RegisterId,
    Guid DoctorId,
    ICollection<SymptomDto> Symptoms,
    ICollection<DiagnosisDto> Diagnoses,
    ICollection<PosologyDto> Posologies,
    DateTime? CreatedAt = null,
    DateTime? LastModified = null,
    string? CreatedBy = null,
    string? LastModifiedBy = null);
    public record GetPrescriptionsResult(PaginatedResult<PrescriptionDto> Prescriptions);

    public record PosologyDto(Guid Id,
        Guid PrescriptionId,
        MedicationDto Medication,
        DateTime StartDate,
        DateTime? EndDate,
        bool IsPermanent,
        ICollection<CommentsDto> Comments,
        ICollection<DispensesDto> Dispenses);

    public record CommentsDto(Guid Id,
        Guid PosologyId,
        string Label,
        string Content);

    public record DispensesDto(Guid Id,
        Guid PosologyId,
        int Hour,
        int? QuantityBE,
        int? QuantityAE);
}