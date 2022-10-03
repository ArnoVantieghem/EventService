using Microsoft.AspNetCore.Mvc;

namespace EventServiceWebAPI.Controllers
{
        [Route("api/[controller]")] // pad
        [ApiController]
        public class EventController : ControllerBase
        {
            private IEventRepository repo;

            public EventController(IEventRepository repo)
            {
                this.repo = repo;
            }
        }
}
