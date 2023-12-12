namespace MiloradMarkovic_DeltaDrive_Delta.Services
{
    public class LoadDataService : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly IMapper _mapper;

        public LoadDataService(IServiceScopeFactory serviceScopeFactory, IHostApplicationLifetime applicationLifetime, IMapper mapper)
        {
            _scopeFactory = serviceScopeFactory;
            _applicationLifetime = applicationLifetime;
            _mapper = mapper;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _applicationLifetime.ApplicationStarted.Register(async () =>
            {
                stoppingToken.ThrowIfCancellationRequested();

                using var reader = new StreamReader("../../delta-drive.csv");
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<CSVVehicle>();

                var dbRange = _mapper.Map<IEnumerable<CSVVehicle>, IEnumerable<Vehicle>>(records);

                using var scope = _scopeFactory.CreateScope();
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                await unitOfWork._vehicleRepository.AddRange(dbRange);
                await unitOfWork.Save();
            });

            return Task.CompletedTask;
        }
    }
}
