

namespace BacPatient.Domain.Models
{
    public class Medicine : Aggregate<MedicineId>
    {
        public string name { get; private set; } = default!;
        public string forme { get; private set; } = default!;
        public string dose { get; private set; } = default!;
        public string unit { get; private set; } = default!;
        public DateTime dateExp { get; private set; } = default!;
        public int stock { get; private set; } = default!;
        public List<string> note { get; private set; } = default!;

        private readonly List<Posology> _posologies = new();
        public IReadOnlyList<Posology> Posologies => _posologies.AsReadOnly();
    }
}
