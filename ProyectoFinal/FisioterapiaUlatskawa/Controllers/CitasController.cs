using FisioterapiaUlatskawa.DataModel;
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
    public class CitasController : Controller
    {
        private Context db = new Context();

        // GET: Citas
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult Get(DateTime from, DateTime to)
        {

            var data = db.SchedulerRecurringEvent.ToList();

            List<Models.WebAPIRecurringEvent> eventos = new List<Models.WebAPIRecurringEvent>();

            foreach (var item in data)
            {
                var inicio = (DateTime)item.StartDate;
                var start = inicio.ToString("yyyy-MM-dd HH:mm");

                var final = (DateTime)item.EndDate;
                var end = final.ToString("yyyy-MM-dd HH:mm");

                eventos.Add(new Models.WebAPIRecurringEvent
                {
                    id = item.Id,
                    text = item.Text,
                    start_date = start,
                    end_date = end,
                    event_pid = item.EventPID,
                    rec_type = item.RecType,
                    event_length = (long?)item.EventLength
                });
                
            }

            return Json(eventos, JsonRequestBehavior.AllowGet);

           
        }

        [HttpPost]
        public JsonResult CreateSchedulerEvent(Models.WebAPIRecurringEvent webAPIEvent)
        {
           

            SchedulerRecurringEvent eventos = new SchedulerRecurringEvent {
                //Id = webAPIEvent.id,
                Text = webAPIEvent.text,
                StartDate = DateTime.Parse(webAPIEvent.start_date),
                EndDate = DateTime.Parse(webAPIEvent.end_date),
                EventPID = webAPIEvent.event_pid,
                RecType = webAPIEvent.rec_type,
                EventLength = webAPIEvent.event_length
            };


            db.InsertarSchema(
                eventos.Text,
                eventos.StartDate,
                eventos.EndDate,
                eventos.EventPID,
                eventos.RecType,
                eventos.EventLength).FirstOrDefault();

            // delete a single occurrence from a recurring series
            var resultAction = "inserted";
            if (eventos.RecType == "none")
            {
                resultAction = "deleted";
            }

            var jsonObject = new JsonResult();
            jsonObject.JsonRequestBehavior = JsonRequestBehavior.AllowGet;           
            jsonObject.Data = "Ok";
            return jsonObject;


        }

        [HttpPut]
        public JsonResult CreateSchedulerEvent(int id, Models.WebAPIRecurringEvent webAPIEvent)
        {

            SchedulerRecurringEvent eventos = new SchedulerRecurringEvent
            {
                Id = webAPIEvent.id,
                Text = webAPIEvent.text,
                StartDate = DateTime.Parse(webAPIEvent.start_date),
                EndDate = DateTime.Parse(webAPIEvent.end_date),
                EventPID = webAPIEvent.event_pid,
                RecType = webAPIEvent.rec_type,
                EventLength = webAPIEvent.event_length
            };


            db.ActualizarEventos(
                eventos.Id,
                eventos.Text,
                eventos.StartDate,
                eventos.EndDate

                ).FirstOrDefault();

            var jsonObject = new JsonResult();
            jsonObject.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonObject.Data = "Ok";
            return jsonObject;

        }

        [HttpDelete]
        public JsonResult CreateSchedulerEvent(int id)
        {
            var schedulerEvent = db.SchedulerRecurringEvent.Find(id);

            db.EliminarEventos(schedulerEvent.Id).FirstOrDefault();

            var jsonObject = new JsonResult();
            jsonObject.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            jsonObject.Data = "Ok";
            return jsonObject;
        }


    }
}
