using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;

namespace proyectoNotas.InterfasMVC.Controllers
{
    public class NotaController : Controller
    {

        NotaBL notaBL = new NotaBL();
        // GET: Nota
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        //accion para devolver los registros almacenados del profesor que ha ingresado
        [Authorize]
        public JsonResult Obtener(int pId)
        {
            return Json(notaBL.ObtenerNotas(pId), JsonRequestBehavior.AllowGet);
        }



        [Authorize]
        //accio que permite leer el detalle de un registro
        public JsonResult ObtenerPorId(int pId)
        {
            return Json(notaBL.ObtenerNotaPorId(pId), JsonRequestBehavior.AllowGet);
        }

        //accion que permite agregar un nuevo registro
        [Authorize]
        [HttpPost]
        public JsonResult Agregar(Nota pNota)
        {
            return Json(notaBL.InsertarNota(pNota), JsonRequestBehavior.AllowGet);
        }

        //ACCION QUE PERMITE Modificar un registro
        [Authorize]
        [HttpPost]
        public JsonResult Modificar(Nota pNota)
        {
            return Json(notaBL.ModificarNota(pNota), JsonRequestBehavior.AllowGet);
        }

        //Acccion eliminar registro
        [Authorize]
        [HttpPost]
        public JsonResult Eliminar(int pId)
        {
            return Json(notaBL.EliminarNota(pId));
        }

    }
}