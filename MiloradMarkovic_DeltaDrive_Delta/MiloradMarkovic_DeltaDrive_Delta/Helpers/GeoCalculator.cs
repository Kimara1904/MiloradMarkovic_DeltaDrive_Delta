using MiloradMarkovic_DeltaDrive_Delta.Helpers.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Helpers
{
    public class GeoCalculator : IGeoCalculator
    {
        public async Task<double> CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            double radLat1 = Math.PI * lat1 / 180;
            double radLon1 = Math.PI * lon1 / 180;
            double radLat2 = Math.PI * lat2 / 180;
            double radLon2 = Math.PI * lon2 / 180;

            double deltaLat = radLat2 - radLat1;
            double deltaLon = radLon2 - radLon1;

            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                   Math.Cos(radLat1) * Math.Cos(radLat2) *
                   Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);

            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            double distance = 6371 * c; // multiplying with radius of Earth

            return distance;
        }
    }
}
