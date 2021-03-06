using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;

namespace proyectoNotas.InterfasMVC.Controllers
{
    public class AlumnoController : Controller
    {
        AlumnoBL alumnoBL = new AlumnoBL();
        // GET: Administrador
        public ActionResult Index()
        {
            return View();
        }
        //accion para devolver los registros almacenados
        public JsonResult Obtener()
        {
            return Json(alumnoBL.ObtenerAlumnos(), JsonRequestBehavior.AllowGet);
        }

        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(alumnoBL.ObtenerAlumnosPorId(pId), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerPorS(int pId)
        {
            return Json(alumnoBL.ObtenerAlumnosPorSeccion(pId), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [HttpPost]
        public JsonResult Agregar(Alumno pAlumno)
        {
            return Json(alumnoBL.InsertarAlumno(pAlumno), JsonRequestBehavior.AllowGet);
        }
        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(Alumno pAlumno)
        {
            return Json(alumnoBL.ModificarAlumno(pAlumno), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(alumnoBL.EliminarAlumno(pId));
        }
    }
}