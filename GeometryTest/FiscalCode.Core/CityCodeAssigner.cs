namespace FiscalCode.Core;

public class CityCodeAssigner
{
    private readonly Dictionary<string, string> _dictionary;

    public CityCodeAssigner()
    {
        _dictionary =
            new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase)
            {
                { "Firenze", "D612" },
                { "Torino", "L219" },
                { "Roma", "H501" },
                { "Palermo", "H501" },
                { "Austria", "Z102" },
                { "Belgio", "Z103" }
            };
    }

    public string GetCode(string placeOfBirth)
    {
        return _dictionary[placeOfBirth];
    }

}