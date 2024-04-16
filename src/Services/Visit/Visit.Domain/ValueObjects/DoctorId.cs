

using System.Text.Json.Serialization;

namespace Visit.Domain.ValueObjects
{
  public record DoctorId
    {
        public Guid Value { get; }

        // [JsonConstructor] errur :désérialisation des objets de valeur 
        //Le problème réside dans le fait que ces objets de valeur (PatientId et DoctorId) n'ont pas de constructeur sans paramètre.
        //Lorsque ASP.NET Core essaie de désérialiser la demande, il ne peut pas instancier ces objets de valeur car il ne trouve pas de constructeur sans paramètre.
        //Pour résoudre ce problème, vous pouvez ajouter un constructeur sans paramètre à vos objets
        //de valeur(PatientId et DoctorId) ou ajouter un constructeur annoté avec JsonConstructorAttribute.
        private DoctorId(Guid value) => Value = value;

        public static DoctorId Of (Guid value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (value == Guid.Empty)
            {
                throw new DomainException ("DoctorId cannot be empty!");
            }
            return new DoctorId(value);
        }
    }
}
