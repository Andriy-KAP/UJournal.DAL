using AutoMapper;
using MediatR;
using System.Linq.Expressions;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.WEB.ViewModel;

namespace UJournal.WEB.Features.Student.Query
{
    public class GetWhereStudentQuery: IRequest<IEnumerable<StudentViewModel>>
    {
        public Expression<Func<StudentDTO, bool>> Expression { get; set; } = null!;
    }

    public class GetWhereStudentQueryHandler: IRequestHandler<GetWhereStudentQuery, IEnumerable<StudentViewModel>>
    {
        private IStudentService studentService;
        private IMapper mapper;
        public GetWhereStudentQueryHandler(IStudentService _studentService, IMapper _mapper)
        {
            this.studentService = _studentService;
            this.mapper = _mapper;
        }

        public async Task<IEnumerable<StudentViewModel>> Handle(GetWhereStudentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StudentDTO> students = await this.studentService.GetWhere(request.Expression);
            return this.mapper.Map<IEnumerable<StudentViewModel>>(students);
        }
    }
}
