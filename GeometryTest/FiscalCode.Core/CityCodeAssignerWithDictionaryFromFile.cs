using FiscalCode.Core.Exceptions;

namespace FiscalCode.Core;

public class CityCodeAssignerWithDictionaryFromFile : ICityCodeAssigner
{
    private readonly Dictionary<string, string> _dictionary;

    public CityCodeAssignerWithDictionaryFromFile(string sourceFilePath)
    {
        //string[] lines = File.ReadAllLines(sourceFilePath);

        //_dictionary = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

        //foreach (string line in lines) 
        //{
        //    string[] parts = line.Split('|');
        //    _dictionary.Add(parts[0].Trim(), parts[1].Trim());
        //}

        _dictionary =         
            File
            .ReadAllLines(sourceFilePath)
            .Select
            (
                line =>
                {
                    var parts =
                        line
                        .Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                    return (Key: parts[0], Value: parts[1]);
                }
            )
            .ToDictionary(x => x.Key, x => x.Value, StringComparer.CurrentCultureIgnoreCase);
    }

    public string GetCode(string? placeOfBirth)
    {
        if (placeOfBirth is null)
        {
            throw new PlaceOfBirthDoesNotExistException("null");
        }

        string key = placeOfBirth.Trim();


        if (!_dictionary.TryGetValue(key, out string? code))
        {
            throw new PlaceOfBirthDoesNotExistException(key);
        }
        return code;
    }
}