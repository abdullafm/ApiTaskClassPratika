using ApiPratica.Data;
using ApiPratica.Helpers.Dto_s.Student;
using ApiPratica.Models;
using ApiPratica.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace ApiPratica.Services
{
    public class StudentService :IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StudentCreateDto> CreateAsync(StudentCreateDto studentCreateDto)
        {
            var students = new Student
            {
                FullName = studentCreateDto.FullName,
                Address = studentCreateDto.Address,
                Age = studentCreateDto.Age,
                Email = studentCreateDto.Email,
                StudentGroups = studentCreateDto.GroupId.Select(id => new StudentGroup
                {
                    GroupId = id
                }).ToList()
            };
            await _context.Students.AddAsync(students);
            await _context.SaveChangesAsync();
            return studentCreateDto;
        }

        public async Task DeletedAsync(int id)
        {
            var deletedId = await _context.Students.FirstOrDefaultAsync(d => d.Id == id);
             _context.Students.Remove(deletedId);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentDto>> GetAllAsync()
        {
            var studentGetAll = await _context.Students.Select(s => new StudentDto
            {
                Id = s.Id,
                FullName = s.FullName,
                Address = s.Address,
                Age = s.Age,
                Email = s.Email,
                GroupId = s.StudentGroups.Select(sg => sg.GroupId).FirstOrDefault()
            }).ToListAsync();

            return studentGetAll;
        }

        public async Task<StudentDto> GetByIdAsync(int id)
        {
            var getbyid = await _context.Students.FirstOrDefaultAsync(i => i.Id == id);
            return new StudentDto {
                Id = getbyid.Id,
                FullName = getbyid.FullName,
                Address = getbyid.Address,
                Email = getbyid.Email,
                Age = getbyid.Age,
            };
        }

        public async Task<IEnumerable<StudentDto>> SearchByNameAsync(string name)
        {
            var searchByName = await _context.Students.FirstOrDefaultAsync(x => x.FullName.Trim().ToUpper().ToLower().Contains(name.Trim().ToUpper().ToLower()));
        }
    }
}
