using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;

namespace proyectoNotas.InterfasMVC.Controllers
{
    public class SeccionController : Controller
    {
        SeccionBL seccionBL = new SeccionBL();

        // accion que muestra la vista
        public ActionResult Index()
        {
            return View();
        }

        //accion para devolver los registros almacenados
        public JsonResult Obtener()
        {
            return Json(seccionBL.ObtenerSeccion(), JsonRequestBehavior.AllowGet);
        }

        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(seccionBL.ObtenerPorId(pId), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [HttpPost]
        public JsonResult Agregar(Seccion pSeccion)
        {
            return Json(seccionBL.InsertarSeccion(pSeccion), JsonRequestBehavior.AllowGet);
        }
        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(Seccion pSeccion)
        {
            return Json(seccionBL.ModificaSeccion(pSeccion), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(seccionBL.EliminarSeccion(pId));
        }
    }
}