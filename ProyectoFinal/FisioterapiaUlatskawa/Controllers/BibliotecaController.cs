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
    [Authorize]
    [SessionExpireFilter]
    public class BibliotecaController : Controller
    {


        private readonly Context context;

        public BibliotecaController()
        {
            context = new Context();
        }

        // GET: Biblioteca
        public ActionResult Index()
        {

            List<BibliotecaViewModel> listado = new List<BibliotecaViewModel>();

            try
            {

                var result = context.ListarVideos().ToList();

                foreach (var dato in result)
                {
                    listado.Add(new BibliotecaViewModel
                    {
                        titulo = dato.tituloVideo,
                        url = dato.urlVideo,
                        descripcion = dato.descripcionVideo,
                    });
                };



                return View(listado);
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

                return View(listado);
            }

            //listado.Add(new BibliotecaViewModel {
            //    url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
            //    descripcion = "Prueba",
            //    titulo = "Relajación de músculos"
            //});

            //listado.Add(new BibliotecaViewModel
            //{
            //    url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
            //    descripcion = "Prueba",
            //    titulo = "Relajación de músculos"
            //});

            //listado.Add(new BibliotecaViewModel
            //{
            //    url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
            //    descripcion = "Prueba",
            //    titulo = "Relajación de músculos"
            //});

            //listado.Add(new BibliotecaViewModel
            //{
            //    url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
            //    descripcion = "Prueba",
            //    titulo = "Relajación de músculos"
            //});

            //return View(listado);
        }



        #region GET: Inventario/Create
        public ActionResult Create()
        {
            BibliotecaViewModel bibliotecaViewModel = new BibliotecaViewModel();
            try
            {


               List<SelectListItem> Lista = new List<SelectListItem>();

                var result = context.ListarVideos().ToList();

            //    foreach (var dato in result)
            //    {
            //        ListaTipoInventario.Add(new SelectListItem
            //        {
            //            Value = dato.TipoProducto.ToString(),
            //            Text = dato.nombreTipoProducto
            //        });
            //    };

            //    //bibliotecaViewModel.ListaTipoProducto = ListaTipoInventario;

            return View(bibliotecaViewModel);
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

            return RedirectToAction("Index", "Biblioteca");
        }


        [HttpPost]
     
        public ActionResult Create([Bind(Include = "url,titulo,descripcion")] BibliotecaViewModel bibliotecaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var resulta = context.InsertarVideo(

                      bibliotecaVM.titulo,
                      bibliotecaVM.url,
                      bibliotecaVM.descripcion
                       ).FirstOrDefault();


                    TempData["Message"] = "Video Insertado correctamente";

                    return RedirectToAction("Index", "Biblioteca");
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

            //List<SelectListItem> ListaTipoProducto = new List<SelectListItem>();

            //var result = context.ListarTipoProducto().ToList();

            //foreach (var dato in result)
            //{
            //    ListaTipoProducto.Add(new SelectListItem
            //    {
            //        Value = dato.TipoProducto.ToString(),
            //        Text = dato.nombreTipoProducto
            //    });
            //};

            //bibliotecaVM.Lista = ListaTipoProducto;

            return View(bibliotecaVM);
        }
        #endregion


        #region GET: Usuarios/Edit
        public ActionResult Edit(string pTituloVideo)
        {


            try
            {

                //List<SelectListItem> ListaTipoUsuario = new List<SelectListItem>();

                //ListaTipoUsuario.Add(new SelectListItem
                //{
                //    Value = "1",
                //    Text = "Administrador"
                //});

                //ListaTipoUsuario.Add(new SelectListItem
                //{
                //    Value = "2",
                //    Text = "Limitado"
                //});




                var resultado = context.ConsultaVideo(pTituloVideo).FirstOrDefault();

                BibliotecaViewModel videoVM = new BibliotecaViewModel
                {
                    idVideo = resultado.idVideo,
                    titulo = resultado.tituloVideo,
                    url = resultado.urlVideo,
                    descripcion = resultado.descripcionVideo

                };

                return View(videoVM);
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

                return RedirectToAction("Index", "Biblioteca");
            }
        }

        // POST: Clases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVideo,url,titulo,descripcion")] BibliotecaViewModel bibliotecaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {


                    var result = context.ActualizarVideo(
                        bibliotecaVM.idVideo,
                        bibliotecaVM.titulo,
                        bibliotecaVM.url,
                        bibliotecaVM.descripcion
                        ).FirstOrDefault();

                    TempData["Message"] = "Video modificado correctamente";




                    return RedirectToAction("Index", "Biblioteca");
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

            return View(bibliotecaVM);
        }
        #endregion
    }
}