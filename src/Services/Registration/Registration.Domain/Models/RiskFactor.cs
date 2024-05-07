namespace Registration.Domain.Models;

public class RiskFactor : Aggregate<RiskFactorId>
{
    // Properties
    public string Key { get; private set; } = default!;
    public string Value { get; private set; } = default!;
    public string Code { get; private set; } = default!;
    public string Description { get; private set; } = default!;
    public bool IsSelected { get; private set; } = false;
    public string Type { get; private set; } = default!;
    public string Icon { get; private set; } = default!;
    public IReadOnlyList<SubRiskFactor> SubRiskFactors => _subRiskFactors.AsReadOnly();

    // Foreign key for Disease relationship
    public RegisterId RegisterIdForDisease { get; private set; } = default!;

    // Foreign key for Allergy relationship
    public RegisterId RegisterIdForAllergy { get; private set; } = default!;

    // Foreign key for FamilyMedicalHistory relationship
    public RegisterId RegisterIdForFamilyMedicalHistory { get; private set; } = default!;

    // Foreign key for PersonalMedicalHistory relationship
    public RegisterId RegisterIdForPersonalMedicalHistory { get; private set; } = default!;

    // Fields
    private readonly List<SubRiskFactor> _subRiskFactors = new();

    // Constructor (private to enforce creation through factory method)
    private RiskFactor() { }

    // Factory method
    public static RiskFactor Create(
        RiskFactorId id,
        string key,
        string value,
        string code,
        string description,
        bool isSelected,
        string type,
        string icon)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));

        var riskFactor = new RiskFactor
        {
            Id = id,
            Key = key,
            Value = value ?? string.Empty,
            Code = code ?? string.Empty,
            Description = description ?? string.Empty,
            IsSelected = isSelected,
            Type = type ?? string.Empty,
            Icon = icon ?? string.Empty
        };

        riskFactor.AddDomainEvent(new RiskFactorCreatedEvent(riskFactor));
        return riskFactor;
    }

    // Method to update the risk factor
    public void Update(
        string key,
        string value,
        string code,
        string description,
        bool isSelected,
        string type,
        string icon)
    {
        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));

        Key = key;
        Value = value ?? string.Empty;
        Code = code ?? string.Empty;
        Description = description ?? string.Empty;
        IsSelected = isSelected;
        Type = type ?? string.Empty;
        Icon = icon ?? string.Empty;

        AddDomainEvent(new RiskFactorUpdatedEvent(this));
    }

    // Method to add sub risk factors
    public void AddSubRiskFactor(SubRiskFactor subRiskFactor)
    {
        if (subRiskFactor == null)
            throw new ArgumentNullException(nameof(subRiskFactor));

        _subRiskFactors.Add(subRiskFactor);
    }
}
