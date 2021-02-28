using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;


namespace proyectoNotas.InterfasMVC.Controllers
{
    public class ProfesorController : Controller
    {

        ProfesorBL profesorBL = new ProfesorBL();
        // GET: Profesor
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Obtener()
        {
            return Json(profesorBL.ObtenerProfesor(), JsonRequestBehavior.AllowGet);
        }

        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(profesorBL.ObtenerPorId(pId), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [HttpPost]
        public JsonResult Agregar(Profesor pProfesor)
        {
            return Json(profesorBL.InsertarProfesor(pProfesor), JsonRequestBehavior.AllowGet);
        }

        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(Profesor pProfesor)
        {
            return Json(profesorBL.ModificarProfesor(pProfesor), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(profesorBL.EliminarProfesor(pId));
        }



    }
}