using Data.Extensions;
using EverybodyCodes.Contracts;
using EverybodyCodes.Data;
using EverybodyCodes.Data.Models;

namespace EverybodyCodes.Services
{
    public class CameraService : ICameraService
    {
        private readonly CameraDetailsContext cameraDetailsContext;

        public CameraService(CameraDetailsContext cameraDetailsContext)
        {
            this.cameraDetailsContext = cameraDetailsContext;
        }

        public IEnumerable<CameraDetailsDto> GetCameraDetailList()
        {
            var entityList = cameraDetailsContext.CameraDetails.ToList();
            foreach (var entity in entityList)
            {
                yield return entity.ToCameraDetailsDto();
            }
        }
    }
}
