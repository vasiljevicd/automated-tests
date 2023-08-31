# Automated tests

#API

The folder contains RESTful API tests which are implemented using NUnit Test Framework.

## Running tests

In order to run all tests in the console from api folder:

```bash
dotnet test
```

#UI

The folder contains automated frontend tests which are implemented using the Selenium Web Driver.

Tests use the [Specflow/Gherkin] BDD style syntax to align with manual test cases and create a consistent framework for product quality.

## Running tests
The test can be run on Chrome or Firefox driver, which can be changed in /ui/Config/Configuration.cs file.
With every execution, ExtentReport is generated in the folder Report.

In order to run all tests in the console from ui folder:

```bash
dotnet test
```

## Writing a .feature file

`.feature` files are located in `Features/*.feature`. The Gherkin syntax is as follows:

``` feature
Feature:  Login Functionality
  As I customer,
  I want to be able to log in to the application if the user exists

Scenario: Succesfull login
  Given I am on the login page
  When I enter username "<Username>" and password "<Password>"
  And I click the login button
  Then I should be redirected to the products page
```

## Tagging tests

Tests can be run using specific tags. In order to tag a scenario, we add a tag in the `.feature` file, prefixed with the `@` sign:

``` feature
@Regression
@LoginFunctionality
Feature:  Log-in and Logout Functionality
  As I customer,
  I want to be able to log in to the application if the user exists

Scenario: Succesfull login
  Given I am on the login page
  When I enter username "<Username>" and password "<Password>"
  And I click the login button
  Then I should be redirected to the products page
```

Then, to run tests with specific tags, issue:

```bash
 dotnet test --filter "TestCategory=Regression"
```

