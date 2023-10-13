using System.ComponentModel.DataAnnotations;

namespace Flow.Api.Settings;

public class DatabaseSettings
{
    public const string ConfigurationSection = "DatabaseSettings";

    [Required]
    public string ConnectionString { get; set; } = string.Empty;
}
