@CartFunctionality
@Regression
Feature:  Cart Functionality
  As a customer,
  I want to be able to add and remove items to the cart


Scenario: Adding item to the cart from the products page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I add the item "Sauce Labs Backpack" from the products page
  Then shopping cart badge should be 1

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Adding item to the cart from item page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I add the item "Sauce Labs Bolt T-Shirt" from the item page
  Then shopping cart badge should be 1

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking prices in the cart
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I get price for the item "Sauce Labs Fleece Jacket" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page
  And I click on the cart
  Then the price for the item "Sauce Labs Fleece Jacket" in the cart should be the same as on products page

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking quantity in the cart
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I add the item "Sauce Labs Fleece Jacket" from the products page
  And I click on the cart
  Then the quantity of the item "Sauce Labs Fleece Jacket" in the cart should be 1

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Removing item from the cart from the home page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I add the item "Sauce Labs Backpack" from the products page
  And I remove the item "Sauce Labs Backpack" from the products page
  Then shopping cart badge should not be visible

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Removing item from the cart page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  Given I am on the products page
  When I add the item "Sauce Labs Backpack" from the products page
  And I click on the cart
  And I remove the item "Sauce Labs Backpack" from the cart page
  Then shopping cart should be empty


Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |