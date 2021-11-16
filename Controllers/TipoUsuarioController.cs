using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.tipo_usuario.ToList());
            }
        }

        // GET: TipoUsuario/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities())
            {
                return View(db.tipo_usuario.Find(id));
            }
        }

        // GET: TipoUsuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoUsuario/Create
        [HttpPost]
        public ActionResult Create(tipo_usuario tipoUser)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities())
                {
                    db.tipo_usuario.Add(tipoUser);
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

        // GET: TipoUsuario/Edit/5
        public ActionResult Edit(int id)
        {
            using (var db = new codigo_policiaEntities())
            {
                var tipoUserEdit = db.tipo_usuario.Where(a => a.idtipo_usuario == id).FirstOrDefault();
                return View(tipoUserEdit);
            }
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(tipo_usuario tipoUserEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new codigo_policiaEntities())
                {
                    var oldTipoUser = db.tipo_usuario.Find(tipoUserEdit.idtipo_usuario);
                    oldTipoUser.nombre_tipo_usuario = tipoUserEdit.nombre_tipo_usuario;
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