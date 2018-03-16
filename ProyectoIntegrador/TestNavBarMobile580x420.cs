using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using OpenQA.Selenium.Interactions;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class TestNavBarMobile580x420
    {
        [TestMethod]
        public void testNavBarMobile580x420()
        {
            // Inicializar chrome driver
            using (var driver = new ChromeDriver())
            {
                // Variables a utilizar
                IWebElement element;
                Actions actions = new Actions(driver);
                // Pantalla tamaño 580 x 420
                driver.Manage().Window.Size = new Size(580, 420);
                // Ir al índice
                driver.Navigate().GoToUrl("http://localhost:49290/");
                // Ir a la sección Huellas latentes
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[1]/a"));
                element.Click();
                // Ir a la sección Impresiones de huellas
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[2]/a"));
                element.Click();
                // Ir a la sección Historial
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[3]/a"));
                element.Click();
                // Ir a la sección Mi cuenta
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[4]/a"));
                element.Click();
                // Volver al índice
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/a"));
                element.Click();
                // Termina test
                Console.WriteLine("Prueba Completada");
            }
        }
    }
}