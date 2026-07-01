namespace PlayersGuide.Notes.Helpers.ThisKeyword;

public class City
{
    public string Name { get; set; }
    public int ZipCode { get; set; }

    public City() : this("Unknown", 0)
    {

    }

    public City(string name, int zipCode)
    {
        Name = name;
        ZipCode = zipCode;
    }
}
