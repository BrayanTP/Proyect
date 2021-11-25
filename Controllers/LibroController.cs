using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.libro.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.libro.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(libro book)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    db.libro.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            } catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                var libroEdit = db.libro.Where(a => a.idlibro == id).FirstOrDefault();
                return View(libroEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit (libro bookEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db =new codigo_policiaEntities1())
                {
                    var oldLibro = db.libro.Find(bookEdit.idlibro);
                    oldLibro.nombre_libro = bookEdit.nombre_libro;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            } catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }
    }

}