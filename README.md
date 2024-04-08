# taxtest_dotnet

install the following packages:
"Microsoft.Playwright"
"Microsoft.Playwright.Nunit"
"NUnit"
"NUnit3TestAdapter"
"System.Security.Cryptography.ProtectedData"

One thing I could have implemented for more advanced solution is saving StorageState from login and use it forother tests, but for some reasons StorageStateOptions did not work on the given Microsoft.Playwright namespace.

For better separation I could have possibly create one more layer for Page Actions and separate the Page Actions from Page Objects more. In a real-life project, that is more than recommeneded, but I did not implement it here.

Run the test with dotnet test or dotnet test --settings:chromium.runsettings
