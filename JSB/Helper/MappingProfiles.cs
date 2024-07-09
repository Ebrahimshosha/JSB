namespace JSB.Helper;

public class MappingProfiles :Profile
{
    public MappingProfiles()
    {
        CreateMap<Book, BookToReturnDto>()
            .ForMember(d=>d.CategoryDescription,o=>o.MapFrom(s=>s.Category.Description))
            .ForMember(d=>d.CategoryName,o=>o.MapFrom(s=>s.Category.Name));

        CreateMap<BookDTO, Book>();
    }
}
