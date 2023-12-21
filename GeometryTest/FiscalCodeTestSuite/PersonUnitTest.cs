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
    }

    [Fact]
    public void Person_With_Invalid_Chars_For_Name_Should_Fail()
    {
        try
        {
            Person cippa =
                new Person
                (
                    "Cippa97",
                    "Lippa",
                    new DateOnly(1997, 5, 18),
                    Gender.Male,
                    "Firenze"
                );

            Assert.True(false);
        }
        catch (ArgumentNullException ex)
        {
            Assert.True(false);
        }
        catch (ArgumentException ex)
        {
            //Assert.True(ex.GetType() == typeof(ArgumentException));
            Assert.True(true);
        }
        catch (Exception)
        {
            Assert.True(false);
        }
    }
}