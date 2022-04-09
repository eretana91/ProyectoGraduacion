
using FisioterapiaUlatskawa.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace FisioterapiaUlatskawa.Controllers
{
    

    public class SchedulerRecurringController : ApiController
    {
        private Context db = new Context();

        // GET: api/schedulerrecurring
        public IEnumerable<Models.WebAPIRecurringEvent> Get(DateTime from, DateTime to)
        {
            return (IEnumerable<Models.WebAPIRecurringEvent>)db.SchedulerRecurringEvent
                .Where(e => e.StartDate < to && e.EndDate >= from)
                .ToList()
                .Select(e => e);
        }

        // GET: api/schedulerrecurring/5
        //public Models.WebAPIRecurringEvent Get(int id)
        //{
        //    return (Models.WebAPIRecurringEvent)db.SchedulerRecurringEvent.Find(id);
        //}

        // PUT: api/schedulerrecurring/5
        [System.Web.Http.HttpPut]
        public IHttpActionResult EditSchedulerEvent(int id, Models.WebAPIRecurringEvent webAPIEvent)
        {
            var updatedSchedulerEvent = (Models.SchedulerRecurringEventVM)webAPIEvent;
            updatedSchedulerEvent.Id = id;
            db.Entry(updatedSchedulerEvent).State = EntityState.Modified;

            if (!string.IsNullOrEmpty(updatedSchedulerEvent.RecType) && updatedSchedulerEvent.RecType != "none")
            {
                //all modified occurrences must be deleted when we update a recurring series
                //https://docs.dhtmlx.com/scheduler/server_integration.html#savingrecurringevents

                db.SchedulerRecurringEvent.RemoveRange(
                    db.SchedulerRecurringEvent.Where(e => e.EventPID == id)
                );
            }

            db.SaveChanges();

            return Ok(new
            {
                action = "updated"
            });
        }

        // POST: api/schedulerrecurring/5
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateSchedulerEvent(Models.WebAPIRecurringEvent webAPIEvent)
        {
            var newSchedulerEvent = (Models.SchedulerRecurringEventVM)webAPIEvent;


            var dataEnviar = new DataModel.SchedulerRecurringEvent {
                Id = webAPIEvent.id,
                Text = webAPIEvent.text,
                StartDate = DateTime.Parse(webAPIEvent.start_date),
                EndDate = DateTime.Parse(webAPIEvent.end_date),
                EventPID = webAPIEvent.event_pid,
                RecType = webAPIEvent.rec_type,
                EventLength = webAPIEvent.event_length
            };


            db.SchedulerRecurringEvent.Add(dataEnviar);
            db.SaveChanges();

            // delete a single occurrence from a recurring series
            var resultAction = "inserted";
            if (newSchedulerEvent.RecType == "none")
            {
                resultAction = "deleted";
            }

            return Ok(new
            {
                tid = newSchedulerEvent.Id,
                action = resultAction
            });
        }

        // DELETE: api/schedulerrecurring/5
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteSchedulerEvent(int id)
        {
            var schedulerEvent = db.SchedulerRecurringEvent.Find(id);
            if (schedulerEvent != null)
            {
                //some logic specific to recurring events support
                //https://docs.dhtmlx.com/scheduler/server_integration.html#savingrecurringevents

                if (schedulerEvent.EventPID != default(int))
                {
                    // deleting a modified occurrence from a recurring series
                    // If an event with the event_pid value was deleted, it should be updated 
                    // with rec_type==none instead of deleting.

                    schedulerEvent.RecType = "none";
                }
                else
                {
                    //if a recurring series deleted, delete all modified occurrences of the series
                    if (!string.IsNullOrEmpty(schedulerEvent.RecType) && schedulerEvent.RecType != "none")
                    {
                        //all modified occurrences must be deleted when we update recurring series
                        //https://docs.dhtmlx.com/scheduler/server_integration.html#savingrecurringevents
                        db.SchedulerRecurringEvent.RemoveRange(
                            db.SchedulerRecurringEvent.Where(ev => ev.EventPID == id)
                        );
                    }

                    db.SchedulerRecurringEvent.Remove(schedulerEvent);
                }
                db.SaveChanges();
            }

            return Ok(new
            {
                action = "deleted"
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}