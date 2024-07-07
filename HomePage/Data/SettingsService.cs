using System.Text.Json;

namespace HomePage.Data;

public class SettingsService
{
    private const string FilePath = "wwwroot/images/settings.json";

    private JsonSerializerOptions jsonSerializerOptions = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

    public Task<Settings> GetAsync()
    {
        try
        {
            string json = System.IO.File.ReadAllText(FilePath);
            var settings = JsonSerializer.Deserialize<Settings>(json, jsonSerializerOptions);
            if (settings != null)
                return Task.FromResult(settings);
        }
        catch (Exception ex)
        {
            // Log the exception (using your preferred logging approach)
            Console.WriteLine(ex.Message);
        }
        return Task.FromResult(new Settings());
    }

    public async Task SaveAsync(Settings settings)
    {
        try
        {
            string json = JsonSerializer.Serialize(settings, jsonSerializerOptions);
            await System.IO.File.WriteAllTextAsync(FilePath, json);
        }
        catch (Exception ex)
        {
            // Log the exception (using your preferred logging approach)
            Console.WriteLine(ex.Message);
        }
    }
}
