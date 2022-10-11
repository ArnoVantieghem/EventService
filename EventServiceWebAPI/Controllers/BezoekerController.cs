using EventServiceBL.Managers;
using EventServiceBL.Model;
using Microsoft.AspNetCore.Mvc;

namespace EventServiceWebAPI.Controllers
{
    [Route("[controller]")] // pad
    [ApiController]
    public class BezoekerController : ControllerBase
    {
        private BezoekerManager bm = new BezoekerManager();
        [HttpPost]
        public ActionResult<Bezoeker> PostBezoeker([FromBody] Bezoeker bezoeker)
        {
            if (bezoeker == null) return BadRequest();
            try
            {
                Bezoeker b = bm.RegistreerBezoeker(bezoeker);
                bm.RegistreerNaarLijst(b);
                return CreatedAtAction(nameof(GetAll), new { id = b.Id }, b);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //[HttpGet]
        //public ActionResult<Bezoeker> Get(int id)
        //{
        //    try
        //    {
        //        return bm.GeefBezoeker(id);
        //    } catch (Exception ex) {
        //        return NotFound();
        //    }
        //}
        [HttpGet]
        public ActionResult<List<Bezoeker>> GetAll()
        {
            try
            {
                return bm.GeefAlleBezoerks().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpDelete]
        public IActionResult Delete(Bezoeker bezoeker)
        {
            try
            {
                bm.VerwijderVanLijst(bezoeker);
                return NoContent();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody] Bezoeker bezoeker)
        {
            if (bezoeker == null) return BadRequest();
            try
            {
                bm.UpdateBezoeker(bezoeker);
                return NoContent();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    } 
}
