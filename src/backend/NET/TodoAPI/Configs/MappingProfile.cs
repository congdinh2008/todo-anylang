using AutoMapper;

namespace TodoAPI;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoViewModel>().ReverseMap();
        CreateMap<Category, CategoryViewModel>().ReverseMap();
    }
}
