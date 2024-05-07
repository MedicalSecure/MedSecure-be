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

    // Fields
    private readonly List<Test> _tests = new();
    private readonly List<RiskFactor> _familyMedicalHistory = new();
    private readonly List<RiskFactor> _personalMedicalHistory = new();
    private readonly List<RiskFactor> _disease = new();
    private readonly List<RiskFactor> _allergy = new();
    private readonly List<History> _history = new();

    // Constructor
    private Register() { } // Ensure creation through factory method

    // Factory method
    public static Register Create(RegisterId id, Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));
        
        var register = new Register
        {
            Id = id,
            Patient = patient
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

    // Method to update patient and test
    public void Update(Patient patient)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        Patient = patient;

        AddDomainEvent(new RegisterUpdatedEvent(this));
    }
}
