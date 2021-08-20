using APICatalago.Models;
using GraphQL.Types;

namespace APICatalago.GraphQL
{
    public class CategoriaType : ObjectGraphType<Categoria>
    {
        public CategoriaType()
        {
            Field(x => x.CategoriaId);
            Field(x => x.Nome);
            Field(x => x.ImagemUrl);

            Field<ListGraphType<CategoriaType>>("categorias");
        }
    }
}
