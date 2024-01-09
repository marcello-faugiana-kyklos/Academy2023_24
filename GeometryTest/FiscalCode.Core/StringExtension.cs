namespace FiscalCode.Core;

public static class StringExtension
{
    public static bool IsNullOrEmpty(this string? s) =>
        string.IsNullOrEmpty(s);

    public static string StringJoin(this IEnumerable<string> list, string separator) =>
        string.Join(separator, list);
}