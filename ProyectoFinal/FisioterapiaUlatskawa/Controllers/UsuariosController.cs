
using FisioterapiaUlatskawa.DataModel;
using FisioterapiaUlatskawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    //[Authorize]

    public class UsuariosController : Controller
    {
        private readonly Context context;

        public UsuariosController()
        {
            context = new Context();
        }


        /******************************************************/
        // Metodos CRUD
        #region GET: Usuarios
        public ActionResult Index()
        {

            List<UsuariosViewModel> ListUsuarios = new List<UsuariosViewModel>();

            try
            {  

                var result = context.ListarUsuarios().ToList();

                foreach (var dato in result)
                {
                    ListUsuarios.Add(new UsuariosViewModel
                    {
                        cedula = dato.cedula,
                        nombre = dato.nombre,
                        apellidos = dato.apellidos,
                        telefono = dato.telefono,
                        email = dato.email,
                        contrasenna = dato.contrasenna,
                        idTipoUsuario = dato.idTipoUsuario,
                    });
                };

               

                return View(ListUsuarios);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    TempData["ErrorMessage"] = ex.InnerException.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = ex.Message;
                }

                return View(ListUsuarios);
            }
        }
        #endregion

        #region GET: Usuarios/Create
        public ActionResult Create()
        {
            UsuariosViewModel usuarios = new UsuariosViewModel();
            try
            {
                List<SelectListItem> ListaTipoUsuario = new List<SelectListItem>();               

                ListaTipoUsuario.Add(new SelectListItem
                    {
                        Value = "1",
                        Text = "Administrador"
                    });

                ListaTipoUsuario.Add(new SelectListItem
                {
                    Value = "2",
                    Text = "Limitado"
                });


                usuarios.ListaTipoUsuario = ListaTipoUsuario;

                return View(usuarios);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    TempData["ErrorMessage"] = ex.InnerException.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = ex.Message;
                }
            }

            return RedirectToAction("Index", "Usuarios");
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,nombre,apellidos,telefono,email,contrasenna,idTipoUsuario")] UsuariosViewModel usuariosVM)
        {
            if (ModelState.IsValid)
            {
                try
                {                  

                     var result = context.InsertarUsuario(
                        usuariosVM.cedula,
                        usuariosVM.nombre,
                        usuariosVM.apellidos,
                        usuariosVM.telefono,
                        usuariosVM.email,
                        usuariosVM.contrasenna,
                        usuariosVM.idTipoUsuario
                        ).FirstOrDefault();

                    TempData["Message"] = "Usuario Insertado correctamente";

                    return RedirectToAction("Index", "Usuarios");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        TempData["ErrorMessage"] = ex.InnerException.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = ex.Message;
                    }
                }
            }
            else
            {
                

                var error = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .FirstOrDefault(); 

                TempData["ErrorMessage"] = error[0].ErrorMessage;


            }


            return View(usuariosVM);
        }
        #endregion

        #region GET: Usuarios/Edit
        public ActionResult Edit(string pIdUsuario)
        {


            try
            {

                List<SelectListItem> ListaTipoUsuario = new List<SelectListItem>();

                ListaTipoUsuario.Add(new SelectListItem
                {
                    Value = "1",
                    Text = "Administrador"
                });

                ListaTipoUsuario.Add(new SelectListItem
                {
                    Value = "2",
                    Text = "Limitado"
                });


                

                var resultado = context.ConsultaUsuario(pIdUsuario).FirstOrDefault();

                UsuariosViewModel usuarioVM = new UsuariosViewModel
                {
                    apellidos = resultado.apellidos,
                    cedula = resultado.cedula,
                    contrasenna = resultado.contrasenna,
                    email = resultado.email,
                    nombre = resultado.nombre,
                    telefono = resultado.telefono,
                    idTipoUsuario= resultado.idTipoUsuario,
                    ListaTipoUsuario = ListaTipoUsuario

            };

                return View(usuarioVM);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    TempData["ErrorMessage"] = ex.InnerException.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = ex.Message;
                }

                return RedirectToAction("Index", "Usuarios");
            }
        }

        // POST: Clases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cedula,nombre,apellidos,telefono,email,contrasenna,idTipoUsuario")] UsuariosViewModel usuariosVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    

                    var result = context.ActualizarUsuarios(
                        usuariosVM.cedula,
                        usuariosVM.nombre,
                        usuariosVM.apellidos,
                        usuariosVM.telefono,
                        usuariosVM.email,
                        usuariosVM.contrasenna,
                        usuariosVM.idTipoUsuario
                        ).FirstOrDefault();

                    TempData["Message"] = "Usuario modificado correctamente";

                   


                    return RedirectToAction("Index", "Usuarios");
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        TempData["ErrorMessage"] = ex.InnerException.Message;
                    }
                    else
                    {
                        TempData["ErrorMessage"] = ex.Message;
                    }
                }
            }

            return View(usuariosVM);
        }
        #endregion

        #region GET: Clases/Details
        public ActionResult Details(string pIdUsuario)
        {
            try
            {

                var resultado = context.ConsultaUsuario(pIdUsuario).FirstOrDefault();

                UsuariosViewModel usuarioVM = new UsuariosViewModel
                {
                    apellidos = resultado.apellidos,
                    cedula = resultado.cedula,
                    contrasenna = resultado.contrasenna,
                    email = resultado.email,
                    nombre = resultado.nombre,
                    telefono = resultado.telefono,
                    idTipoUsuario = resultado.idTipoUsuario

                };

                return View(usuarioVM);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    TempData["ErrorMessage"] = ex.InnerException.Message;
                }
                else
                {
                    TempData["ErrorMessage"] = ex.Message;
                }

                return RedirectToAction("Index", "Usuarios");
            }
        }
        #endregion

    }
}