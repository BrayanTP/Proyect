using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class NoticiaController : Controller
    {
        // GET: Noticia
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.noticia.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.noticia.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(noticia news)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    db.noticia.Add(news);
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
                var noticiaEdit = db.noticia.Where(a => a.idnoticia == id).FirstOrDefault();
                return View(noticiaEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(noticia newsEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    var oldNew = db.noticia.Find(newsEdit.idnoticia);
                    oldNew.nombre_noticia = newsEdit.nombre_noticia;
                    oldNew.texto_notica = newsEdit.texto_notica;
                    oldNew.fecha = newsEdit.fecha;
                    oldNew.estado = newsEdit.estado;
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