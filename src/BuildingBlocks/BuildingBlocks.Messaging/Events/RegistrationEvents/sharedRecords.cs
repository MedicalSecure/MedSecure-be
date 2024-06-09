using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Messaging.Events.RegistrationSharedEvents
{
    public record RegisterSharedEvent(Guid Id, PatientSharedEvent Patient, List<RiskFactorSharedEvent>? FamilyMedicalHistory, List<RiskFactorSharedEvent>? PersonalMedicalHistory, List<RiskFactorSharedEvent>? Diseases, List<RiskFactorSharedEvent>? Allergies, List<HistorySharedEvent>? History, List<TestSharedEvent>? Test, int? Status, DateTime? CreatedAt);

    public record RiskFactorSharedEvent(Guid Id, List<RiskFactorSharedEvent>? SubRiskFactor, Guid? RiskFactorParentId, string Key, string Value, string? Code, string? Description, bool? IsSelected, string? Type, string? Icon);

    public record TestSharedEvent(Guid Id, string Code, string Description, int Language, int TestType, Guid RegisterId);

    public record PatientSharedEvent(Guid Id, string FirstName, string LastName, DateTime DateOfBirth, string Identity, int Gender, int? CNAM, string? Assurance, int? Height, int? Weight, bool? AddressIsRegistrations, bool? SaveForNextTime, string? Email, string? Address1, string? Address2, int? Country, string? State, int? ZipCode, int? ActivityStatus, int? FamilyStatus, int? Children);

    public record HistorySharedEvent(Guid Id, DateTime? Date, int Status, Guid RegisterId);
}