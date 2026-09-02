namespace ApiPratica.Models
{
    public class Group :BaseEntity
    {
        public string Name { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
