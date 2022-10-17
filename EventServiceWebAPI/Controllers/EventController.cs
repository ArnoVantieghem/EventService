using EventServiceBL.Managers;
using EventServiceBL.Model;
using Microsoft.AspNetCore.Mvc;

namespace EventServiceWebAPI.Controllers
{
    [Route("[controller]")] // pad
        [ApiController]
        public class EventController : ControllerBase
        {
        private EventManager em;
        private BezoekerManager bm;

        public EventController(EventManager em, BezoekerManager bm)
        {
            this.em = em;
            this.bm = bm;
        }

        [HttpPost]
            public ActionResult<Event> VoegEventToe([FromBody] Event ev)
            {
            try
            {
                if (ev == null) return BadRequest();
                em.VoegEventToe(ev);
                return CreatedAtAction(nameof(Get),new {name=ev.Naam},ev);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            } 
            [HttpDelete("name")]
            public IActionResult VerwijderEvent(string name)
            {
            try
            {
                if (!em.BestaatEvent(name)) return NotFound();
                em.VerwijderEvent(em.GetEventOpNaam(name));
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpPut("{name}")]
            public IActionResult UpdateEvent (string name, [FromBody] Event ev)
            {
            try
            {
                if (!name.Equals(ev.Naam)) return BadRequest("names not matching");
                if (!em.BestaatEvent(name)) return BadRequest("event does not exist");
                em.UpdateEvent(ev);
                return NoContent();
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpGet("{name}")]
            public ActionResult<Event> Get(string name)
            {
            try
            {
                return Ok(em.GetEventOpNaam(name));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpGet]
            public ActionResult<List<Event>> GeefAlleEvents ()
            {
            try
            {
                return Ok(em.GetEvents());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpGet]
            [Route("date/{date}")]
            public ActionResult<List<Event>> GeefEventsVoorDatum (string date)
            {
            try
            {
                return Ok(em.GetEventOpDatum(DateTime.Parse(date)));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpGet]
            [Route("location/{location}")]
            public ActionResult<List<Event>> GeefEventsVoorLocatie (string location)
            {
            try
            {
                return Ok(em.GetEventOpLocatie(location));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpPost]
            [Route("{EventName}")]
            public ActionResult<Event> RegistreerBezoekerVoorEvent(string EventName, [FromBody]int bezoekerId)
            {
            try
            {
                Bezoeker be= bm.GeefBezoeker(bezoekerId);
                Event ev=em.GetEventOpNaam(EventName);
                em.RegistreerBezoeker(be, ev);
                return CreatedAtAction(nameof(Get),new {name=EventName},ev);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            }
            [HttpDelete]
            [Route("{EventName}")]
        public IActionResult MeldBezoekerAfVoorEvent(string EventName, [FromBody] int bezoekerId)
        {
            try
            {
                Bezoeker be = bm.GeefBezoeker(bezoekerId);
                Event ev = em.GetEventOpNaam(EventName);
                em.VerwijderBezoeker(be, ev);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
