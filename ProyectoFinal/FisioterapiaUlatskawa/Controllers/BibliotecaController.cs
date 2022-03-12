using FisioterapiaUlatskawa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    public class BibliotecaController : Controller
    {
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
    }
}