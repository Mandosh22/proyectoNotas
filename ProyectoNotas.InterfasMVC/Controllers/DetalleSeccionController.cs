using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;

namespace proyectoNotas.InterfasMVC.Controllers
{
    public class DetalleSeccionController : Controller
    {
        DetalleSeccionBL detalleseccionBL = new DetalleSeccionBL();
        // GET: DetalleSeccion
        public ActionResult Index()
        {
            return View();
        }

        //accion para devolver los registros almacenados
        public JsonResult Obtener()
        {
            return Json(detalleseccionBL.ObtenerDetalleSeccion(), JsonRequestBehavior.AllowGet);
        }

        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(detalleseccionBL.ObtenerPorId(pId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerPorSeccionPorProfesor(int pId)
        {
            return Json(detalleseccionBL.ObtenerSeccionesPorProfesor(pId), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult Agregar(DetalleSeccion pDetalleSeccion)
        {
            return Json(detalleseccionBL.InsertarDetalleSeccion(pDetalleSeccion), JsonRequestBehavior.AllowGet);
        }

        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(DetalleSeccion pDetalleSeccion)
        {
            return Json(detalleseccionBL.ModificarDetalleSeccion(pDetalleSeccion), JsonRequestBehavior.AllowGet);
        }



        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(detalleseccionBL.EliminarDetalleSeccion(pId));
        }

    }
}