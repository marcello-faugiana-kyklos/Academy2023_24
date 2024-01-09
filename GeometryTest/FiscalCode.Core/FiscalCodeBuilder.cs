namespace FiscalCode.Core;

public class FiscalCodeBuilder
{
    private static readonly Dictionary<char, int> cinEven;
    private static readonly Dictionary<char, int> cinOdd;
    static FiscalCodeBuilder()
    {
        cinOdd =
            new Dictionary<char, int>()
            {
                { '0', 1 },
                { '1', 0 },
                { '2', 5 },
                { '3', 7 },
                { '4', 9 },
                { '5',13 },
                { '6', 15},
                { '7',17 },
                { '8',19 },
                { '9', 21},
                { 'A', 1 },
                { 'B', 0 },
                { 'C', 5 },
                { 'D', 7 },
                { 'E', 9 },
                { 'F',13 },
                { 'G',15 },
                { 'H',17 },
                { 'I',19 },
                { 'J',21 },
                { 'K', 2 },
                { 'L', 4 },
                { 'M',18 },
                { 'N',20 },
                { 'O',11 },
                { 'P', 3 },
                { 'Q', 6 },
                { 'R', 8 },
                { 'S', 12},
                { 'T', 14},
                { 'U',16 },
                { 'V',10 },
                { 'W',22 },
                { 'X',25 },
                { 'Y',24 },
                { 'Z',23 }
            };

        cinEven =
            new Dictionary<char, int>
            {
                { '0', 0 },
                // to be completed
            };
    }

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

        string partialCode = $"{surnamePart}{namePart}{birthDateAndGenderPart}{codeOfPlaceOfBirthPart}".ToUpper();

        return partialCode + BuildCINPart(partialCode);
    }

    private string BuildCINPart(string partialCode)
    {
        int sum = 0;

        for (int i = 0; i < partialCode.Length; i++)
        {
            if ((i + 1) % 2 == 0)
            {
                sum += cinEven[partialCode[i]];
            }
            else
            {
                sum += cinOdd[partialCode[i]];
            }
        }

        int remainder = sum % 26;

        return ('A' + remainder).ToString();
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

            if (Vowels.Contains(c))
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
    ) =>
        cityCodeAssigner.GetCode(placeOfBirth);
}
