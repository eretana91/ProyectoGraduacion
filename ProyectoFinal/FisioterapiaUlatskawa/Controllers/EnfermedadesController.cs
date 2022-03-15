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
    public class EnfermedadesController : Controller
    {
        private readonly Context context;
        // GET: Enfermedades

        public EnfermedadesController()
        {
            context = new Context();
        }

        /******************************************************/
        // Metodos CRUD
        #region GET: Enfermedades
        public ActionResult Index(string pCedula)
        {
            Session["pCedula"] = pCedula;

            List<EnfermedadesViewModel> ListEnfermedades = new List<EnfermedadesViewModel>();

            try
            {

                var result = context.ListarEnfermedades(pCedula).ToList();

                foreach (var dato in result)
                {
                    ListEnfermedades.Add(new EnfermedadesViewModel
                    {
                        nombreEnfermedad = dato.nombreEnfermedad,
                        cedula = dato.cedula
                        
                    });
                };



                return View(ListEnfermedades);
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

                return View(ListEnfermedades);
            }
        }
        #endregion

        #region GET: Enfermedades/Create
        public ActionResult Create(string pCedula)
        {


            EnfermedadesViewModel enfermedadesViewModel = new EnfermedadesViewModel();
            try
            {
                Session["pCedula"] = pCedula;

                enfermedadesViewModel.cedula = pCedula;
                

                return View(enfermedadesViewModel);
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

            return RedirectToAction("Index", "Enfermedades");
        }



        [HttpPost]
        
        public ActionResult Create([Bind(Include = "nombreEnfermedad,cedula,Detalles")] EnfermedadesViewModel enfermedadesVM)
        {
            List<ResultViewModel> dataReturn = new List<ResultViewModel>();

            if (ModelState.IsValid)
            {
                try
                {

                    foreach (var item in enfermedadesVM.Detalles)
                    {
                        var result = context.InsertarEnfermedad(
                           item.idEnfermedad,
                           item.nombreEnfermedad,
                           enfermedadesVM.cedula).FirstOrDefault();
                    };
                    
                       
                      

                    var redirectUrl = new UrlHelper(Request.RequestContext).Action("Index", "Enfermedades",
                        new
                        {
                            pCedula = enfermedadesVM.cedula
                        });

                    TempData["Message"] = "Enfermedad Insertada correctamente";

                    dataReturn.Add(new ResultViewModel
                    {
                        statusCode = "200",
                        data = redirectUrl
                    });

                    return Json(dataReturn, JsonRequestBehavior.AllowGet);


                    
                }
                catch (Exception ex)
                {
                    if (ex.InnerException != null)
                    {
                        dataReturn.Add(new ResultViewModel
                        {
                            statusCode = "99",
                            data = ex.InnerException.Message
                        });

                        return Json(dataReturn, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        dataReturn.Add(new ResultViewModel
                        {
                            statusCode = "99",
                            data = ex.Message
                        });

                        return Json(dataReturn, JsonRequestBehavior.AllowGet);

                    }
                }
            }
            else
            {


                var error = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .FirstOrDefault();

               

                dataReturn.Add(new ResultViewModel
                {
                    statusCode = "99",
                    data = error[0].ErrorMessage
                });

                return Json(dataReturn, JsonRequestBehavior.AllowGet);

            }


          
        }
        #endregion




    }
}