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
    public class TestHistorialMobile420x720
    {
        [TestMethod]
        public void testHistorialMobile420x720()
        {
            // Inicializar chrome driver
            using (var driver = new ChromeDriver())
            {
                // Variables a utilizar
                IWebElement element;
                Actions actions = new Actions(driver);
                // Pantalla tamaño 420 x 780
                driver.Manage().Window.Size = new Size(420, 720);
                // Ir al índice
                driver.Navigate().GoToUrl("http://localhost:49290/");
                // Ir a la sección Huellas latentes
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[3]/a"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                // Ver detalle
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("detalle1"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                // Se regresa a la pantalla de huellas latentes
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[3]/a"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                // Probar el filtro
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("filter"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.SendKeys("2018");
                // Probar botón para nueva identificación
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("nuevaIdentificacion"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                // Volver al índice
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/a"));
                actions.MoveToElement(element);
                Thread.Sleep(2000);
                element.Click();
                // Termina test
                Console.WriteLine("Prueba Completada");
            }
        }
    }
}