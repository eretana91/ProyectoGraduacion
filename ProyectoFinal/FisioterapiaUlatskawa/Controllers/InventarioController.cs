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
    public class InventarioController : Controller
    {
        private readonly Context context;

        public InventarioController()
        {
            context = new Context();
        }

        public ActionResult Index()
        {
            

            List<InventariosViewModel> ListInventarios = new List<InventariosViewModel>();

            try
            {

                var result = context.ListarProdcutos().ToList();

                foreach (var dato in result)
                {
                    ListInventarios.Add(new InventariosViewModel
                    {
                        idProducto = dato.idProducto,
                        tipoProducto= dato.tipoProducto,
                        codigoBarras = dato.codigoBarras,
                        //nombreProducto= dato.nombreProducto,
                        precio = dato.precio,
                        cantidad = dato.cantidad,
                        fechaExpiracion = dato.fechaExpiracion,
                        notas = dato.notas,
                        nombreProducto = dato.nombreDelProducto
                    });
                };



                return View(ListInventarios);
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

                return View(ListInventarios);
            }
        }



        #region GET: Inventario/Create
        public ActionResult Create()
        {
            InventariosViewModel inventarioViewModel = new InventariosViewModel();
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

                inventarioViewModel.ListaTipoProducto = ListaTipoInventario;

                return View(inventarioViewModel);
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
        public ActionResult Create([Bind(Include = "tipoProducto,nombreProducto,codigoBarras,precio,cantidad, fechaExpiracion, notas")] InventariosViewModel inventariosVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var resulta = context.InsertarProducto(
                        
                      inventariosVM.tipoProducto,
                      inventariosVM.nombreProducto,
                      inventariosVM.codigoBarras,
                      inventariosVM.precio,
                      inventariosVM.cantidad,
                      inventariosVM.fechaExpiracion,
                      inventariosVM.notas
                       ).FirstOrDefault();


                    TempData["Message"] = "Producto Insertado correctamente";

                    return RedirectToAction("Index", "Inventario");
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

            inventariosVM.ListaTipoProducto = ListaTipoProducto;

            return View(inventariosVM);
        }
        #endregion



        #region GET: Inventario/Edit
        public ActionResult Edit(string pCodigoBarras)
        {
            try
            {

                var resultado = context.ConsultaProducto(pCodigoBarras).FirstOrDefault();


                List<SelectListItem> ListaTipoProductos = new List<SelectListItem>();

                var result = context.ListarTipoProducto().ToList();

                foreach (var dato in result)
                {
                    ListaTipoProductos.Add(new SelectListItem
                    {
                        Value = dato.TipoProducto.ToString(),
                        Text = dato.nombreTipoProducto
                    });
                };



                InventariosViewModel inventariosVM = new InventariosViewModel
                {
                    idProducto = resultado.idProducto,
                    tipoProducto = resultado.tipoProducto,
                    nombreProducto = resultado.nombreProducto,
                    codigoBarras = resultado.codigoBarras,
                    precio = resultado.precio,
                    cantidad = resultado.cantidad,
                    fechaExpiracion = resultado.fechaExpiracion,
                    notas = resultado.notas,
                    ListaTipoProducto = ListaTipoProductos
                };

                return View(inventariosVM);
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

                return RedirectToAction("Index", "Inventario");
            }
        }

        // POST: Clases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,Producto, tipoProducto,nombreProducto,codigoBarras,precio,cantidad,fechaExpiracion,notas")] InventariosViewModel inventariosVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var results = context.ActualizarProductos(
                       inventariosVM.idProducto,
                        inventariosVM.tipoProducto,
                        inventariosVM.nombreProducto,
                        inventariosVM.codigoBarras,
                        inventariosVM.precio,
                        inventariosVM.cantidad,
                        inventariosVM.fechaExpiracion,
                        inventariosVM.notas
                        ).FirstOrDefault();

                    TempData["Message"] = "Producto modificado correctamente";

                    return RedirectToAction("Index", "Inventario", new { pCodigoBarras = Session["pCodigoBarras"]});
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
            inventariosVM.ListaTipoProducto = ListaTipoProducto;

            return View(inventariosVM);
        }
        #endregion

        #region GET: Clases/Details
        public ActionResult Details(string pCodigoBarras)
        {
            try
            {

                var resultado = context.ConsultaProducto(pCodigoBarras).FirstOrDefault();

                InventariosViewModel inventariosVM = new InventariosViewModel
                {
                    idProducto = resultado.idProducto,
                    tipoProducto = resultado.tipoProducto,
                    nombreProducto = resultado.nombreProducto,
                    codigoBarras = resultado.codigoBarras,
                    precio = resultado.precio,
                    cantidad = resultado.cantidad,
                    fechaExpiracion = resultado.fechaExpiracion,
                    notas = resultado.notas

                };

                return View(inventariosVM);
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

                return RedirectToAction("Index", "Inventario", new { pCodigoBarras = Session["pCodigoBarras"] });
            }
            #endregion

        }



    }
}