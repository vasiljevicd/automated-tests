@Regression
@LoginFunctionality
Feature:  Login and Logout Functionality
  As I customer,
  I want to be able to login to the application if user exist
  I want to be unable to login to the application if user do not exist
  I want to be able to logout from application


Scenario: Succesfull login
  Given I am on the login page
  When I enter username "<Username>" and password "<Password>"
  And I click the login button
  Then I should be redirected to the products page

   Examples:
  | Username      | Password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Unsucesfull login
  Given I am on the login page
  When I enter username "<Username>" and password "<Password>"
  And I click the login button
  Then error message "<ErrorMessage>" is shown on login page

   Examples:
  | Username        | Password     | ErrorMessage                                                              |
  | user_not_exist  | secret_sauce | Epic sadface: Username and password do not match any user in this service |
  | locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out.                       |


Scenario: Succesfull logout
  Given I am on the login page
  When I enter username "<Username>" and password "<Password>"
  And I click the login button
  Then I should be redirected to the products page
  When I logout from the application
  Then I should be redirected to the login page

   Examples:
  | Username      | Password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |