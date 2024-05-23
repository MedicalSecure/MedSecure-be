using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Domain.Models;

public class Register : Aggregate<RegisterId>
{
    // Properties
    public Patient Patient { get; private set; } = default!;

    public PatientId PatientId { get; private set; } = default!;

    public IReadOnlyList<Test> Tests => _tests.AsReadOnly();
    public IReadOnlyList<RiskFactor> FamilyMedicalHistory => _familyMedicalHistory.AsReadOnly();
    public IReadOnlyList<RiskFactor> PersonalMedicalHistory => _personalMedicalHistory.AsReadOnly();
    public IReadOnlyList<RiskFactor> Disease => _disease.AsReadOnly();
    public IReadOnlyList<RiskFactor> Allergy => _allergy.AsReadOnly();
    public IReadOnlyList<History> History => _history.AsReadOnly();

    public RegisterStatus Status { get; private set; } = RegisterStatus.Active;

    // Fields
    private readonly List<Test> _tests = new List<Test>();

    private readonly List<RiskFactor> _familyMedicalHistory = new List<RiskFactor>();
    private readonly List<RiskFactor> _personalMedicalHistory = new List<RiskFactor>();
    private readonly List<RiskFactor> _disease = new List<RiskFactor>();
    private readonly List<RiskFactor> _allergy = new List<RiskFactor>();
    private readonly List<History> _history = new List<History>();

    // Constructor
    public Register()
    { }

    // Factory method
    public static Register Create(RegisterId id, Patient patient, RegisterStatus status = RegisterStatus.Active)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        var register = new Register
        {
            Id = id,
            Patient = patient,
            Status = status,
        };
        register.AddDomainEvent(new RegisterCreatedEvent(register));
        return register;
    }

    // Methods to add medical history, disease, allergy
    public void AddFamilyMedicalHistory(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        _familyMedicalHistory.Add(riskFactor);
    }

    public void AddPersonalMedicalHistory(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        _personalMedicalHistory.Add(riskFactor);
    }

    public void AddDisease(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        _disease.Add(riskFactor);
    }

    public void AddAllergy(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        _allergy.Add(riskFactor);
    }

    public void AddTests(Test test)
    {
        if (test == null)
            throw new ArgumentNullException(nameof(test));

        _tests.Add(test);
    }

    public void AddHistory(History history)
    {
        if (history == null)
            throw new ArgumentNullException(nameof(history));

        _history.Add(history);
    }

    // Method to update patient and test
    public void Update(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        Patient = patient;

        AddDomainEvent(new RegisterUpdatedEvent(this));
    }

    public void Archive()
    {
        this.Status = RegisterStatus.Archived;
        History outHistory = Domain.Models.History.Create(new DateTime(), HistoryStatus.Out, this.Id);
        _history.Add(outHistory);
        AddDomainEvent(new RegisterUpdatedEvent(this));
    }
}