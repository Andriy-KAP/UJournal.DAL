using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.Model.Core;
using UJournal.Model.Models;
using UJournal.WEB.ViewModel;

namespace UJournal.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;
        public StudentController(IStudentService _studentService, IMapper _mapper)
        {
            this.studentService = _studentService;
            this.mapper = _mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentViewModel>> Get()
        {
            IEnumerable<StudentDTO> students = await this.studentService.Get();
            IEnumerable<StudentViewModel> result = this.mapper.Map<IEnumerable<StudentViewModel>>(students);

            return result;
        }
        
    }
}
