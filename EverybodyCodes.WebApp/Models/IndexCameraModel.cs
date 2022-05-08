using EverybodyCodes.Data.Models;

namespace EverybodyCodes.WebApp.Models
{
    public class IndexCameraModel
    {
        public IEnumerable<ClassifiedCameraDetailsModel> Cameras { get; set; }

        public IndexCameraModel()
        {

        }

        public IndexCameraModel(IEnumerable<CameraDetailsDto> cameraDetailsDtos)
        {
            Cameras = GroupCameras(cameraDetailsDtos);
        }

        public IEnumerable<ClassifiedCameraDetailsModel> GroupCameras(IEnumerable<CameraDetailsDto> cameraDetailsList)
        {
            foreach (var camera in cameraDetailsList)
            {
                int groupNumber;
                if (camera.CameraId % 15 == 0)
                    groupNumber = 3;
                else if (camera.CameraId % 3 == 0)
                    groupNumber = 1;
                else if (camera.CameraId % 5 == 0)
                    groupNumber = 2;
                else
                    groupNumber = 4;
                yield return new ClassifiedCameraDetailsModel(camera, groupNumber);
            }
        }
    }
}
