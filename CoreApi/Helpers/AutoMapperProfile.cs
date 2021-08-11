using AutoMapper;
using CoreApi.Entities;
using CoreApi.Models;

namespace CoreApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Entity to Model
            CreateMap<Todo, TodoModel>();

            // Model to Entity
            CreateMap<TodoModel, Todo>();
        }
    }
}