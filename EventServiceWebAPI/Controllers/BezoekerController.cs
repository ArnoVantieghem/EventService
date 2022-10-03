using Microsoft.AspNetCore.Mvc;

namespace EventServiceWebAPI.Controllers
{
        [Route("api/[controller]")] // pad
        [ApiController]
        public class BezoekerController : ControllerBase
        {
            private IBezoekerRepository repo;

            public BezoekerController(IEventRepository repo)
            {
                this.repo = repo;
            }
        }
}
