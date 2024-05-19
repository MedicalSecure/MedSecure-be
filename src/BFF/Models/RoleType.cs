using System.Text.Json.Serialization;


    public partial class CreateUserController
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum RoleType
        {
            Doctor,
            Nurse,
            Pharmacist,
            Supervisor,
            Nutritionist,
            Hygienist,
        }
    }

