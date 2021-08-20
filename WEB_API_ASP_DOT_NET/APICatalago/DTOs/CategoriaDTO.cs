using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.DTOs
{
    public record CategoriaDTO
    {
        public int CategoriaId { get; init; }
        public string Nome { get; init; }
        public string ImagemUrl { get; init; }
        public ICollection<ProdutoDTO> Produtos { get; init; }
    }
}
