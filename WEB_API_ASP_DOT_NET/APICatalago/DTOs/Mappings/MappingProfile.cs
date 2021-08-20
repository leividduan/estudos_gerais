using APICatalago.Models;
using AutoMapper;

namespace APICatalago.DTOs.Mappings
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProdutoDTO, Produto>().ReverseMap();
            CreateMap<CategoriaDTO, Categoria>().ReverseMap();
        }
    }
}
