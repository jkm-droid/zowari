namespace Domain.Configurations;

public class IdentityConfiguration
{
    public const string SectionName = "IdentityConfiguration";
    public string SecretKey { get; set; }
    public string ValidIssuer { get; set; }
    public string ValidAudience { get; set; }
    public short Expires { get; set; }
}