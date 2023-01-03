using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using UJournal.DAL.Behavior;
using UJournal.DAL.DTO;
using UJournal.Model.Core;
using UJournal.Model.Models;
using UJournal.WEB.Features.Student.Query;
using UJournal.WEB.ViewModel;

namespace UJournal.DAL.Controllers
{
    [Route("Api/{controller}")]
    [Authorize]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IMediator mediator;
        public StudentController(IMediator _mediator)
        {
            this.mediator = _mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentViewModel>> Get()
        {
            return await this.mediator.Send(new GetAllStudentQuery());
        }

        [HttpGet]
        [Route("GetWhere")]
        public async Task<IEnumerable<StudentViewModel>> GetWhere(int id)
        {
            return await this.mediator.Send(new GetWhereStudentQuery { Expression = student =>  student.Id == id});
        }
    }
}
