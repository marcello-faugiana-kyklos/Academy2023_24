namespace FiscalCode.Core;

public interface ICityCodeAssigner
{
    string GetCode(string? placeOfBirth);
}