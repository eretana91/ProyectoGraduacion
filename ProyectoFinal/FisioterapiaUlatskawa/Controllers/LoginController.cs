using FisioterapiaUlatskawa.DataModel;
using FisioterapiaUlatskawa.Models;
using FisioterapiaUlatskawa.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    public class LoginController : Controller
    {
        private readonly Context context;

        EnviarCorreo enviarCorreo = new EnviarCorreo();

        public LoginController()
        {
            context = new Context();
        }
        public ActionResult Index()
        {
            SessionHelper.DestroyUserSession();

            return View();
        }

       

        #region CheckPassword / Valida si la contraseña nueva no es igual a la contraseña anterior
        //public JsonResult CheckPassword(ChangePasswordViewModel password)
        //{
        //    if (password.CurrentPassword != null && password.NewPassword != null)
        //    {
        //        if (password.CurrentPassword != password.NewPassword)
        //        {
        //            return Json(true, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    return Json(false, JsonRequestBehavior.AllowGet);
        //}
        #endregion


        #region GET: Login /  Autenticación del Sistema
        public  ActionResult ValidaCredeciales(UsuariosViewModel users)
        {
            try
            {
                var resultado = context.ConsultaUsuario(users.cedula).FirstOrDefault();

                if (resultado.cedula == null)
                {
                    users.LoginErrorMessage = "Usuario Incorrecto";
                    return View("Index", users);
                }

                if (resultado.cedula == users.cedula && resultado.contrasenna == users.contrasenna)
                {
                    Session["EsAdmin"] = resultado.idTipoUsuario;
                    Session["userID"] = resultado.cedula;
                    SessionHelper.AddUserToSession(1, resultado.cedula);

                    Session.Timeout = 180;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                     users.LoginErrorMessage = "Credenciales incorrectas";
                     return View("Index", users);
                }





            }
            catch (Exception ex)
            {
                users.LoginErrorMessage = ex.InnerException.Message;

                return View("Index", users);
            }
        }
        #endregion




        #region GET: Login / Forgot Password

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            try
            {

                UsuariosViewModel usuariosVM = new UsuariosViewModel();
               

                return View(usuariosVM);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.InnerException.Message;

                return RedirectToAction("Index"); // Redirigir en caso de error
            }

        }

        [HttpPost]
        public ActionResult ForgotPassword(UsuariosViewModel users)
        {
            string msg = "";

            try
            {



                if (users.cedula != "")
                {

                    var usuario = context.ConsultaUsuario(users.cedula).FirstOrDefault();


                    if (usuario != null)
                    {
                        //Generar nueva contraseña 
                        int longitud = 7;
                        Guid miGuid = Guid.NewGuid();
                        string token = Convert.ToBase64String(miGuid.ToByteArray());
                        token = token.Replace("=", "").Replace("+", "");


                        usuario.contrasenna = token;

                        var result = context.ActualizarUsuarios(
                            usuario.cedula,
                            usuario.nombre,
                            usuario.apellidos,
                            usuario.telefono,
                            usuario.email,
                            usuario.contrasenna,
                            usuario.idTipoUsuario
                            ).FirstOrDefault();  
                        
                            enviarCorreo.EnviadorCorreo(usuario.contrasenna, usuario.email);
                            users.LoginErrorMessage = "Correo enviado correctamente";                        
                        
                    }
                   

                }
                else
                {
                    users.LoginErrorMessage = "La cédula es requerida";
                }


            }
            catch (Exception ex)
            {

                users.LoginErrorMessage = ex.Message;
            }


            return View(users);
        }
        #endregion

        //#region Autherize / Autenticación del Sistema
        ////[HttpPost]
        //public ActionResult AutenticarAsync(string pIdCompany, string pIdUser)
        ////   public ActionResult Autherize(UsuariosViewModel usuarios)
        //{


        //    try
        //    {
        //        var resultado = await LoginBLL.QueryListUserCompanyBLL(_idCompany, _idUser, System.Web.HttpContext.Current);

        //        Session["empresaID"] = resultado.User.idCompany;
        //        Session["NombreEmpresa"] = resultado.User.company;

        //        SessionHelper.AddUserToSession(Convert.ToInt32(_idCompany), _idUser);


        //        return RedirectToAction("Index", "Home");

        //    }
        //    catch (Exception ex)
        //    {
        //        return View("Index");
        //    }

        //}
        //#endregion

        #region TimeoutRedirect / Funcion para Controlar la Session, y redireccionar al login cuando expira.
        public ActionResult TimeoutRedirect(UsuariosViewModel usuarios)
        {
            SessionHelper.DestroyUserSession();

            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();

            usuarios.LoginErrorMessage = "Su sesión ha expirado, por favor vuelva a iniciar sesión.";

            return View("Index", usuarios);
        }
        #endregion

        #region LogOut / Limpieza y Cierre de Session
        public ActionResult LogOut()
        {
            try
            {
                SessionHelper.DestroyUserSession();

                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
                Response.Cache.SetNoStore();

                Session.Clear();
                Session.Abandon();
                Session.RemoveAll();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.InnerException.Message;

                return RedirectToAction("Index");
            }
        }
        #endregion


    }
}