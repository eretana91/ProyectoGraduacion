using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FisioterapiaUlatskawa.DataModel;

namespace FisioterapiaUlatskawa.Controllers
{
    public class ExpedientesController : Controller
    {
        //private Context db = new Context();

        //// GET: Expedientes
        //public ActionResult Index()
        //{
        //    var expedientes = db.Expedientes.Include(e => e.Usuario);
        //    return View(expedientes.ToList());
        //}

        //// GET: Expedientes/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expedientes expediente = db.Expedientes.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expediente);
        //}

        //// GET: Expedientes/Create
        //public ActionResult Create()
        //{
        //    ViewBag.cedula = new SelectList(db.Usuario, "cedula", "nombre");
        //    return View();
        //}

        //// POST: Expedientes/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "cedula,fechaN,ciudad,canton,distrito,diagnostico,antecedentes,mediUtilizados,anteQuirurgicos,fracturas,anteFamiliares")] Expediente expediente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Expedientes.Add(expediente);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.cedula = new SelectList(db.Usuario, "cedula", "nombre", expediente.cedula);
        //    return View(expediente);
        //}

        //// GET: Expedientes/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expedientes expediente = db.Expedientes.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.cedula = new SelectList(db.Usuario, "cedula", "nombre", expediente.cedula);
        //    return View(expediente);
        //}

        //// POST: Expedientes/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "cedula,fechaN,ciudad,canton,distrito,diagnostico,antecedentes,mediUtilizados,anteQuirurgicos,fracturas,anteFamiliares")] Expediente expediente)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(expediente).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.cedula = new SelectList(db.Usuarios, "cedula", "nombre", expediente.cedula);
        //    return View(expediente);
        //}

        //// GET: Expedientes/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Expediente expediente = db.Expedientes.Find(id);
        //    if (expediente == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(expediente);
        //}

        //// POST: Expedientes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Expediente expediente = db.Expedientes.Find(id);
        //    db.Expedientes.Remove(expediente);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
