@Regression
@endToEndFunctionality
Feature:  End to end Funcionality
  As a customer,
  I want to be able to login,
  I want to be able to add products in the cart,
  I want to be able to remove product from the cart,
  I want to be able to go to the checkout
  and I want to be able to finsih my purchase and logout


Scenario: Adding and removing items from the products page and checking out 
  Given I am on the login page
  When I enter username "standard_user" and password "secret_sauce"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the products page
  And I add the item "Test.allTheThings() T-Shirt (Red)" from the products page
  And I add the item "Sauce Labs Fleece Jacket" from the products page
  Then shopping cart badge should be 3
  When I click on the cart
  And I remove the item "Sauce Labs Onesie" from the cart page
  And I get price for the item "Test.allTheThings() T-Shirt (Red)" from the cart page
  And I get price for the item "Sauce Labs Fleece Jacket" from the cart page
  And I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then I should be redirected to the overview page
  Then the item total in the overview should be sum of all items in the cart
  Then the tax in the overview should be 8% of items total
  Then the total in the overview should be sum of tax and items total
  When I click on the finish button
  Then I should be redirected to the checkout complete page
  When I click on the back to home button
  Then I should be redirected to the products page
  When I logout from the application
  Then I should be redirected to the login page



Scenario: Adding items from the items page, removing items from the product page and checking out 
  Given I am on the login page
  When I enter username "standard_user" and password "secret_sauce"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the item page and go back to products
  And I add the item "Test.allTheThings() T-Shirt (Red)" from the item page and go back to products
  And I add the item "Sauce Labs Bolt T-Shirt" from the item page and go back to products
  Then shopping cart badge should be 3
  When I remove the item "Test.allTheThings() T-Shirt (Red)" from the products page
  When I click on the cart
  And I get price for the item "Sauce Labs Onesie" from the cart page
  And I get price for the item "Sauce Labs Bolt T-Shirt" from the cart page
  And I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then I should be redirected to the overview page
  Then the item total in the overview should be sum of all items in the cart
  Then the tax in the overview should be 8% of items total
  Then the total in the overview should be sum of tax and items total
  When I click on the finish button
  Then I should be redirected to the checkout complete page
  When I click on the back to home button
  Then I should be redirected to the products page
  When I logout from the application
  Then I should be redirected to the login page


Scenario: Adding items from the item and products page, removing items from the cart page and checking out 
  Given I am on the login page
  When I enter username "standard_user" and password "secret_sauce"
  And I click the login button
  Then I should be redirected to the products page
  When I add the item "Sauce Labs Onesie" from the item page and go back to products
  And I add the item "Test.allTheThings() T-Shirt (Red)" from the products page
  And I add the item "Sauce Labs Bike Light" from the item page and go back to products
  Then shopping cart badge should be 3
  When I click on the cart
  And I remove the item "Sauce Labs Bike Light" from the cart page
  And I get price for the item "Sauce Labs Onesie" from the cart page
  And I get price for the item "Test.allTheThings() T-Shirt (Red)" from the cart page
  And I click on the checkout button
  Then I should be redirected to the checkout your information page
  When I enter first name "First name" , last name "Last name" and postal code "11000"
  And I click on the continue button
  Then I should be redirected to the overview page
  Then the item total in the overview should be sum of all items in the cart
  Then the tax in the overview should be 8% of items total
  Then the total in the overview should be sum of tax and items total
  When I click on the finish button
  Then I should be redirected to the checkout complete page
  When I click on the back to home button
  Then I should be redirected to the products page
  When I logout from the application
  Then I should be redirected to the login page

