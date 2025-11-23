using System.Text.Json.Serialization;

namespace entityframeworkcore_many_to_many_relationship_project.Models
{
    public class Subject
    {
        public int ID { get; set; }
        public string? Name { get; set; }

        // Many-to-Many Relationship
        [JsonIgnore]
        public ICollection<StudentSubject>? StudentSubjects { get; set; } // navigation property

    }
}