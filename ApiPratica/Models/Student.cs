namespace ApiPratica.Models
{
    public class Student :BaseEntity
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
