namespace MiloradMarkovic_DeltaDrive_Delta.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthday { get; set; }
        public virtual List<Rate> Rates { get; set; } = null!;
        public virtual List<HistoryPreviewItem> HistoryPreviews { get; set; } = null!;
    }
}
