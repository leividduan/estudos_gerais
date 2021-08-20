﻿using APICatalago.Models;
using APICatalago.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APICatalago.Repository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        Task<PagedList<Categoria>> GetCategorias(CategoriasParameters categoriasParameters);
        Task<IEnumerable<Categoria>> GetCategoriasProdutos();
    }
}
