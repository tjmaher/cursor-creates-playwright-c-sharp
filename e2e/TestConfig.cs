using System.Reflection;
using System.Text.Json;

namespace E2ETests.e2e;

/// <summary>
/// Strongly-typed representation of test configuration loaded from JSON.
/// </summary>
public class TestConfig
{
    public string BaseUrl { get; init; } = "";
    public CredentialsSection Credentials { get; init; } = new();
    public LoginPageSection LoginPage { get; init; } = new();
    public SecureAreaSection SecureArea { get; init; } = new();

    public class CredentialsSection
    {
        public string ValidUsername { get; init; } = "";
        public string ValidPassword { get; init; } = "";
    }

    public class LoginPageSection
    {
        public string Heading { get; init; } = "";
        public string BodyText { get; init; } = "";
        public string InvalidUsernameMessagePrefix { get; init; } = "";
    }

    public class SecureAreaSection
    {
        public string Heading { get; init; } = "";
        public string BodyText { get; init; } = "";
        public string SuccessfulLoginMessagePrefix { get; init; } = "";
    }

    private static readonly Lazy<TestConfig> _current = new(Load, isThreadSafe: true);

    /// <summary>
    /// Singleton access to the loaded configuration.
    /// </summary>
    public static TestConfig Current => _current.Value;

    private static TestConfig Load()
    {
        var assemblyLocation = Assembly.GetExecutingAssembly().Location;
        var baseDir = Path.GetDirectoryName(assemblyLocation)
                     ?? AppContext.BaseDirectory;

        var configPath = Path.Combine(baseDir, "e2e", "testdata.json");

        if (!File.Exists(configPath))
        {
            throw new FileNotFoundException($"Test data configuration file not found at '{configPath}'.");
        }

        var json = File.ReadAllText(configPath);
        var config = JsonSerializer.Deserialize<TestConfig>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (config is null)
        {
            throw new InvalidOperationException("Failed to deserialize test configuration.");
        }

        return config;
    }
}

