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
    public static Register Create(
        RegisterId id,
        Patient patient,
        IEnumerable<RiskFactor> familyHistory = null,
        IEnumerable<RiskFactor> personalHistory = null,
        IEnumerable<RiskFactor> diseases = null,
        IEnumerable<RiskFactor> allergies = null,
        IEnumerable<History> historyList = null,
        IEnumerable<Test> testList = null,
        RegisterStatus status = RegisterStatus.Active)
    {
        if (patient == null)
            throw new ArgumentNullException(nameof(patient));

        var register = new Register
        {
            Id = id,
            Patient = patient,
            Status = status
        };

        register.AddFamilyMedicalHistory(familyHistory ?? Enumerable.Empty<RiskFactor>());
        register.AddPersonalMedicalHistory(personalHistory ?? Enumerable.Empty<RiskFactor>());
        register.AddDisease(diseases ?? Enumerable.Empty<RiskFactor>());
        register.AddAllergy(allergies ?? Enumerable.Empty<RiskFactor>());
        register.AddHistory(historyList ?? Enumerable.Empty<History>());
        register.AddTests(testList ?? Enumerable.Empty<Test>());

        register.AddDomainEvent(new RegisterCreatedEvent(register));

        return register;
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
        History outHistory = Domain.Models.History.Create(this.Id, HistoryStatus.Out, new DateTime());
        _history.Add(outHistory);
        AddDomainEvent(new RegisterUpdatedEvent(this));
    }

    // Methods to add medical history, disease, allergy
    public void AddFamilyMedicalHistory(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        if (_familyMedicalHistory.Any(r => r.Id == riskFactor.Id))
            throw new ArgumentException($"A risk factor with ID '{riskFactor.Id}' already exists in the family medical history.", nameof(riskFactor));

        _familyMedicalHistory.Add(riskFactor);
    }

    public void AddPersonalMedicalHistory(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        if (_personalMedicalHistory.Any(r => r.Id == riskFactor.Id))
            throw new ArgumentException($"A risk factor with ID '{riskFactor.Id}' already exists in the personal medical history.", nameof(riskFactor));

        _personalMedicalHistory.Add(riskFactor);
    }

    public void AddDisease(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        if (_disease.Any(r => r.Id == riskFactor.Id))
            throw new ArgumentException($"A risk factor with ID '{riskFactor.Id}' already exists in the disease list.", nameof(riskFactor));

        _disease.Add(riskFactor);
    }

    public void AddAllergy(RiskFactor riskFactor)
    {
        if (riskFactor == null)
            throw new ArgumentNullException(nameof(riskFactor));

        if (_allergy.Any(r => r.Id == riskFactor.Id))
            throw new ArgumentException($"A risk factor with ID '{riskFactor.Id}' already exists in the allergy list.", nameof(riskFactor));

        _allergy.Add(riskFactor);
    }

    public void AddTests(Test test)
    {
        if (test == null)
            throw new ArgumentNullException(nameof(test));

        if (_tests.Any(t => t.Id == test.Id))
            throw new ArgumentException($"A test with ID '{test.Id}' already exists in the tests list.", nameof(test));

        _tests.Add(test);
    }

    public void AddHistory(History history)
    {
        if (history == null)
            throw new ArgumentNullException(nameof(history));

        if (_history.Any(h => h.Id == history.Id))
            throw new ArgumentException($"A history with ID '{history.Id}' already exists in the history list.", nameof(history));

        _history.Add(history);
    }

    public void AddFamilyMedicalHistory(IEnumerable<RiskFactor> riskFactors)
    {
        if (riskFactors == null)
            throw new ArgumentNullException(nameof(riskFactors));

        foreach (var riskFactor in riskFactors)
        {
            AddFamilyMedicalHistory(riskFactor);
        }
    }

    public void AddPersonalMedicalHistory(IEnumerable<RiskFactor> riskFactors)
    {
        if (riskFactors == null)
            throw new ArgumentNullException(nameof(riskFactors));

        foreach (var riskFactor in riskFactors)
        {
            AddPersonalMedicalHistory(riskFactor);
        }
    }

    public void AddDisease(IEnumerable<RiskFactor> riskFactors)
    {
        if (riskFactors == null)
            throw new ArgumentNullException(nameof(riskFactors));

        foreach (var riskFactor in riskFactors)
        {
            AddDisease(riskFactor);
        }
    }

    public void AddAllergy(IEnumerable<RiskFactor> riskFactors)
    {
        if (riskFactors == null)
            throw new ArgumentNullException(nameof(riskFactors));

        foreach (var riskFactor in riskFactors)
        {
            AddAllergy(riskFactor);
        }
    }

    public void AddTests(IEnumerable<Test> tests)
    {
        if (tests == null)
            throw new ArgumentNullException(nameof(tests));

        foreach (var test in tests)
        {
            AddTests(test);
        }
    }

    public void AddHistory(IEnumerable<History> histories)
    {
        if (histories == null)
            throw new ArgumentNullException(nameof(histories));

        foreach (var history in histories)
        {
            AddHistory(history);
        }
    }

}