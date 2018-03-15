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
    public class TestIndexMobile320x1080Index
    {
        [TestMethod]
        public void testIndexMobile320x1080()
        {
            // Inicializar chrome driver
            using (var driver = new ChromeDriver())
            {
                // Variables a utilizar
                IWebElement element;
                Actions actions = new Actions(driver);
                // Pantalla 320 x 1080
                driver.Manage().Window.Size = new Size(320, 1080);
                // Ir al índice
                driver.Navigate().GoToUrl("http://localhost:49290/");
                // Ir a la sección de identificación de huella latente
                element = driver.FindElement(By.Id("identificacionLatente"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                Thread.Sleep(2000);
                // Volver al índice
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/a"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                Thread.Sleep(2000);
                // Ir a la sección de identificación de huella impresión
                element = driver.FindElement(By.Id("identificacionImpresion"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                Thread.Sleep(2000);
                // Volver al índice
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/a"));
                element.Click();
                Thread.Sleep(2000);
                // Ir a la sección de identificaciones guardadas
                element = driver.FindElement(By.Id("verHistorial"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                Thread.Sleep(2000);
                // Volver al índice
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/a"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                Thread.Sleep(1000);
                // Termina test
                Console.WriteLine("Prueba Completada");
            }
        }
    }
}