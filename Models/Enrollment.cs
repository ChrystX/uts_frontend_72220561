namespace uts_frontend_72220561.Models
{
    public class Instructors
    {
        public int InstructorId { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
    }

    public class Enrollments
    {
        public int EnrollmentId { get; set; }
        public int InstructorId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }
}
