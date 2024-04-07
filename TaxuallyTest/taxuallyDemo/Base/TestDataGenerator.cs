using System;

namespace TaxuallyTest.taxuallyDemo.Base;
public class TestDataGenerator
{
    private readonly string _candidateName = "candidate name";
    private readonly string _companyName = "test company";
    public string GenerateFullLegalName()
    {
        string actualDate = DateTime.Now.ToString("yyyy-MM-dd");
        return $"{_candidateName} {_companyName} {actualDate}";
    }
    public int RandomNumberGenerator()
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        return randomNumber;
    }
}
