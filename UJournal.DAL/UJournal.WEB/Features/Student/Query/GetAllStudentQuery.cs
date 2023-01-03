using AutoMapper;
using MediatR;
using System.Transactions;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.WEB.ViewModel;

namespace UJournal.WEB.Features.Student.Query
{
    public class GetAllStudentQuery: IRequest<IEnumerable<StudentViewModel>>
    {
    }
    public class GetAllStudentQueryHandler : StudentQueryCommandBase, IRequestHandler<GetAllStudentQuery, IEnumerable<StudentViewModel>>
    {
        public GetAllStudentQueryHandler(IServiceProvider serviceProvider): base(serviceProvider)
        {

        }
        public async Task<IEnumerable<StudentViewModel>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<StudentDTO> students = await this.studentService.Get();
            return this.mapper.Map<IEnumerable<StudentViewModel>>(students);
        }
    }
}
