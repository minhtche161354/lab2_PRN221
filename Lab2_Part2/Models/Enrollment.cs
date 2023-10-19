using System.ComponentModel.DataAnnotations;

namespace Lab2_Part2.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
