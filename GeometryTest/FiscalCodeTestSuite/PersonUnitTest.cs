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

    const string fileName = "people.txt";

    [Fact]
    public void Read_all_people_from_file_with_classic_code_should_work()
    {
        Person[] people = null; // add code to read and parse the people in the file

        Assert.Equal(3, people.Length);

        Assert.Equal("Cippa", people[0].Name);
        // other asserts 
    }

    [Fact]
    public void Read_all_people_from_file_with_LINQ_should_work()
    {    


    }
}





