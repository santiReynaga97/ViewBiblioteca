using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ViewBiblioteca.Controllers
{
    public class LibroController : Controller
    {

        Logica.LibroLog dao = new Logica.LibroLog();

        public ActionResult VistaLibros()
        {

            return View(dao.ListaLibros());

        }
        // GET: Libro
        public ActionResult AgregarLibro()
        {


            return View();

        }
        [HttpPost]
        public ActionResult AgregarLibro(Entidad.Libro libro1)
        {
            var dato = dao.Registrar(libro1);
            if (dato == false)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            else
                return RedirectToAction("VistaLibros");

        }

        public ActionResult ActualizarLibro(int id)
        {

            return View(dao.TrarLibro(id));

        }
        [HttpPost]
        public ActionResult ActualizarLibro(Entidad.Libro libro1)
        {
            var dato = dao.Actualizar(libro1);
            if (dato == false)
            {
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/Error.cshtml");
            }
            else
                return RedirectToAction("VistaLibros");
        }

        public ActionResult EliminarLibro(int id)
        {
            var r = dao.Eliminar(id);

            if (!r)
            {
                // Podemos validar para mostrar un mensaje personalizado, por ahora el aplicativo se caera por el throw que hay en nuestra capa DAL
                ViewBag.Mensaje = "Ocurrio un error inesperado";
                return View("~/Views/Shared/_Mensajes.cshtml");
            }

            return Redirect("~/");
        }


    }
}