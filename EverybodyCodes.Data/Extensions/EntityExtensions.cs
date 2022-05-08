using EverybodyCodes.Data.Entities;
using EverybodyCodes.Data.Models;

namespace Data.Extensions
{
    public static class EntityExtensions
    {
        public static CameraDetailsDto ToCameraDetailsDto(this CameraDetails entity)
        {
            return new CameraDetailsDto
            {
                CameraName = entity.Camera,
                Latitude = entity.Latitude,
                Longitude = entity.Longitude,
                CameraId = GetCameraId(entity.Camera),
            };
        }

        private static int GetCameraId(string cameraName)
        {
            var arr = cameraName.Split(' ');
            if (arr.Length == 0) return 0;
            var splittedName = arr[0].Split('-');
            return splittedName.Length < 3 || !int.TryParse(splittedName[2], out int cameraId) ? 0 : cameraId;
        }
    }
}
