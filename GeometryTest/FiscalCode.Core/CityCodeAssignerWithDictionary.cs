using FiscalCode.Core.Exceptions;

namespace FiscalCode.Core;

public class CityCodeAssignerWithDictionary : ICityCodeAssigner
{
    private static readonly Dictionary<string, string> dictionary;

    static CityCodeAssignerWithDictionary()
    {
        dictionary =
            new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase)
            {
                { "Firenze", "D612" },
                { "Torino", "L219" },
                { "Roma", "H501" },
                { "Palermo", "G273" },
                { "Austria", "Z102" },
                { "Belgio", "Z103" }
            };
    }

    public string GetCode(string? placeOfBirth)
    {
        if (placeOfBirth is null)
        {
            throw new PlaceOfBirthDoesNotExistException("null");
        }

        string key = placeOfBirth.Trim();

        //if (!_dictionary.ContainsKey(key))
        //{
        //    throw new PlaceOfBirthDoesNotExistException(key);
        //}

        //return _dictionary[key];

        if (!dictionary.TryGetValue(key, out string? code))
        {
            throw new PlaceOfBirthDoesNotExistException(key);
        }
        return code;
    }
}