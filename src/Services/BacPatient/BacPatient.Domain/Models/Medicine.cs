

namespace BacPatient.Domain.Models
{
    public class Medicine : Aggregate<MedicineId>
    {
        public string Name { get; private set; } = default!;
        public string Forme { get; private set; } = default!;
        public string Dose { get; private set; } = default!;
        public string Unit { get; private set; } = default!;
        public Root Root { get; private set; } = default!;
        public DateTime DateExp { get; private set; } = default!;
        public int Stock { get; private set; } = default!;
        public List<string> Note { get; private set; } = default!;

        private readonly List<Posology> _posologies = new();
        public IReadOnlyList<Posology> Posologies => _posologies.AsReadOnly();
        public static Medicine Create(
           MedicineId Id,
           string Name,
           string Forme,
           Root Root , 
           string Dose,
           string Unit,
           DateTime DateExp,
           int Stock,
           List<string> Note
       )
        {
            var medicine = new Medicine()
            {
                Id = Id,
                Name = Name,
                Forme = Forme,
                Root = Root, 
                Dose = Dose,
                Unit = Unit,
                DateExp = DateExp,
                Stock = Stock,
                Note = Note
            };

            return medicine;
        }
        public void AddPosology(Posology pos)
        {
            if (pos == null)
                throw new ArgumentNullException(nameof(pos));

            _posologies.Add(pos);
        }
        public void AddNote(string note)
        {
            if (note == null)
                throw new ArgumentNullException();

            Note.Add(note);
        }
    }
}
