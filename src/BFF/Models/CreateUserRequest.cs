using System.ComponentModel.DataAnnotations;


    public partial class CreateUserController
    {
        public class CreateUserRequest
        {
            [Required]
            public string DisplayName { get; set; } = default!;
            
            [Required]
            public string GivenName { get; set; } = default!;
            
            [Required]
            public string MailNickname { get; set; } = default!;

            public string Surname { get; set; } = default!;
            
            [Required]
            public string Username { get; set; } = default!;
            
            [Required]
            public string Domain { get; set; } = default!;
            
            [Required]
            public string Password { get; set; } = default!;
            
            [Required]
            public List<Role> Roles { get; set; } = new List<Role>();

            [Required]
            public List<Permission> Permissions { get; set; } = new List<Permission>();
        }
    }

