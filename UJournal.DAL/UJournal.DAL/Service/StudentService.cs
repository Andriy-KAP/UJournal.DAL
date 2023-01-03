using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.Model.Behavior;
using UJournal.Model.Models;

namespace UJournal.DAL.Service
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> repository;
        private readonly IMapper mapper;
        public StudentService(IRepository<Student> _repository, IMapper _mapper)
        {
            this.repository = _repository;
            this.mapper = _mapper;
        }

        public async Task<IEnumerable<StudentDTO>> Get()
        {
            IEnumerable<Student> students = await this.repository.Get().ToListAsync<Student>();
            IEnumerable<StudentDTO> result = this.mapper.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }

        public Task<StudentDTO> GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDTO>> GetWhere(Expression<Func<StudentDTO, bool>> expression)
        {
            Expression<Func<Student, bool>> convertedExpression = this.mapper.Map<Expression<Func<Student, bool>>>(expression);
            IEnumerable<Student> students = await this.repository.GetWhere(convertedExpression).ToListAsync<Student>();
            IEnumerable<StudentDTO> result = this.mapper.Map<IEnumerable<StudentDTO>>(students);
            return result;
        }
        public Task Add(StudentDTO student)
        {
            throw new NotImplementedException();
        }
        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(StudentDTO student)
        {
            throw new NotImplementedException();
        }
    }
}
