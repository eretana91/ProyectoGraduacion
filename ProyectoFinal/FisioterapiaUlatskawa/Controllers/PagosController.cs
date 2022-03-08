using FisioterapiaUlatskawa.DataModel;
using FisioterapiaUlatskawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    public class PagosController : Controller
    {
        private readonly Context context;

        public PagosController()
        {
            context = new Context();
        }


        /******************************************************/
        // Metodos CRUD
        #region GET: Pagos
        public ActionResult Index(string pCedula)
        {
            Session["pCedula"] = pCedula;

            List<PagosViewModel> ListPagos = new List<PagosViewModel>();

            try
            {

                var result = context.ListarMisPagos(pCedula).ToList();

                foreach (var dato in result)
                {
                    ListPagos.Add(new PagosViewModel
                    {
                        idPago = dato.idPago,
                        tipoPago = dato.tipoPago,
                        monto = dato.monto,
                        banco = dato.banco,
                        cedula = dato.cedula,
                        fechaPago = dato.fechaPago,
                        notas = dato.notas,
                        nombrePago = dato.nombrePago
                    });
                };



                return View(ListPagos);
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

                return View(ListPagos);
            }
        }
        #endregion

        #region GET: Usuarios/Create
        public ActionResult Create(string pCedula)
        {
            PagosViewModel pagosViewModel = new PagosViewModel();
            try
            {
                Session["pCedula"] = pCedula;

                pagosViewModel.cedula = pCedula;

                List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();

                var result = context.ListarTipoPagos().ToList();

                foreach (var dato in result)
                {
                    ListaTipoPagos.Add(new SelectListItem
                    {
                        Value = dato.tipoPago.ToString(),
                        Text = dato.nombrePago
                    });
                };

                pagosViewModel.ListaTipoPago = ListaTipoPagos;

                return View(pagosViewModel);
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

            return RedirectToAction("Index", "Pagos");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tipoPago,monto,banco,cedula,notas")] PagosViewModel pagosVM)
        {
                if (ModelState.IsValid)
            {
                try
                {

                    var resulta = context.InsertarPagos(
                      pagosVM.tipoPago,
                      pagosVM.monto,
                      pagosVM.banco,
                      pagosVM.cedula,
                      pagosVM.notas
                       ).FirstOrDefault();


                    TempData["Message"] = "Pago Insertado correctamente";

                    return RedirectToAction("Index", "Pagos", new {pCedula = pagosVM.cedula});
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

            List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();

            var result = context.ListarTipoPagos().ToList();

            foreach (var dato in result)
            {
                ListaTipoPagos.Add(new SelectListItem
                {
                    Value = dato.tipoPago.ToString(),
                    Text = dato.nombrePago
                });
            };

            pagosVM.ListaTipoPago = ListaTipoPagos;

            return View(pagosVM);
        }
        #endregion

        #region GET: Usuarios/Edit
        public ActionResult Edit(int pIdPago)
        {
            try
            {

                var resultado = context.ConsultarPagos(pIdPago).FirstOrDefault();


                List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();

                var result = context.ListarTipoPagos().ToList();

                foreach (var dato in result)
                {
                    ListaTipoPagos.Add(new SelectListItem
                    {
                        Value = dato.tipoPago.ToString(),
                        Text = dato.nombrePago
                    });
                };

                

                PagosViewModel pagosVM = new PagosViewModel
                {
                    idPago = resultado.idPago,
                    tipoPago = resultado.tipoPago,
                    monto = resultado.monto,
                    banco = resultado.banco,
                    cedula = resultado.cedula,
                    fechaPago = resultado.fechaPago,
                    notas = resultado.notas,
                    ListaTipoPago = ListaTipoPagos
                };

                return View(pagosVM);
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

                return RedirectToAction("Index", "Pagos", new { pCedula = Session["pCedula"] as string });
            }
        }

        // POST: Clases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPago,tipoPago,monto,banco,cedula,notas")] PagosViewModel pagosVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var results = context.ActualizarPagos(
                        pagosVM.idPago,
                        pagosVM.tipoPago,
                        pagosVM.monto,
                        pagosVM.banco,
                        pagosVM.cedula,
                        pagosVM.notas
                        ).FirstOrDefault();

                    TempData["Message"] = "Pago modificado correctamente";

                    return RedirectToAction("Index", "Pagos", new { pCedula = Session["pCedula"] as string });
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

            List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();
            var result = context.ListarTipoPagos().ToList();
            foreach (var dato in result)
            {
                ListaTipoPagos.Add(new SelectListItem
                {
                    Value = dato.tipoPago.ToString(),
                    Text = dato.nombrePago
                });
            };
            pagosVM.ListaTipoPago = ListaTipoPagos;

            return View(pagosVM);
        }
        #endregion

        #region GET: Clases/Details
        public ActionResult Details(int pIdPago)
        {
            try
            {

                var resultado = context.ConsultarPagos(pIdPago).FirstOrDefault();

                PagosViewModel pagosVM = new PagosViewModel
                {
                    idPago = resultado.idPago,
                    tipoPago = resultado.tipoPago,
                    monto = resultado.monto,
                    banco = resultado.banco,
                    cedula = resultado.cedula,
                    fechaPago = resultado.fechaPago,
                    notas = resultado.notas
                };

                return View(pagosVM);
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

                return RedirectToAction("Index", "Pagos", new { pCedula = Session["pCedula"] as string });
            }
            #endregion

        }
    }
}