
namespace Registration.Domain.Models
{
    public class Test
    {
        //enum type : clique test ou labTest
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Language language { get; set; } = default!;
        public TestType type { get; set; } = default!;
    }
}
