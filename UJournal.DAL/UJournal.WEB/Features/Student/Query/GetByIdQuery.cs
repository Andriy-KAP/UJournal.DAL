using AutoMapper;
using MediatR;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.WEB.ViewModel;

namespace UJournal.WEB.Features.Student.Query
{
    public class GetByIdQuery: IRequest<StudentViewModel>
    {
        public int Id { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, StudentViewModel>
    {
        private IStudentService studentService;
        private IMapper mapper;
        public GetByIdQueryHandler(IStudentService _studentService, IMapper _mapper)
        {
            this.studentService = _studentService;
            this.mapper = _mapper;
        }

        public async Task<StudentViewModel> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            StudentDTO student = await this.studentService.GetSingle(request.Id);
            return this.mapper.Map<StudentViewModel>(student);
        }
    }
}
