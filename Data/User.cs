namespace StudyMapAPI.Data
{
    public class User
    {
        public int Id { get; set; }
        public string? GoogleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string? PasswordHash { get; set; }

        public string? PasswordSalt { get; set; }

        public string? AuthProvider { get; set; }

        public int Coins { get; set; }
    }
}
