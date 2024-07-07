namespace HomePage.Data;

public class Settings
{
    public int Columns { get; set; } = 6;
    public int Margin { get; set; } = 2;
    public List<Category> Categories { get; set; } = new List<Category>();
}
