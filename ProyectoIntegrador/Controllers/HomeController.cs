using System.Web.Mvc;
using System;
using System.IO.Compression;
using System.Drawing;
using System.Collections.Generic;

namespace ProyectoIntegrador.Controllers
{
    public class HomeController : Controller
    {
        string[] errors = { "La imagen debe estar en escala de grises", "Debes seleccionar al menos una región" };
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Impresion()
        {
            if (Request.RequestType.Equals("POST"))
            {
                var regiones = Request.Form.AllKeys;
                if (regiones.Length <= 0)
                {
                    Response.Redirect("/Home/Impresion?error=1");
                    return View();
                }
                System.Diagnostics.Debug.WriteLine(regiones);
                using (ZipArchive zip = new ZipArchive(Request.Files.Get("image").InputStream))
                {
                    foreach (ZipArchiveEntry entry in zip.Entries)
                    {
                        var img = Bitmap.FromStream(entry.Open());
                        if(!TestGrayScale(new Bitmap(img), 8))
                        {
                            Response.Redirect("/Home/Impresion?error=0");
                            return View();
                        }
                        System.Diagnostics.Debug.WriteLine(new Bitmap(img).HorizontalResolution);
                    }
                }
                Response.Redirect("/Home/Detalle");
            }
            if(Request.QueryString["error"] != null)
            {
                ViewBag.Error = errors[Int32.Parse(Request.QueryString["error"])];
            }
            ViewBag.Header = "Identificación de huellas de impresión";
            return View();
        }

        public ActionResult Latente()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Historial()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Cuenta()
        {
            ViewBag.Message = "Tu información de tu cuenta";
            return View();
        }

        public ActionResult Detalle()
        {
            ViewBag.Message = "Detalle de identificación";
            return View();
        }

        public bool TestGrayScale(Bitmap bmp, int threshold)
        {
            Color pixelColor = Color.Empty;
            int rgbDelta;

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    pixelColor = bmp.GetPixel(x, y);
                    rgbDelta = Math.Abs(pixelColor.R - pixelColor.G) + Math.Abs(pixelColor.G - pixelColor.B) + Math.Abs(pixelColor.B - pixelColor.R);
                    if (rgbDelta > threshold) return false;
                }
            }
            return true;
        }
    }
}