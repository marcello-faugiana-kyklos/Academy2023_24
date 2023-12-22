namespace FiscalCode.Core;

public class Person
{
    public string Name { get; }
    public string Surname { get; }
    public DateOnly DateOfBirth { get; }
    public Gender Gender { get; }
    public string PlaceOfBirth { get; }

    public Person(string name, string surname, DateOnly dateOfBirth, Gender gender, string placeOfBirth)
    {       
        ValidateString(name, nameof(name));
        ValidateString(surname, nameof(surname));
        ValidateString(placeOfBirth, nameof(placeOfBirth));

        Name = name;
        Surname = surname;
        DateOfBirth = dateOfBirth;
        Gender = gender;
        PlaceOfBirth = placeOfBirth;
    }

    private static readonly ISet<char> AllowedChars = 
        new HashSet<char>
        {
            'a', 'b', 'c',
            'd', 'e', 'f',
            'g', 'h', 'i',
            'j', 'k', 'l',
            'm', 'n', 'o',
            'p', 'q', 'r',
            's', 't', 'u',
            'v', 'w', 'x',
            'y', 'z',
            'à', 'è', 'é',
            'ì', 'ò', 'ù',
            '\'', ' '
        };

    private static void ValidateString(string value, string parameterName)
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        //foreach (char c in value)
        //{
        //    if (!AllowedChars.Contains(char.ToLower(c)))
        //    {
        //        throw new ArgumentException($"{parameterName} contains invalid chars: {c}");
        //    }
        //}

        //Enumerable.All(value, c => AllowedChars.Contains(char.ToLower(c))))

        if (!value.All(c => AllowedChars.Contains(char.ToLower(c))))
        {
            throw new ArgumentException($"{parameterName} contains invalid chars");
        }

        if (value.Length < 2)
        {
            throw new ArgumentException($"{parameterName} must be at least 2 chars");
        }
    }
}
