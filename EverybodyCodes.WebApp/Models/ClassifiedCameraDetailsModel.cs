using EverybodyCodes.Data.Models;

namespace EverybodyCodes.WebApp.Models
{
    public class ClassifiedCameraDetailsModel : CameraDetailsDto
    {
        public int GroupNumber { get; set; }

        public ClassifiedCameraDetailsModel()
        {
        }

        public ClassifiedCameraDetailsModel(CameraDetailsDto dto, int groupNumber)
        {
            CameraId = dto.CameraId;
            CameraName = dto.CameraName;
            Latitude = dto.Latitude;
            Longitude = dto.Longitude;
            GroupNumber = groupNumber;
        }
    }
}
