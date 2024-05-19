using System.Text.Json.Serialization;


    public partial class CreateUserController
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum PermissionType
        {
            Read,
            Write
        }
    }

