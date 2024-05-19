using System.ComponentModel.DataAnnotations;


    public partial class CreateUserController
    {
        public class Permission
        {
            [Required]
            public PermissionType Name { get; set; }
        }
    }

