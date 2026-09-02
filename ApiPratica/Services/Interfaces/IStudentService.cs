using ApiPratica.Helpers.Dto_s.Student;

namespace ApiPratica.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentCreateDto> CreateAsync(StudentCreateDto studentCreateDto);
        Task<IEnumerable<StudentDto>> GetAllAsync();
        Task DeletedAsync(int id);
        Task<IEnumerable<StudentDto>> SearchByNameAsync(string name);
        Task<StudentDto> GetByIdAsync(int id);
    }
}
