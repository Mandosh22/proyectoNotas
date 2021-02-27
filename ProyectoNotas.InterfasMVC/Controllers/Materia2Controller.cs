using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;


namespace proyectoNotas.InterfasMVC.Controllers
{
    public class Materia2Controller : Controller
    {

        MateriaBL materiaBL = new MateriaBL();
        // GET: Materia2
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Obtener()
        {
            return Json(materiaBL.ObtenerMaterias(), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [HttpPost]
        public JsonResult Agregar(Materia pMateria)
        {
            return Json(materiaBL.InsertarMateria(pMateria), JsonRequestBehavior.AllowGet);
        }
        //ACCION QUE PERMITE Modificar un registro
        [HttpPost]
        public JsonResult Modificar(Materia pMateria)
        {
            return Json(materiaBL.ModificarMateria(pMateria), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(materiaBL.EliminarMateria(pId));
        }

    }
}