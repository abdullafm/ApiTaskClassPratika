namespace ApiPratica.Helpers.Dto_s.Student
{
    public class StudentCreateDto
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<int> GroupId { get; set; }
    }
}
