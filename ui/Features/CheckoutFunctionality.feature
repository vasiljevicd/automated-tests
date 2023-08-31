@Regression
@CheckoutFunctionality
Feature:  Checkout Functionality
  As a customer,
  I want to be able to checkout when my items are in cart


Scenario: Filling in all information on the Checkout: Your Information Page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then I should be redirected to the overview page

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Getting error message when some information is not entered on the Checkout: Your Information Page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "<FirstName>" , last name "<LastName>" and postal code "<PostalCode>"
  And I click on the continue button
  Then error message "<ErrorMessage>" is shown on checkout your information page

  Examples:
  | FirstName  | LastName  | PostalCode | ErrorMessage                   | username                | password     |
  |            | Last name | 12345      | Error: First Name is required  | standard_user           | secret_sauce |
  | First name |           | 12345      | Error: Last Name is required   | problem_user            | secret_sauce |
  | First name | Last name |            | Error: Postal Code is required | performance_glitch_user | secret_sauce |


Scenario: Cheking prices in the checkout overview page 
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I get price for the item "Sauce Labs Onesie" from the cart page
  And I get price for the item "Sauce Labs Fleece Jacket" from the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then the price for the item "Sauce Labs Onesie" in the overview should be the same as on cart page
  Then the price for the item "Sauce Labs Fleece Jacket" in the overview should be the same as on cart page
    
  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking quantity in the checkout overview page 
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then the quantity of the item "Sauce Labs Onesie" in the overview should be 1
  Then the quantity of the item "Sauce Labs Fleece Jacket" in the overview should be 1

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking item total in the checkout overview page 
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I get price for the item "Sauce Labs Onesie" from the cart page
   When I get price for the item "Sauce Labs Fleece Jacket" from the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then the item total in the overview should be sum of all items in the cart

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking tax in the checkout overview page 
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I get price for the item "Sauce Labs Onesie" from the cart page
  When I get price for the item "Sauce Labs Fleece Jacket" from the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then the tax in the overview should be 8% of items total

  Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Cheking total in the checkout overview page 
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I get price for the item "Sauce Labs Onesie" from the cart page
  When I get price for the item "Sauce Labs Fleece Jacket" from the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then the total in the overview should be sum of tax and items total

Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Canceling checkout on overview page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  And I click on the cancel button
  Then I should be redirected to the products page

Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |


Scenario: Finishing checkout on overview page
  Given I am on the login page
  When I enter username "<username>" and password "<password>"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page   
  And I click on the cart
  Given I am on the cart page
  When I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  And I click on the finish button
  Then I should be redirected to the checkout complete page
  When I click on the back to home button
  Then I should be redirected to the products page

Examples:
  | username      | password     |
  | standard_user | secret_sauce |
  | problem_user  | secret_sauce |
  | performance_glitch_user  | secret_sauce |