using System.ComponentModel.DataAnnotations;


    public partial class CreateUserController
    {
        public class InviteUserRequest
        {
            [Required]
            public string EmailAddress { get; set; } = default!;

            [Required]
            public string DisplayName { get; set; } = default!;

            [Required]
            public List<Role> Roles { get; set; } = default!;

            [Required]
            public List<Permission> Permissions { get; set; } = default!;
        }
    }

