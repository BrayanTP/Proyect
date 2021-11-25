using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyect.Models;

namespace Proyect.Controllers
{
    public class AsignarController : Controller
    {
        // GET: Asignar
        public ActionResult Index()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.usuario_tipo_usuario.ToList());
            }
        }

        public static string nombreUsuario(int idUsuario)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return db.usuario.Find(idUsuario).nombreUsuario;
            }
        }

        public static string nombreTipoUsuario(int idTipoUsuario)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return db.tipo_usuario.Find(idTipoUsuario).nombre_tipo_usuario;
            }
        }

        public ActionResult listarUsuario()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return PartialView(db.usuario.ToList());
            }
        }
        public ActionResult listarTipoUsuario()
        {
            using (var db = new codigo_policiaEntities1())
            {
                return PartialView(db.tipo_usuario.ToList());
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new codigo_policiaEntities1())
            {
                return View(db.usuario_tipo_usuario.Find(id));
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(usuario_tipo_usuario userRol)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    db.usuario_tipo_usuario.Add(userRol);
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
                var userRolEdit = db.usuario_tipo_usuario.Where(a => a.idusuario == id).FirstOrDefault();
                return View(userRolEdit);
            }
        }

        // POST: TipoUsuario/Edit/5
        [HttpPost]
        public ActionResult Edit(usuario_tipo_usuario userRolEdit)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new codigo_policiaEntities1())
                {
                    var olduserRolEdit = db.usuario_tipo_usuario.Find(userRolEdit.idusuario);
                    olduserRolEdit.idusuario = userRolEdit.idusuario;
                    olduserRolEdit.idtipo_usuario = userRolEdit.idtipo_usuario;
                    olduserRolEdit.funcion = userRolEdit.funcion;
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