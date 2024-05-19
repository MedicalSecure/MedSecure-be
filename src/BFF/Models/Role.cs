using System.ComponentModel.DataAnnotations;


    public partial class CreateUserController
    {
        public class Role
        {
            [Required]
            public RoleType Name { get; set; }
        }
    }
