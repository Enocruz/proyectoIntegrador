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
    public class TestCuentaMobile720x720
    {
        [TestMethod]
        public void testCuentaMobile720x720()
        {
            // Inicializar chrome driver
            using (var driver = new ChromeDriver())
            {
                // Variables a utilizar
                IWebElement element;
                Actions actions = new Actions(driver);
                // Pantalla 720x720
                driver.Manage().Window.Size = new Size(720, 720);
                // Ir al índice
                driver.Navigate().GoToUrl("http://localhost:49290/");
                // Ir a la sección Huellas latentes
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[4]/a"));
                element.Click();
                // Ver detalle
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""history""]/thead/tr/th[1]"));
                actions.MoveToElement(element);
                element.Click();
                // Probar el filtro
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("filter"));
                actions.MoveToElement(element);
                actions.Perform();
                element.SendKeys("33.1");
                // Probar botón para nueva identificación
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("nuevaIdentificacion"));
                actions.MoveToElement(element);
                actions.Perform();
                element.Click();              
                // Termina test
                Console.WriteLine("Prueba Completada");
            }
        }
    }
}