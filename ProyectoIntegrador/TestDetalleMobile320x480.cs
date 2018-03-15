using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Drawing;

namespace UnitTest
{
    [TestClass]
    public class TestDetalleHuellasMobile320x480
    {
        [TestMethod]
        public void testDetalleHuellasMobile320x480()
        {
            // Inicializar chrome driver
            using (var driver = new ChromeDriver())
            {
                // Variables a utilizar
                IWebElement element;
                // Pantalla completa
                driver.Manage().Window.Size = new Size(320,480);
                // Ir al índice
                driver.Navigate().GoToUrl("http://localhost:49290/");
                // Ir a la sección historial
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[1]/button"));
                element.Click();
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/ul/li[3]/a"));
                element.Click();
                // Ver detalle
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("detalle1"));
                element.Click();
                // Seleccionar huella a identificar para mostrar zoom
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("imgHuellaIdentificar"));
                element.Click();
                // Cerrar modal
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""imagemodal""]/div/div/div/button/span[1]"));
                element.Click();
                // Seleccionar primer elemento de la lista de resultados
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""lista""]/tbody/tr[1]"));
                element.Click();
                // Cerrar info
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("close"));
                element.Click();
                // Seleccionar segundo elemento de la lista de resultados
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""lista""]/tbody/tr[2]"));
                element.Click();
                // Zoom de la huella de resultados
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("huellaResultado"));
                element.Click();
                // Cerrar modal
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""imagemodal""]/div/div/div/button"));
                element.Click();
                // Guardar resultados
                Thread.Sleep(2000);
                element = driver.FindElement(By.Id("GuardarResultados"));
                element.Click();
                // Aceptar
                Thread.Sleep(2000);
                element = driver.FindElement(By.XPath(@"//*[@id=""guardarIdentificacion""]/div/div/div[3]/button[1]"));
                element.Click();
                // Termina test
                Thread.Sleep(2000);
                Console.WriteLine("Prueba Completada");
            }
        }
    }
}