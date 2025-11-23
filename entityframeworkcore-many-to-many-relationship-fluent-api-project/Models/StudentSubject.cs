namespace entityframeworkcore_many_to_many_relationship_project.Models
{
    public class StudentSubject
    {
        public Student? Student { get; set; }
        public int StudentID { get; set; }
        public Subject? Subject { get; set; }
        public int SubjectID { get; set; }
    }
}
