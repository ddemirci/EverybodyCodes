using EverybodyCodes.Data.Models;

namespace EverybodyCodes.Contracts
{
    public interface ICameraService
    {
        IEnumerable<CameraDetailsDto> GetCameraDetailList();
    }
}
