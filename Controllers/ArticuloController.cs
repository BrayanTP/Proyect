using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class ArticuloController : Controller
    {
        // GET: Articulo
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.articulo.ToList());
            }
        }

        public static string nombreTitulo(int idtitulo)
        {
            using (var db = new codigo_policiaEntities())
            {
                return db.titulo.Find(idtitulo).nombre_titulo;
            }
        }

        public ActionResult listarTitulo()
        {
            using (var db = new codigo_policiaEntities())
            {
                return PartialView(db.titulo.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.articulo.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(articulo article)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities())
                {
                    db.articulo.Add(article);
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
            using (var db = new codigo_policiaEntities())
            {
                var articuloEdit = db.articulo.Where(a => a.idarticulo == id).FirstOrDefault();
                return View(articuloEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(articulo articleEdit)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities())
                {
                    var oldarticulo = db.articulo.Find(articleEdit.idarticulo);
                    oldarticulo.nombre_articulo = articleEdit.nombre_articulo;
                    oldarticulo.texto_articulo = articleEdit.texto_articulo;
                    oldarticulo.estado = articleEdit.estado;
                    oldarticulo.idtitulo = articleEdit.idtitulo;
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