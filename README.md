# taxtest_dotnet

install the following packages:
"Microsoft.Playwright"
"Microsoft.Playwright.Nunit"
"NUnit"
"NUnit3TestAdapter"
"coverlet.collector"
"System.Security.Cryptography.ProtectedData"

One thing I could have implemented for more advanced solution is saving StorageState from login and use it forother tests, but for some reasons StorageStateOptions did not work on the given Microsoft.Playwright namespace.

Run the test with dotnet test or dotnet test --settings:chromium.runsettings
