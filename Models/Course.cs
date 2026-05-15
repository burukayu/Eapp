namespace EntityApp.Models
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public int? DurationDays { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}