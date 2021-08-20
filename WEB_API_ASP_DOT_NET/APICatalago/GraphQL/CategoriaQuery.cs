using APICatalago.Repository;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalago.GraphQL
{
    public class CategoriaQuery : ObjectGraphType
    {
        public CategoriaQuery(IUnitOfWork _context)
        {
            Field<ListGraphType<CategoriaType>>("categoria", arguments: new QueryArguments(new QueryArgument<IntGraphType>() { Name = "id" }),
                                                resolve: context =>
                                                {
                                                    var id = context.GetArgument<int>("id");
                                                    return _context.CategoriaRepository.GetById(c => c.CategoriaId == id);
                                                });


            Field<ListGraphType<CategoriaType>>("categorias",
                resolve: context =>
                {
                    return _context.CategoriaRepository.Get();
                });
        }
    }
}
