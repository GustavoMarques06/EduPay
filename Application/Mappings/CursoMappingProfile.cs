using AutoMapper;
using EduPay.Domain.Entities;
using EduPay.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class CursoMappingProfile : Profile
{
    public CursoMappingProfile()
    {
        // DTO -> Entidade Polimórfica
        CreateMap<CursoUpdateDto, CursoOnline>()
            .ForMember(dest => dest.Modulo, opt => opt.MapFrom(src => src.Modulo))
            .ForMember(dest => dest.DataLancamento, opt => opt.MapFrom(src => src.DataLancamento))
            .ForMember(dest => dest.Plataforma, opt => opt.MapFrom(src => src.Plataforma));

        CreateMap<CursoUpdateDto, CursoPresencial>()
            .ForMember(dest => dest.Sala, opt => opt.MapFrom(src => src.Sala))
            .ForMember(dest => dest.Instituicao, opt => opt.MapFrom(src => src.Instituicao));
    }
}
