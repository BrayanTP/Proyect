using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class TituloController : Controller
    {
        // GET: Titulo
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.titulo.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.titulo.Find(id));
            }
        }

        public static string nombreLibro(int idLibro)
        {
            using (var db = new codigo_policiaEntities())
            {
                return db.libro.Find(idLibro).nombre_libro;
            }
        }

        public ActionResult listarLibro()
        {
            using (var db = new codigo_policiaEntities())
            {
                return PartialView(db.libro.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(titulo title)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using(var db = new codigo_policiaEntities())
                {
                    db.titulo.Add(title);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using(var db = new codigo_policiaEntities())
            {
                var tituloEdit = db.titulo.Where(a => a.idtitulo == id).FirstOrDefault();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit (titulo titleEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities())
                {
                    var oldTitle = db.titulo.Find(titleEdit.idtitulo);
                    oldTitle.nombre_titulo = titleEdit.nombre_titulo;
                    oldTitle.idlibro = titleEdit.idlibro;
                    db.SaveChanges();

                    return RedirectToAction("Index"); 
                }
            }catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }
    }
}