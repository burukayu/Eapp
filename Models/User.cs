namespace EntityApp.Models
{
    public class User
    {    
        public Guid userId { get; set; }
        public string? Fullname { get; set; }
        public string? Email { get; set; }
        public Guid Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}