namespace MiloradMarkovic_DeltaDrive_Delta.Helpers.Interfaces
{
    public interface IGeoCalculator
    {
        Task<double> CalculateDistance(double lat1, double lon1, double lat2, double lon2);
    }
}
