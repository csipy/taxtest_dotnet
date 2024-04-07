# taxtest_dotnet

install the following packages:
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.11.0" />
    <PackageReference Include="Microsoft.Playwright" Version="1.42.0" />
    <PackageReference Include="Microsoft.Playwright.Nunit" Version="1.42.0" />
    <PackageReference Include="NUnit" Version="3.13.2" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.5.0" />
    <PackageReference Include="coverlet.collector" Version="3.1.0" />
    <PackageReference Include="System.Security.Cryptography.ProtectedData" Version="8.0.0" />

One thing I could have implemented for more advanced solution is saving StorageState from login and use it forother tests, but for some reasons StorageStateOptions did not work on the given Microsoft.Playwright namespace.

Run the test with dotnet test or dotnet test --settings:chromium.runsettings
