using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using static System.Collections.Specialized.BitVector32;

namespace SeleniumTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("test case started ");
            //create the reference for the browser  
            IWebDriver driver = new ChromeDriver();
            // navigate to URL  
            driver.Navigate().GoToUrl("https://www.automationexercise.com/products");
            Thread.Sleep(1000);

            IWebElement ele = driver.FindElement(By.Id("search_product"));
            ele.SendKeys("dress");
            Thread.Sleep(1000);

            IWebElement ele1 = driver.FindElement(By.Id("submit_search"));
            ele1.Click();

            IReadOnlyCollection<IWebElement> sectionElements = driver.FindElements(By.TagName("section"));

            // Check if the list contains at least two elements
            if (sectionElements.Count == 2)
            {
                // Select the second section element
                IWebElement secondSectionElement = sectionElements.ToList()[1];

                IWebElement container = secondSectionElement.FindElement(By.CssSelector(".container"));

                IWebElement row = container.FindElement(By.CssSelector(".row"));

                IWebElement colsm9 = row.FindElement(By.CssSelector(".col-sm-9"));

                IWebElement featureElement = colsm9.FindElement(By.CssSelector(".features_items"));

                IReadOnlyCollection<IWebElement> colElements = featureElement.FindElements(By.CssSelector(".col-sm-4"));

                for (int i = 0; i < colElements.Count; i++)
                {

                    IWebElement selectedCol = colElements.ToList()[i];

                    Actions actions = new Actions(driver);

                    actions.MoveToElement(selectedCol).Perform();

                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    IWebElement prodImageWrap = selectedCol.FindElement(By.CssSelector(".product-image-wrapper"));

                    IWebElement singleProduct = prodImageWrap.FindElement(By.CssSelector(".single-products"));

                    IWebElement productOverlay = singleProduct.FindElement(By.CssSelector(".product-overlay"));

                    IWebElement overlayContent = productOverlay.FindElement(By.CssSelector(".overlay-content"));

                    IWebElement addToCart = overlayContent.FindElement(By.CssSelector(".btn.btn-default.add-to-cart"));
                    addToCart.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(3));

                    IWebElement cartModal = featureElement.FindElement(By.Id("cartModal"));

                    IWebElement modalDialog = cartModal.FindElement(By.CssSelector(".modal-dialog"));

                    IWebElement modalContent = modalDialog.FindElement(By.CssSelector(".modal-content"));

                    IWebElement modalFooter = modalContent.FindElement(By.CssSelector(".modal-footer"));

                    IWebElement btnContShop = modalFooter.FindElement(By.CssSelector(".btn.btn-success.close-modal"));
                    btnContShop.Click();
                    ////Thread.Sleep(TimeSpan.FromSeconds(3));

                }
                
            }

            driver.Close();

            Console.Write("test case ended ");
        }

    }
}
