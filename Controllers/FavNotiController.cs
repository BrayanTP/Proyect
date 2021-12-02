using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class FavNotiController : Controller
    {
        // GET: FavNoti
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.usuario_noticia.ToList());
            }
        }

        public static string nombreUsuario(int idUsuario)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return db.usuario.Find(idUsuario).nombreUsuario;
            }
        }

        public static string nombreNoticia(int idNoticia)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return db.noticia.Find(idNoticia).nombre_noticia;
            }
        }

        public ActionResult listarUsuario()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return PartialView(db.usuario.ToList());
            }
        }

        public ActionResult listarNoticia()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return PartialView(db.noticia.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.usuario_noticia.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(usuario_noticia userNoti)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    db.usuario_noticia.Add(userNoti);
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
                var userNotiEdit = db.usuario_noticia.Where(a => a.id_usuario == id).FirstOrDefault();
                return View(userNotiEdit);
            }
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(usuario_noticia userNotiEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    var olduserNotiEdit = db.usuario_noticia.Find(userNotiEdit.id_usuario);
                    olduserNotiEdit.id_usuario = userNotiEdit.id_usuario;
                    olduserNotiEdit.id_noticia = userNotiEdit.id_noticia;
                    olduserNotiEdit.fecha_modificado = userNotiEdit.fecha_modificado;
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