using AutoMapper;
using UJournal.DAL.Behavior;
using UJournal.DAL.Service;

namespace UJournal.WEB.Features.Student
{
    public class StudentQueryCommandBase
    {
        protected IStudentService studentService;
        protected IMapper mapper;
        public StudentQueryCommandBase(IServiceProvider serviceProvider)
        {
            this.studentService = serviceProvider.GetService<IStudentService>();
            this.mapper = serviceProvider.GetService<IMapper>();
        }
    }
}
