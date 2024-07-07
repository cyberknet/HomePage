using System.Text.Json.Serialization;

namespace HomePage.Data;

public class Category
{
    private static string[] _reservedIds = new string[] { "settings", string.Empty };
    public string Id => GenerateId(Name);
    public string Name { get; set; } = string.Empty;
    public List<Button> Buttons { get; set; } = new ();

    public static string GenerateId(string name) => name.ToLower().Replace(" ", "").Trim();
    public static bool IsReservedId(string name) => _reservedIds.Contains(GenerateId(name));

    [JsonIgnore]
    public bool ExpandedInSettings { get; set; } = false;
}
