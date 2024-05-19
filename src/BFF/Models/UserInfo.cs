
public class UserInfo
{
    public static readonly UserInfo Anonymous = new();

    public bool IsAuthenticated { get; set; }

    public string NameClaimType { get; set; } = string.Empty;

    public string RoleClaimType { get; set; } = string.Empty;

    public ICollection<ClaimValue> Claims { get; set; } = new List<ClaimValue>();

    public List<string> Roles { get; set; } = new List<string>();

    public List<string> Permissions { get; set; } = new List<string>();
}
