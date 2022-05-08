using EverybodyCodes.Contracts;
using EverybodyCodes.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace EverybodyCodes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CameraController : ControllerBase
    {
        private readonly ICameraService cameraService;
        public CameraController(
            ICameraService cameraService)
        {
            this.cameraService = cameraService;
        }

        // GET: api/camera/list
        [HttpGet("list")]
        public IEnumerable<CameraDetailsDto> Get()
        {
            var list = cameraService.GetCameraDetailList();
            return list;
        }

    }
}
