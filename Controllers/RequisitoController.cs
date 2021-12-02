using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class RequisitoController : Controller
    {
        // GET: Requisito
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.requisitos.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.requisitos.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(requisitos require)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    db.requisitos.Add(require);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                var requisitoEdit = db.requisitos.Where(a => a.idrequisitos == id).FirstOrDefault();
                return View(requisitoEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(requisitos requireEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    var oldRequire = db.requisitos.Find(requireEdit.idrequisitos);
                    oldRequire.nombre_requisitos = requireEdit.nombre_requisitos;
                    oldRequire.descripcion_requisitos= requireEdit.descripcion_requisitos;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error {ex}");
                return View();
            }
        }
    }
}