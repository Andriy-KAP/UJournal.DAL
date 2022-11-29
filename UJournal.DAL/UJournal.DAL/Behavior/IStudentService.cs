using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UJournal.DAL.DTO;

namespace UJournal.DAL.Behavior
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDTO>> Get();
        Task<IEnumerable<StudentDTO>> GetWhere(Expression<Func<StudentDTO, bool>> expression);

        Task<StudentDTO> GetSingle(int id);
        Task Add(StudentDTO student);
        Task Update(StudentDTO student);
        Task Remove(int id);
    }
}
