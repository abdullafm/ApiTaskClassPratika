using ApiPratica.Helpers.Dto_s.Student;
using ApiPratica.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPratica.Controllers.Admin
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public AdminController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(StudentCreateDto studentCreateDto)
        {
            var createpost = await _studentService.CreateAsync(studentCreateDto);
            return Ok(createpost);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var getallget = await _studentService.GetAllAsync();
            return Ok(getallget);
        }
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var getbyidget = await _studentService.GetByIdAsync(id);
            return Ok(getbyidget);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletedAsync(int id)
        {
            var deletedIdDel = await _studentService.GetByIdAsync(id);
            await _studentService.DeletedAsync(id);
            return Ok(deletedIdDel);
        }
    }
}
