namespace FiscalCode.Core;

public interface ICityCodeAssigner
{
    /// <summary>
    /// Retrieves the Belfiore code for the place of birth.
    /// </summary>
    /// <param name="placeOfBirth">Place of birth. If null or does not exist then throws a PlaceOfBirthDoesNotExistException</param>
    /// <returns>The associated code</returns>
    string GetCode(string? placeOfBirth);
}