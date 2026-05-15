namespace EntityApp.Models

{
    public class CourseFee
    {
        public Guid CourseFeeId { get; set; }
        public Guid CourseId { get; set; }
        public int CategoryId { get; set; }
        public Decimal Fee { get; set; }
    }
}