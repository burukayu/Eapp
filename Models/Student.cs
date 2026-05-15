namespace EntityApp.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        
        public string Phone { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CategoryId { get; set; } 
    }
}