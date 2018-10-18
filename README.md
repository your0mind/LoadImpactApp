# LoadImpactApp
More quick and convenient extraction of LoadImpact's test results.


# Installation
1. Download last release
2. Open .sln in VS and build the project
3. Copy the *UserSettings.xml* file located in the project root directory to the folder with the built-in application (*/bin/Debug* or */bin/Release*)

### If you want to use the export results to the Google Sheets
You should have your own google console project and *credentials.json* file from it
1. Visit [this page](https://developers.google.com/sheets/api/quickstart/dotnet)
2. Find the title "Step 1: Turn on the Google Sheets API" and follow the steps described there
3. In the end put your *credentials.json* file to the folder with the built-in application

When you try to export results for the first time you will need to give permission to access to your Google Sheets docs in the opened browser tab
