using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using ui.Config;

namespace ui.Core.Pages
{
	public class OverviewPage: BasePage
	{
        private IWebElement overviewTitle => driver.FindElement(By.XPath("//span[text()='Checkout: Overview']"));
        private IWebElement itemTotal => driver.FindElement(By.ClassName("summary_subtotal_label"));
        private IWebElement tax => driver.FindElement(By.ClassName("summary_tax_label"));
        private IWebElement total => driver.FindElement(By.XPath("//div[contains(@class,'summary_total_label')]"));
        private IWebElement cancelButton => driver.FindElement(By.Id("cancel"));
        private IWebElement finishButton => driver.FindElement(By.Id("finish"));

        public OverviewPage()
		{
			url = Configuration.baseUrl + "checkout-step-two.html";

        }

        public void VerifyOverviewTitleIsDisplayed()
        {
            Assert.IsTrue(baseWebElement.IsElementDisplayed(overviewTitle));

        }

        public string GetPriceForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'" + item + "')]/../../..//div[@class='inventory_item_price']").Text;
        }

        public string GetQuantityForItem(string item)
        {
            return baseWebElement.FindElementByXPath("//div[@class='inventory_item_name'][contains(text(),'" + item + "')]/../../..//div[@class='cart_quantity']").Text;
        }

        public string GetItemTotal()
        {
            return baseWebElement.GetElementText(itemTotal);
        }

        public string GetTax()
        {
            return baseWebElement.GetElementText(tax);
        }

        public string GetTotal()
        {
            return baseWebElement.GetElementText(total);
        }

        public void ClickOnTheCancelButton()
        {
            baseWebElement.ClickOnElement(cancelButton);
        }

        public void ClickOnTheFinishButton()
        {
            baseWebElement.ClickOnElement(finishButton);
        }

        public void VerifyPriceForItemOnOverviewPage(string itemPrice, string item)
        {
            Assert.AreEqual(itemPrice, GetPriceForItem(item));
        }

        public void VerifyQuantutyOfItemOnOverviewPage(string item, string itemQuantity)
        {
            Assert.AreEqual(itemQuantity, GetQuantityForItem(item));
        }

        public void VerifyItemTotalOnOverviewPage(Dictionary<string, string> itemsAndPrices)
        {
            double totalItem = CalculateItemTotal(itemsAndPrices);
            Assert.AreEqual(TransformItemTotalToString(totalItem), GetItemTotal());
        }

        public void VerifyTaxOnOverviewPage(Dictionary<string, string> itemsAndPrices)
        {
            double tax = CalculateTax(itemsAndPrices);
            Assert.AreEqual(TransformTaxToString(tax), GetTax());
        }

        public void VerifyTotalOnOverviewPage(Dictionary<string, string> itemsAndPrices)
        {
            double total = CalculateTotal(itemsAndPrices);
            Assert.AreEqual(TransformTotalToString(total), GetTotal());
        }




        private double CalculateItemTotal(Dictionary<string, string> itemsAndPrices)
        {
            double itemTotal = 0;
            foreach (var item in itemsAndPrices)
            {
                string numericPart = item.Value.Substring(1); // Remove the dollar sign
                itemTotal += double.Parse(numericPart);
            }

            return Math.Round(itemTotal, 2, MidpointRounding.ToEven);

        }

        private string TransformItemTotalToString(double itemTotal)
        {
            return "Item total: $" + itemTotal.ToString("F2");
        }

        private double CalculateTax(Dictionary<string, string> itemsAndPrices)
        {
            double totalItem = CalculateItemTotal(itemsAndPrices);
            double tax = totalItem * 0.08;
            return Math.Round(tax, 2, MidpointRounding.ToEven);

        }

        private string TransformTaxToString(double tax)
        {
            return "Tax: $" + tax.ToString("F2");
        }

        private double CalculateTotal(Dictionary<string, string> itemsAndPrices)
        {
            double itemTotal = CalculateItemTotal(itemsAndPrices);
            double tax = CalculateTax(itemsAndPrices);
            return itemTotal + tax;

        }

        private string TransformTotalToString(double total)
        {
            return "Total: $" + total.ToString("F2");
        }
    }
}

