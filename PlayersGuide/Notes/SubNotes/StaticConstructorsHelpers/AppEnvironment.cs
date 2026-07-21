namespace PlayersGuide.Notes.SubNotes.StaticConstructorsHelpers;

public static class AppEnvironment
{
    public static readonly string ConfigPath;
    public static readonly bool IsDevelopment;
    public static readonly string MachineName;

    static AppEnvironment()
    {
        // Logic — can't be done with a simple "= value" initializer:
        MachineName = Environment.MachineName;

        string? env = Environment.GetEnvironmentVariable("APP_ENV");
        IsDevelopment = env is null || env == "dev";

        ConfigPath = IsDevelopment
            ? Path.Combine(AppContext.BaseDirectory, "appsettings.dev.json")
            : Path.Combine(AppContext.BaseDirectory, "appsettings.json");
    }
}
