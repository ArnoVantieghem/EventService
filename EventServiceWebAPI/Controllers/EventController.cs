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

        public EventController(EventManager em)
        {
            this.em = em;
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
            //public void GeefEventsVoorDatum () { }
            //public void GeefEventsVoorLocatie () { }
            //public void RegistreerBezoekerVoorEvent() { }
            //public void MeldBezoekerAfVoorEvent() { }

    }
}
