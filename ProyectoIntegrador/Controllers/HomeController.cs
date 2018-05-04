using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using ProyectoIntegrador.Models;
using SourceAFIS.Simple;
using System.Windows.Media.Imaging;
using System.Drawing;

namespace ProyectoIntegrador.Controllers
{

    public class HomeController : Controller
    {
        static AfisEngine afis = new AfisEngine();
        string[] errors = { "La imagen debe estar en escala de grises", "Debes seleccionar al menos una región" };
        private Modulo_IdentificacionEntities db = new Modulo_IdentificacionEntities();
        private int id = 1;
        public ActionResult Index()
        {
            USUARIO usuario = db.USUARIO.Find(id);
            ViewBag.creditos = usuario.Creditos;
            return View(usuario);
        }

        public ActionResult Impresion()
        {
            USUARIO usuario = db.USUARIO.Find(id);
            ViewBag.creditos = usuario.Creditos;
            ViewBag.Header = "Identificación de huellas de impresión";
            return View();
        }

        public ActionResult Latente()
        {
            USUARIO usuario = db.USUARIO.Find(id);
            ViewBag.creditos = usuario.Creditos;
            var creditos = usuario.Creditos;
            var caso = db.CASO.ToList();
            var subcaso = db.SUBCASO.Include(l => l.LATENTE).Include(c => c.CASO).ToList();
            return View(Tuple.Create(caso,subcaso,creditos));
        }

        public ActionResult Historial()
        {
            USUARIO usuario = db.USUARIO.Find(id);
            ViewBag.creditos = usuario.Creditos;
            var identificacion = db.IDENTIFICACION.Include(s => s.SUBCASO).ToList();
            return View(identificacion);
        }

        public ActionResult Cuenta()
        {
            ViewBag.Message = "Tu información de tu cuenta";
            using (var context = new Modulo_IdentificacionEntities())
            {
                var id = 1;
                var historial = context.HISTORIAL.Include(h => h.MOVIMIENTO).Include(h => h.SUBCASO).Include(h => h.USUARIO).Where(a => a.idUsuario == id);
                USUARIO usuario = db.USUARIO.Find(id);
                ViewBag.creditos = usuario.Creditos;

                if (usuario == null)
                {
                    return HttpNotFound();
                }
                return View(Tuple.Create(usuario, historial.ToList()));
            }
        }


        public ActionResult Detalle(int idSubcaso, bool? costo, string movimiento)
        {
            try
            {
                USUARIO usuario = db.USUARIO.Find(id);
                var creditos = usuario.Creditos;
                ViewBag.Message = "Detalle de identificación";
                if(costo == true && movimiento == "Identificacion")
                {
                    if (creditos - 125 < 0)
                    {
                        return RedirectToAction("Cuenta");
                    }
                }
                using (var context = new Modulo_IdentificacionEntities())
                {
                    usuario = db.USUARIO.Find(id);
                    ViewBag.creditos = usuario.Creditos;
                    SUBCASO subcaso = db.SUBCASO.Find(idSubcaso);
                    var huella = db.LATENTE.Where(l => l.idHuella == subcaso.idHuella).First();
                    var dactilares = db.Huellas_Dactilares.ToList();
                    var palmares = db.Huellas_Palmares.ToList();
                    if (subcaso == null)
                    {
                        throw new Exception();
                    }
                    List<float> scores = new List<float>();
                    Fingerprint fp = new Fingerprint();
                    fp.AsBitmapSource = new BitmapImage(new Uri(huella.PathImagen, UriKind.RelativeOrAbsolute));
                    Person person1 = new Person();
                    person1.Fingerprints.Add(fp);
                    afis.Extract(person1);
                    if (subcaso.IDENTIFICADOR.Contains("palma"))
                    {
                        foreach (var item in palmares)
                        {
                            Fingerprint fpSource = new Fingerprint();
                            fpSource.AsBitmapSource = new BitmapImage(new Uri(item.Path_imagen, UriKind.RelativeOrAbsolute));
                            Person person2 = new Person();
                            person2.Fingerprints.Add(fpSource);
                            afis.Extract(person2);
                            float score = afis.Verify(person1, person2);
                            scores.Add(score);
                        }
                    }
                    else
                    {
                        foreach (var item in dactilares)
                        {
                            Fingerprint fpSource = new Fingerprint();
                            fpSource.AsBitmapSource = new BitmapImage(new Uri(item.Path_imagen, UriKind.RelativeOrAbsolute));
                            Person person2 = new Person();
                            person2.Fingerprints.Add(fpSource);
                            afis.Extract(person2);
                            float score = afis.Verify(person1, person2);
                            scores.Add(score);
                        }
                    }
                    usuario.Creditos = creditos - 125;
                    db.SaveChanges();
                    AgregarAlHistorial(idSubcaso, 1, DateTime.Now);              
                    return View(Tuple.Create(subcaso, scores, palmares, dactilares));
                }
            } catch (Exception e) {
                
                return View("Error");
            }
        }

        public ActionResult GuardarResultados(int idSubcaso)
        {
            USUARIO usuario = db.USUARIO.Find(id);
            var creditos = usuario.Creditos;           
            if (creditos - 150 < 0)
            {
                return RedirectToAction("Cuenta");
            }
            else
            {
                usuario.Creditos = creditos - 150;
                db.SaveChanges();
            }
            
            using (var context = new Modulo_IdentificacionEntities())
            {
                var maxid = db.IDENTIFICACION.OrderByDescending(u => u.idIdentificacion).FirstOrDefault();
                var identificacion = new IDENTIFICACION
                {
                    idIdentificacion = maxid.idIdentificacion + 1,
                    idSubcaso = idSubcaso,
                    Detalle = "Resultados guardados",
                    Fecha_guardado = DateTime.Now
                };
                AgregarAlHistorial(idSubcaso, 4, DateTime.Now);
                context.IDENTIFICACION.Add(identificacion);
                context.SaveChanges();
                return RedirectToAction("Historial", "Home");
            }
        }

        private bool TestGrayScale(Bitmap bmp, int threshold)
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

        private void AgregarAlHistorial(int idSubcaso, int idMovimiento, DateTime fecha)
        {
            using (var context = new Modulo_IdentificacionEntities())
            {
                var maxid = db.HISTORIAL.OrderByDescending(u => u.idHistorial).FirstOrDefault();
                var historial = new HISTORIAL
                {
                    idHistorial = maxid.idHistorial + 1,
                    idUsuario = id,
                    idSubCaso = idSubcaso,
                    idMovimiento = idMovimiento,
                    fecha = fecha
                };
                context.HISTORIAL.Add(historial);
                context.SaveChanges();
            }
        }
    }
}