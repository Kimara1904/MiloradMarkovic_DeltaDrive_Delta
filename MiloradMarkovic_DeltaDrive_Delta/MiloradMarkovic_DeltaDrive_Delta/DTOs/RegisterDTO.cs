namespace MiloradMarkovic_DeltaDrive_Delta.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Birthday { get; set; }
    }
}
