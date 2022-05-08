using System.ComponentModel.DataAnnotations;

namespace EverybodyCodes.Data.Entities
{
    public class CameraDetails
    {
        [Key]
        public Guid Id { get; set; }
        public string Camera { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public CameraDetails()
        {

        }

        public CameraDetails(string camera, double latitude, double longitude)
        {
            Camera = camera;
            Latitude = latitude;
            Longitude = longitude;
        }

    }
}
