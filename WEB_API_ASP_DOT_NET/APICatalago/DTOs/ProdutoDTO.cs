using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.DTOs
{
    public record ProdutoDTO
    {
        public int ProdutoId { get; init; }
        public string Nome { get; init; }
        public string Descricao { get; init; }
        public decimal Preco { get; init; }
        public string ImagemUrl { get; init; }
        public int CategoriaId { get; init; }
    }
}
