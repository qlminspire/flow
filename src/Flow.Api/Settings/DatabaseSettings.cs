using System.ComponentModel.DataAnnotations;

namespace Flow.Api.Settings;

public class DatabaseSettings
{
    [Required]
    public string ConnectionString { get; set; } = default!;
}
