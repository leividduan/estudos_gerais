using APICatalago.Context;
using APICatalago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICatalagoXUnitTestes
{
    public class DBUnitTestsMockInitializer
    {
        public DBUnitTestsMockInitializer()
        {
        }

        public void Seed(AppDbContext context)
        {
            context.Categorias.Add(new Categoria { CategoriaId = 999, Nome = "Bebidas999", ImagemUrl = "bebidas999.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 2, Nome = "Sucos", ImagemUrl = "Sucos.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 3, Nome = "Doces", ImagemUrl = "Doces.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 4, Nome = "Salgados", ImagemUrl = "Salgados.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 5, Nome = "Tortas", ImagemUrl = "Tortas.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 6, Nome = "Bolos", ImagemUrl = "Bolos.jpg" });
            context.Categorias.Add(new Categoria { CategoriaId = 7, Nome = "Lanches", ImagemUrl = "Lanches.jpg" });

            context.SaveChanges();
        }
    }
}
