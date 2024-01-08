using FiscalCode.Core.Exceptions;

namespace FiscalCode.Core;

public class CityCodeAssignerWithSwitch : ICityCodeAssigner
{
    public string GetCode(string? placeOfBirth)
    {
        if (placeOfBirth is null)
        {
            throw new PlaceOfBirthDoesNotExistException("null");
        }

        string key = placeOfBirth.Trim().ToLower();

        return
            key switch
            {
                "firenze" => "D612",
                "torino" => "L219",
                "roma" => "H501",
                "palermo" => "G273",
                "austria" => "Z102",
                "belgio" => "Z103",
                "francia" => "Z106",
                _ => throw new PlaceOfBirthDoesNotExistException(key)
            };

    }
}