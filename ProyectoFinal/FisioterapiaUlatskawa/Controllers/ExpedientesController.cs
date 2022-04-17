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
    public class ExpedientesController : Controller
    {
        private readonly Context context;

        public ExpedientesController()
        {
            context = new Context();
        }




        /******************************************************/
        // Metodos CRUD
        #region GET: Pagos
        public ActionResult Index()
        {
            string pCedula = "";

            if (Session["EsAdmin"].ToString().Equals("1"))
            {
                pCedula = null;
            }
            else
            {
                pCedula = Session["pCedula"].ToString();

            }


            List<ExpedientesViewModel> ListExpedientes = new List<ExpedientesViewModel>();

            try
            {

                var result = context.ListarMiExpediente(pCedula).ToList();

                foreach (var dato in result)
                {
                    ListExpedientes.Add(new ExpedientesViewModel
                    {
                        idExpediente = dato.idExpediente,
                        cedula = dato.cedula,
                        fechaN = dato.fechaN,
                        ciudad = dato.ciudad,
                        canton = dato.canton,
                        distrito = dato.distrito,
                        diagnostico = dato.diagnostico,
                        antecendente = dato.antecendente,
                        mediUtilizados = dato.mediUtilizados,
                        anteQuirurgicos = dato.anteQuirurgicos,
                        fracturas = dato.fracturas,
                        anteFamiliares = dato.anteFamiliares

                    });
                };

                Session["MiCedula"] = pCedula;

                return View(ListExpedientes);
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

                return View(ListExpedientes);
            }
        }
        #endregion

        #region GET: Usuarios/Create
        public ActionResult Create(string pCedula)
        {
            ExpedientesViewModel expedientesViewModel = new ExpedientesViewModel();
            try
            {
                Session["pCedula"] = pCedula;

                expedientesViewModel.cedula = pCedula;

                //List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();
                List<SelectListItem> ListaUsuarios = new List<SelectListItem>();


                //var result = context.ListarTipoPagos().ToList();

                //foreach (var dato in result)
                //{
                //    ListaTipoPagos.Add(new SelectListItem
                //    {
                //        Value = dato.tipoPago.ToString(),
                //        Text = dato.nombrePago
                //    });
                //};

                var us = context.ListarUsuarios().ToList();

                foreach (var dato in us)
                {
                    ListaUsuarios.Add(new SelectListItem
                    {
                        Value = dato.cedula.ToString(),
                        Text = dato.nombre
                    });
                };

                //pagosViewModel.ListaTipoPago = ListaTipoPagos;
                expedientesViewModel.ListaUsuarios = ListaUsuarios;

                return View(expedientesViewModel);
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

            return RedirectToAction("Index", "Expedientes");
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cedula,fechaN,ciudad,canton,distrito,diagnostico,antecendente,mediUtilizados,anteQuirurgicos,fracturas,anteFamiliares ")] ExpedientesViewModel expedientesVM)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var resulta = context.InsertarExpediente(
                      expedientesVM.cedula,
                      expedientesVM.fechaN,
                      expedientesVM.ciudad,
                      expedientesVM.canton,
                      expedientesVM.distrito,
                      expedientesVM.diagnostico,
                      expedientesVM.antecendente,
                      expedientesVM.mediUtilizados,
                      expedientesVM.anteQuirurgicos,
                      expedientesVM.fracturas,
                      expedientesVM.anteFamiliares
                       ).FirstOrDefault();


                    TempData["Message"] = "Expediente Insertado correctamente";

                    return RedirectToAction("Index", "Expedientes", new { pCedula = expedientesVM.cedula });
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

            //List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();

            //var result = context.ListarTipoPagos().ToList();

            //foreach (var dato in result)
            //{
            //    ListaTipoPagos.Add(new SelectListItem
            //    {
            //        Value = dato.tipoPago.ToString(),
            //        Text = dato.nombrePago
            //    });
            //};

            ////expedientesVM.ListaTipoPago = ListaTipoPagos;

            return View(expedientesVM);
        }


        #region GET: Usuarios/Edit
        public ActionResult Edit(int pIdExpediente)
        {
            try
            {

                var resultado = context.ConsultarExpedientes(pIdExpediente).FirstOrDefault();


                //List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();
                List<SelectListItem> ListaUsuarios = new List<SelectListItem>();

                //var result = context.ListarTipoPagos().ToList();
                var usu = context.ListarUsuarios().ToList();

                //foreach (var dato in result)
                //{
                //    ListaTipoPagos.Add(new SelectListItem
                //    {
                //        Value = dato.tipoPago.ToString(),
                //        Text = dato.nombrePago
                //    });
                //};

                foreach (var dato in usu)
                {
                    ListaUsuarios.Add(new SelectListItem
                    {
                        Value = dato.cedula.ToString(),
                        Text = dato.nombre
                    });
                };


                ExpedientesViewModel expedientesVM = new ExpedientesViewModel
                {
                    idExpediente = resultado.idExpediente,
                    cedula = resultado.cedula,
                    fechaN = resultado.fechaN,
                    ciudad = resultado.ciudad,
                    canton = resultado.canton,
                    distrito = resultado.distrito,
                    diagnostico = resultado.diagnostico,
                    antecendente = resultado.antecendente,
                    mediUtilizados = resultado.mediUtilizados,
                    anteQuirurgicos = resultado.anteQuirurgicos,
                    fracturas = resultado.fracturas,
                    anteFamiliares = resultado.anteFamiliares,
                    ListaUsuarios = ListaUsuarios
                };

                return View(expedientesVM);
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

                return RedirectToAction("Index", "Expedientes", new { pCedula = Session["pCedula"] as string });
            }
        }

        // POST: Clases/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idExpediente, cedula,fechaN,ciudad,canton,distrito,diagnostico,antecendente,mediUtilizados,anteQuirurgicos,fracturas,anteFamiliares ")] ExpedientesViewModel expedientesVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var results = context.ActualizarExpedientes(
                        expedientesVM.idExpediente,
                        expedientesVM.cedula,
                        expedientesVM.fechaN,
                        expedientesVM.ciudad,
                        expedientesVM.canton,
                        expedientesVM.distrito,
                        expedientesVM.diagnostico,
                        expedientesVM.antecendente,
                        expedientesVM.mediUtilizados,
                        expedientesVM.anteQuirurgicos,
                        expedientesVM.fracturas,
                        expedientesVM.anteFamiliares
                        ).FirstOrDefault();

                    TempData["Message"] = "Expediente modificado correctamente";

                    return RedirectToAction("Index", "Expedientes", new { pCedula = Session["pCedula"] as string });
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

            //List<SelectListItem> ListaTipoPagos = new List<SelectListItem>();
            //var result = context.ListarTipoPagos().ToList();
            //foreach (var dato in result)
            //{
            //    ListaTipoPagos.Add(new SelectListItem
            //    {
            //        Value = dato.tipoPago.ToString(),
            //        Text = dato.nombrePago
            //    });
            //};
            //expedientesVM.ListaTipoPago = ListaTipoPagos;

            return View(expedientesVM);
        }
        #endregion



        #region GET: Clases/Details
        public ActionResult Details(int pIdExpediente)
        {
            try
            {

                var resultado = context.ConsultarExpedientes(pIdExpediente).FirstOrDefault();

                ExpedientesViewModel expedientesVM = new ExpedientesViewModel
                {
                    idExpediente = resultado.idExpediente,
                    cedula = resultado.cedula,
                    fechaN = resultado.fechaN,
                    ciudad = resultado.ciudad,
                    canton = resultado.canton,
                    distrito = resultado.distrito,
                    diagnostico = resultado.diagnostico,
                    antecendente = resultado.antecendente,
                    mediUtilizados = resultado.mediUtilizados,
                    anteQuirurgicos = resultado.anteQuirurgicos,
                    fracturas = resultado.fracturas,
                    anteFamiliares = resultado.anteFamiliares
                };

                return View(expedientesVM);
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

                return RedirectToAction("Index", "Expedientes", new { pCedula = Session["pCedula"] as string });
            }
            #endregion

        }
    }
}
