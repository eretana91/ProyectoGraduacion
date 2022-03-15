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

            listado.Add(new BibliotecaViewModel {
                url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
                descripcion = "pRUEBA",
                titulo = "FSADFSAD"
            });

            listado.Add(new BibliotecaViewModel
            {
                url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
                descripcion = "pRUEBA",
                titulo = "FSADFSAD"
            });

            listado.Add(new BibliotecaViewModel
            {
                url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
                descripcion = "pRUEBA",
                titulo = "FSADFSAD"
            });

            listado.Add(new BibliotecaViewModel
            {
                url = "https://www.youtube.com/watch?v=5MQGiXgdGYk",
                descripcion = "pRUEBA",
                titulo = "FSADFSAD"
            });

            return View(listado);
        }



        #region GET: Inventario/Create
        public ActionResult Create()
        {
            BibliotecaViewModel bibliotecaViewModel = new BibliotecaViewModel();
            try
            {


                List<SelectListItem> ListaTipoInventario = new List<SelectListItem>();

                var result = context.ListarTipoProducto().ToList();

                foreach (var dato in result)
                {
                    ListaTipoInventario.Add(new SelectListItem
                    {
                        Value = dato.TipoProducto.ToString(),
                        Text = dato.nombreTipoProducto
                    });
                };

                //bibliotecaViewModel.ListaTipoProducto = ListaTipoInventario;

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

            return RedirectToAction("Index", "Inventario");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tituloVideo,urlVideo,descripcionVideo")] BibliotecaViewModel bibliotecaVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    //var resulta = context.(

                    //  bibliotecaVM.titulo,
                    //  bibliotecaVM.url,
                    //  bibliotecaVM.descripcion
                    //   ).FirstOrDefault();


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

            List<SelectListItem> ListaTipoProducto = new List<SelectListItem>();

            var result = context.ListarTipoProducto().ToList();

            foreach (var dato in result)
            {
                ListaTipoProducto.Add(new SelectListItem
                {
                    Value = dato.TipoProducto.ToString(),
                    Text = dato.nombreTipoProducto
                });
            };

            //bibliotecaVM.Lista = ListaTipoProducto;

            return View(bibliotecaVM);
        }
        #endregion
    }
}