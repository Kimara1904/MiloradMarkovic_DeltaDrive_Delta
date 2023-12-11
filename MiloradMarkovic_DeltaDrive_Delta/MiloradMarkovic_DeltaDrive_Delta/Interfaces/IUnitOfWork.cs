namespace MiloradMarkovic_DeltaDrive_Delta.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
    }
}
