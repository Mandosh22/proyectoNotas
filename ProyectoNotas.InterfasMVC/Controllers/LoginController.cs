using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ProyectoNotasEntidadesDeNegocios;
using ProyectoNotas.LogicaDeNegocio;
using System.Web.Security;


namespace proyectoNotas.InterfasMVC.Controllers
{
    public class LoginController : Controller
    {
        ProfesorBL profesorBL = new ProfesorBL();
        AdministradorBL administradorBL = new AdministradorBL();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Login(Profesor pProfesor)
        {
            Profesor profesor = profesorBL.Login(pProfesor);

            if(profesor != null){

                FormsAuthentication.SetAuthCookie(profesor.UserName, false);
                Session["user"] = profesor;
                return Json(profesor, JsonRequestBehavior.AllowGet);

            }
            else {

                return null;
            }
        }




        [HttpPost]
        public JsonResult LoginAdmin(Administrador pAdministrador)
        {
            Administrador administrador = administradorBL.Login(pAdministrador);

            if (administrador != null)
            {

                FormsAuthentication.SetAuthCookie(administrador.Username, false);
                Session["user"] = administrador;
                return Json(administrador, JsonRequestBehavior.AllowGet);

            }
            else
            {

                return null;
            }
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");

        }


        public ActionResult Perfil()
        {
            return View();
        }

    }
}