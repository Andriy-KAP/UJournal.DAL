using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using UJournal.Model.Core;
using UJournal.Model.Models;

namespace UJournal.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private UJournalContext context;
        public StudentController(UJournalContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Student> Get()
        {

            return this.context.Students.ToList<Student>();
        }
        
    }
}
