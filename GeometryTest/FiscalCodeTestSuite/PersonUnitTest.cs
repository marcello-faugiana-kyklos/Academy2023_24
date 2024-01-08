using FiscalCode.Core;

namespace FiscalCodeTestSuite;

public class PersonUnitTest
{
    [Fact]
    public void Person_With_Valid_chars_for_Name_Surname_PlaceOfBirth_Should_Succed()
    {
        Person cippa =
            new Person
            (
                "Cippa",
                "Lippa",
                new DateOnly(1997, 5, 18),
                Gender.Male,
                "Firenze"
            );

        Assert.Equal("Cippa", cippa.Name);
        Assert.Equal("Lippa", cippa.Surname);
    }

    //[Fact]
    //public void Person_With_Invalid_Chars_For_Name_Should_Fail()
    //{
    //    try
    //    {
    //        Person cippa =
    //            new Person
    //            (
    //                "Cippa97",
    //                "Lippa",
    //                new DateOnly(1997, 5, 18),
    //                Gender.Male,
    //                "Firenze"
    //            );

    //        Assert.True(false);
    //    }
    //    catch (ArgumentNullException ex)
    //    {
    //        Assert.True(false);
    //    }
    //    catch (ArgumentException ex)
    //    {
    //        //Assert.True(ex.GetType() == typeof(ArgumentException));
    //        Assert.True(true);
    //    }
    //    catch (Exception)
    //    {
    //        Assert.True(false);
    //    }
    //}

    [Fact]
    public void Person_With_Invalid_Chars_For_Name_Should_Fail()
    {
        Action action =
            () =>
            {
                new Person
                (
                    "Cippa97",
                    "Lippa",
                    new DateOnly(1997, 5, 18),
                    Gender.Male,
                    "Firenze"
                );
            };

        Assert.Throws<ArgumentException>(action);
    }

    [Fact]
    public void Person_With_Null_Surname_Should_Fail()
    {
        Action action =
            () =>
            {
                new Person
                (
                    "Cippa",
                    null,
                    new DateOnly(1997, 5, 18),
                    Gender.Male,
                    "Firenze"
                );
            };

        Assert.Throws<ArgumentNullException>(action);
    }


    [Theory]
    [InlineData("Lippa", "LPP")]
    [InlineData("Faugiana", "FGN")]
    [InlineData("Fo", "FOX")]
    [InlineData("Of", "FOX")]
    [InlineData("Conte", "CNT")]
    [InlineData("AEO", "AEO")]
    [InlineData("AE", "AEX")]
    [InlineData("ÀEO", "AEO")]
    [InlineData("Di Stefano", "DST")]
    [InlineData("D'Onofrio", "DNF")]
    [InlineData("ÀÈÙÀÒ", "AEU")]
    public void Build_Surname_Part_Should_Work(string surname, string expected)
    {
        var cippa = 
            new Person
            (
                "Cippa",
                surname,
                new DateOnly(1997, 5, 18),
                Gender.Male,
                "Firenze"
            );

        FiscalCodeBuilder fiscalCodeBuilder = new FiscalCodeBuilder();
        string fiscalCode = fiscalCodeBuilder.Build(cippa);

        string surnamePart = fiscalCode.Substring(0, 3);

        Assert.Equal(expected, surnamePart);
    }

    [Theory]
    [InlineData("Cippa", "CPP")]
    [InlineData("Marcello", "MCL")]
    [InlineData("Bo", "BOX")]
    [InlineData("Of", "FOX")]
    [InlineData("Alessio", "LSS")]
    [InlineData("Gianfranco", "GFR")]
    [InlineData("AE", "AEX")]
    [InlineData("ÀEO", "AEO")]
    [InlineData("Vittorio Emanuele", "VTR")]
    [InlineData("Vincenzo", "VCN")]
    [InlineData("Andrea", "NDR")]
    [InlineData("Antonio", "NTN")]
    [InlineData("O'hare", "HRO")]
    public void Build_Name_Part_Should_Work(string name, string expected)
    {
        var cippa =
            new Person
            (
                name,
                "Lippa",
                new DateOnly(1997, 5, 18),
                Gender.Male,
                "Firenze"
            );

        FiscalCodeBuilder fiscalCodeBuilder = new FiscalCodeBuilder();
        string fiscalCode = fiscalCodeBuilder.Build(cippa);

        string namePart = fiscalCode.Substring(3, 3);

        Assert.Equal(expected, namePart);
    }

    [Theory]
    [InlineData("1999-02-16", Gender.Female, "99B56")]
    [InlineData("1999-02-16", Gender.Male, "99B16")]
    public void Build_BirthDate_And_Gender_Part_Should_Work(string birthDateAsString, Gender gender, string expected)
    {
        DateOnly birthdate = DateOnly.ParseExact(birthDateAsString, "yyyy-MM-dd");

        var cippa =
            new Person
            (
                "Cippa",
                "Lippa",
                birthdate,
                gender,
                "Firenze"
            );

        FiscalCodeBuilder fiscalCodeBuilder = new FiscalCodeBuilder();
        string fiscalCode = fiscalCodeBuilder.Build(cippa);

        string birtdateAndGenderPart = fiscalCode.Substring(6, 5);

        Assert.Equal(expected, birtdateAndGenderPart);
    }

    [Theory]
    [InlineData("Firenze", "D612")]
    [InlineData("FIRENZE", "D612")]
    [InlineData("Roma", "H501")]
    [InlineData("Torino", "L219")]
    [InlineData("Pescara", "G482")]
    [InlineData("lsakdfhsklfh", "XYZ")]
    [InlineData("Austria", "Z102")]
    [InlineData("Österreich", "Z102")]
    public void CityCodeAssigner_should_work(string placeOfBirth, string expected)
    {
        CityCodeAssigner cityCodeAssigner = new CityCodeAssigner();

        string code = cityCodeAssigner.GetCode(placeOfBirth);
        Assert.Equal(expected, code);
    }
}





