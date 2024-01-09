using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalCodeTestSuite;

public class FileUnitTest
{
    [Fact]
    public void CheckFile_Read_methods()
    {
        string sourceFilePath = "place_of_birth_codes.txt";

        string content = File.ReadAllText(sourceFilePath);

        string[] lines = File.ReadAllLines(sourceFilePath);

        byte[] contentInBytes = File.ReadAllBytes(sourceFilePath);
    }

    [Fact]
    public void Split_line_should_work()
    {
        string sourceFilePath = "place_of_birth_codes.txt";

        string[] lines = File.ReadAllLines(sourceFilePath);

        foreach (string line in lines)
        {
            string[] parts = 
                line
                .Split
                (
                    '|', 
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                );
            
            string key = parts[0];
            string value = parts[1];
        }
    }
}
