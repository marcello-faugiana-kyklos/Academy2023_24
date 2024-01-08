namespace FiscalCode.Core.Exceptions;

public class PlaceOfBirthDoesNotExistException : Exception
{
    public PlaceOfBirthDoesNotExistException(string placeOfBirth) : 
        base($"The value '{placeOfBirth}' is not a valid place of birth")
    {
    }
}
