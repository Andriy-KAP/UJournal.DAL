using AutoMapper;
using UJournal.DAL.DTO;
using UJournal.Model.Models;
using UJournal.WEB.ViewModel;

namespace UJournal.WEB.Util.Mapper
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<StudentDTO, StudentViewModel>();
        }
    }
}
