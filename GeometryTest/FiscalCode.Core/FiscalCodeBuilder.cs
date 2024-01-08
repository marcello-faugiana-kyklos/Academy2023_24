namespace FiscalCode.Core;

public class FiscalCodeBuilder
{
    public string Build(Person person, ICityCodeAssigner cityCodeAssigner)
    {
        string surnamePart = BuildSurnamePart(person.Surname);
        string namePart = BuildNamePart(person.Name);
        string birthDateAndGenderPart = BuildBirthDateAndGenderPart(person.DateOfBirth, person.Gender);
        
        string codeOfPlaceOfBirthPart = 
            BuildCodeOfPlaceOfBirthPart
            (
                person.PlaceOfBirth, 
                cityCodeAssigner ?? throw new ArgumentNullException(nameof(cityCodeAssigner))
            );

        return $"{surnamePart}{namePart}{birthDateAndGenderPart}{codeOfPlaceOfBirthPart}".ToUpper();
    }

    private string BuildSurnamePart(string surname)
    {
        var (cons, vow) = SplitStringIntoConsonantsAndVowels(surname);

        if (cons.Length >= 3)
        {
            return cons.Substring(0, 3);
        }

        if (cons.Length == 2)
        {
            return cons.Substring(0, 2) + (vow.Length > 0 ? vow[0] : "X");
        }

        if (cons.Length == 1)
        {
            return
                cons.Substring(0, 1) +
                (vow.Length > 1 ? vow.Substring(0, 2) : (vow[0] + "X"));
        }

        return
            vow.Length > 2
            ? vow.Substring(0, 3)
            : (vow.Substring(0, 2) + "X");

    }

    private string BuildNamePart(string name)
    {
        var (cons, vow) = SplitStringIntoConsonantsAndVowels(name);

        if (cons.Length >= 4)
        {
            return $"{cons[0]}{cons[2]}{cons[3]}";
        }

        if (cons.Length == 3)
        {
            return cons.Substring(0, 3);
        }

        if (cons.Length == 2)
        {
            return $"{cons[0]}{cons[1]}{(vow.Length > 0 ? vow[0] : "X")}";
        }

        if (cons.Length == 1)
        {
            return $"{cons[0]}{(vow.Length > 1 ? vow.Substring(0, 2) : (vow[0] + "X"))}";
        }

        return
            vow.Length > 2
            ? vow.Substring(0, 3)
            : (vow.Substring(0, 2) + "X");

    }

    private static char[] MonthLetters = ['A', 'B', 'C', 'D', 'E', 'H', 'L', 'M', 'P', 'R', 'S', 'T'];

    private string BuildBirthDateAndGenderPart(DateOnly dateOfBirth, Gender gender)
    {
        string yearPart = (dateOfBirth.Year % 100).ToString("00");
        string monthPart = MonthLetters[dateOfBirth.Month - 1].ToString();

        string dayPart = (dateOfBirth.Day + (gender == Gender.Female ? 40 : 0)).ToString("00");


        return yearPart + monthPart + dayPart;
    }


    private static readonly ISet<char> Vowels =
        new HashSet<char>
        {
            'a', 'e', 'i', 'o', 'u'
        };

    private static char FixCharacter(char c) =>
        c switch
        {
            'à' => 'a',
            'è' => 'e',
            'é' => 'e',
            'ì' => 'i',
            'ò' => 'o',
            'ù' => 'u',
            _ => c 
        };

    private (string Consonants, string Vowels) SplitStringIntoConsonantsAndVowels(string value)
    {
        string cons = "";
        string vow = "";

        foreach (var cc in value)
        {
            char c = char.ToLower(cc);

            if (char.IsWhiteSpace(c) || c == '\'')
            {
                continue;
            }

            c = FixCharacter(c);

            if  (Vowels.Contains(c))
            {
                vow += c;
            }
            else
            {
                cons += c;
            }
        }

        return (cons, vow);
    }

    private string BuildCodeOfPlaceOfBirthPart
    (
        string placeOfBirth, 
        ICityCodeAssigner cityCodeAssigner
    )  =>
        cityCodeAssigner.GetCode(placeOfBirth);
}
