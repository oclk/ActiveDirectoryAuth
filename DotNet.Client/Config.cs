using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace DotNet.Client;

public class Config
{
    public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";
    public string? TenantId { get; set; }
    public string? ClientId { get; set; }
    public string Authority
    {
        get
        {
            return string.Format(CultureInfo.InvariantCulture,
                                 Instance, TenantId);
        }
    }
    public string? ClientSecret { get; set; }
    public string? BaseAddress { get; set; }
    public string? ResourceID { get; set; }

    public static Config ReadFromJsonFile(string path)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(path);
        IConfiguration configuration = builder.Build();
#pragma warning disable CS8603 // Possible null reference return.
        return configuration.Get<Config>();
#pragma warning restore CS8603 // Possible null reference return.
    }
}
