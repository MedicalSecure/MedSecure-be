
namespace BacPatient.Domain.Models
{
    public class Posology : Aggregate<PoslogyId>
    {
        public DateTime startDate { get; private set; } = default!;
        public DateTime endDate { get; private set; } = default!;

        public int quantityBE { get; private set; } = default!;
        public int quantityAE { get; private set; } = default!;

        public bool isPermanent { get; private set; } = default!;

        public List<string> hours { get; private set; } = default!;

    }
}
