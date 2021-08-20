using APICatalago.Models;
using APICatalago.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalago.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<PagedList<Produto>> GetProdutos(QueryStringParameters produtosParameters);
        Task<IEnumerable<Produto>> GetProdutosPorPreco();
    }
}
