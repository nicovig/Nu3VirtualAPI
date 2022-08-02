namespace NuVirtualApi.Database.EntityModels
{
    public class User
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; } //cm
        public double Weight { get; set; } //kg
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
