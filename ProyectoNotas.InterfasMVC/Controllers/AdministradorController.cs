using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;

namespace proyectoNotas.InterfasMVC.Controllers
{
    public class AdministradorController : Controller
    {
        AdministradorBL administradorBL = new AdministradorBL();
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }
        //accion para devolver los registros almacenados
        public JsonResult Obtener()
        {
            return Json(administradorBL.obtenerAdminstrador(), JsonRequestBehavior.AllowGet);
        }

        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(administradorBL.ObtenerAdministradorPorId(pId), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [HttpPost]
        public JsonResult Agregar(Administrador pAdministrador)
        {
            return Json(administradorBL.InsertarAdministrador(pAdministrador), JsonRequestBehavior.AllowGet);
        }
        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(Administrador pAdministrador)
        {
            return Json(administradorBL.ModificarAdministrador(pAdministrador), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(administradorBL.EliminarAdministardor(pId));
        }
    }
}