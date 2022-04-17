using FisioterapiaUlatskawa.DataModel;
using FisioterapiaUlatskawa.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    public class ReportsController : Controller
    {

        private readonly Context context;

        public ReportsController()
        {
            context = new Context();
        }


        // GET: Reports
        public ActionResult Pagos()
        {
            
            return View();
        }

        public ActionResult Usuarios()
        {

            return View();
        }

        public ActionResult Expedientes()
        {

            return View();
        }

        public ActionResult DownloadReportPagos(DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                List<PagosViewModel> listado = new List<PagosViewModel>();

                var result = context.ListarPagosFechas(fechaDesde, fechaHasta).ToList();

                foreach (var dato in result)
                {
                    listado.Add(new PagosViewModel
                    {
                        idPago = dato.idPago,
                        tipoPago = dato.tipoPago,
                        monto = dato.monto,
                        banco = dato.banco,
                        nombrePago = dato.nombre,
                        cedula = dato.cedula,
                        fechaPago = dato.fechaPago,
                        notas = dato.notas
                    });
                };

                //dataCierre[0].ListFormasPago = Listado;

                LocalReport lr = new LocalReport();

                string path = Path.Combine(Server.MapPath("~/Reports"), "ReportePagos.rdlc");

                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                    lr.DataSources.Clear();
                }
                else
                {
                    TempData["ErrorMessage"] = "No se puede generar el informe solicitado.";
                }


                ReportDataSource reportData = new ReportDataSource("ReportePagos", listado); // nombre del dataset


                //Parametros para enviar al reporte
                //Agregar parametros al reporte fecha hora y periodos de fecha

                ReportParameter[] reportParameters = new ReportParameter[1];
                reportParameters[0] = new ReportParameter("FechaHora", "Generado el " + DateTime.Now.ToString("dd/MM/yyyy"), false);

                             


                lr.SetParameters(reportParameters);

                lr.DataSources.Add(reportData);

                lr.Refresh();

                string encoding;
                string fileNameExtension;
                string reportType = "EXCELOPENXML";
                string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                //caracteristicas del documetno en excel
                string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>" + "excel" + "</OutputFormat>" +
                    "  <PageWidth>21.59cm</PageWidth>" +
                    "  <PageHeight>27.94cm</PageHeight>" +
                    "  <MarginTop>1cm</MarginTop>" +
                    "  <MarginLeft>0.5cm</MarginLeft>" +
                    "  <MarginRight>0.5cm</MarginRight>" +
                    "  <MarginBottom>1cm</MarginBottom>" +
                    "</DeviceInfo>";

                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                return File(renderedBytes, mimeType, "DocumentosEmitidos.xlsx");
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

                return RedirectToAction("Index", "Home");

            }
        }


        public ActionResult DownloadReportUsuarios()
        {
            try
            {
                List<UsuariosViewModel> listado = new List<UsuariosViewModel>();

                var result = context.ListarUsuarios().ToList();

                foreach (var dato in result)
                {
                    listado.Add(new UsuariosViewModel
                    {
                        cedula = dato.cedula,
                        nombre = dato.nombre,
                        apellidos = dato.apellidos,
                        telefono = dato.telefono,
                        email = dato.email
                        
                    });
                };

                //dataCierre[0].ListFormasPago = Listado;

                LocalReport lr = new LocalReport();

                string path = Path.Combine(Server.MapPath("~/Reports"), "ReporteUsuarios.rdlc");

                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                    lr.DataSources.Clear();
                }
                else
                {
                    TempData["ErrorMessage"] = "No se puede generar el informe solicitado.";
                }


                ReportDataSource reportData = new ReportDataSource("ReporteUsuarios", listado); // nombre del dataset


                //Parametros para enviar al reporte
                //Agregar parametros al reporte fecha hora y periodos de fecha

                ReportParameter[] reportParameters = new ReportParameter[1];
                reportParameters[0] = new ReportParameter("FechaHora", "Generado el " + DateTime.Now.ToString("dd/MM/yyyy"), false);




                lr.SetParameters(reportParameters);

                lr.DataSources.Add(reportData);

                lr.Refresh();

                string encoding;
                string fileNameExtension;
                string reportType = "EXCELOPENXML";
                string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                //caracteristicas del documetno en excel
                string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>" + "excel" + "</OutputFormat>" +
                    "  <PageWidth>21.59cm</PageWidth>" +
                    "  <PageHeight>27.94cm</PageHeight>" +
                    "  <MarginTop>1cm</MarginTop>" +
                    "  <MarginLeft>0.5cm</MarginLeft>" +
                    "  <MarginRight>0.5cm</MarginRight>" +
                    "  <MarginBottom>1cm</MarginBottom>" +
                    "</DeviceInfo>";

                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                return File(renderedBytes, mimeType, "ReporteUsuarios.xlsx");
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

                return RedirectToAction("Index", "Home");

            }
        }

        public ActionResult DownloadReportExpedientes()
        {
            try
            {
                List<ExpedientesViewModel> listado = new List<ExpedientesViewModel>();

                var result = context.ListarExpedientes().ToList();

                foreach (var dato in result)
                {
                    listado.Add(new ExpedientesViewModel
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
                        anteQuirurgicos= dato.anteQuirurgicos,
                        fracturas= dato.fracturas,  
                        anteFamiliares = dato.anteFamiliares


                    });
                };

               

                LocalReport lr = new LocalReport();

                string path = Path.Combine(Server.MapPath("~/Reports"), "ReporteExpedientes.rdlc");

                if (System.IO.File.Exists(path))
                {
                    lr.ReportPath = path;
                    lr.DataSources.Clear();
                }
                else
                {
                    TempData["ErrorMessage"] = "No se puede generar el informe solicitado.";
                }


                ReportDataSource reportData = new ReportDataSource("ReporteExpedientes", listado); // nombre del dataset


                //Parametros para enviar al reporte
                //Agregar parametros al reporte fecha hora y periodos de fecha

                ReportParameter[] reportParameters = new ReportParameter[1];
                reportParameters[0] = new ReportParameter("FechaHora", "Generado el " + DateTime.Now.ToString("dd/MM/yyyy"), false);




                lr.SetParameters(reportParameters);

                lr.DataSources.Add(reportData);

                lr.Refresh();

                string encoding;
                string fileNameExtension;
                string reportType = "EXCELOPENXML";
                string mimeType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                //caracteristicas del documetno en excel
                string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>" + "excel" + "</OutputFormat>" +
                    "  <PageWidth>21.59cm</PageWidth>" +
                    "  <PageHeight>27.94cm</PageHeight>" +
                    "  <MarginTop>1cm</MarginTop>" +
                    "  <MarginLeft>0.5cm</MarginLeft>" +
                    "  <MarginRight>0.5cm</MarginRight>" +
                    "  <MarginBottom>1cm</MarginBottom>" +
                    "</DeviceInfo>";

                Warning[] warnings;
                string[] streams;
                byte[] renderedBytes;

                renderedBytes = lr.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);

                return File(renderedBytes, mimeType, "ReporteExpedientes.xlsx");
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

                return RedirectToAction("Index", "Home");

            }
        }
    }
}


