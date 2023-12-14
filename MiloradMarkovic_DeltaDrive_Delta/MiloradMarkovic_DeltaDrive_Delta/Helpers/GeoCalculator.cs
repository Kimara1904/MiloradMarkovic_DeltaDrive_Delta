using GeoCoordinatePortable;
using MiloradMarkovic_DeltaDrive_Delta.Helpers.Interfaces;

namespace MiloradMarkovic_DeltaDrive_Delta.Helpers
{
    public class GeoCalculator : IGeoCalculator
    {
        public async Task<double> CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            var Coord1 = new GeoCoordinate(lat1, lon1);
            var Coord2 = new GeoCoordinate(lat2, lon2);

            return Coord1.GetDistanceTo(Coord2);
        }
    }
}
