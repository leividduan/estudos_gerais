using APICatalago.Context;
using APICatalago.Controllers;
using APICatalago.DTOs;
using APICatalago.DTOs.Mappings;
using APICatalago.Repository;
using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace APICatalagoXUnitTestes
{
    public class CategoriasUnitTestController
    {
        private IMapper mapper;
        private IUnitOfWork repository;
        public static DbContextOptions<AppDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost;Database=CatalagoDB;Trusted_Connection=True;";

        static CategoriasUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlServer(connectionString).Options;
            
        }

        public CategoriasUnitTestController()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            mapper = config.CreateMapper();

            var context = new AppDbContext(dbContextOptions);

            repository = new UnitOfWork(context);
        }

        [Fact]
        public async  void GetCategorias_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<List<CategoriaDTO>>(data.Value);
        }

        [Fact]
        public async void GetCategorias_Return_BadRequest()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void GetCategorias_MatchResult()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);

            //Act
            var data = await controller.Get();

            //Assert
            Assert.IsType<List<CategoriaDTO>>(data.Value);

            var cat = data.Value.Should().BeAssignableTo<List<CategoriaDTO>>().Subject;

            Assert.Equal("Bebidas", cat[0].Nome);
            Assert.Equal("http://macoratti.net/Imagens/1.jpg", cat[0].ImagemUrl);

            Assert.Equal("Sobremesas", cat[2].Nome);
            Assert.Equal("http://macoratti.net/Imagens/3.jpg", cat[2].ImagemUrl);
        }


        [Fact]
        public async void GetCategoriasById_Return_OkResult()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);
            var catId = 2;

            //Act
            var data = await controller.Get(catId);

            //Assert
            Assert.IsType<CategoriaDTO>(data.Value);
        }

        [Fact]
        public async void GetCategoriasById_Return_BadRequest()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);
            var catId = 289898;

            //Act
            var data = await controller.Get(catId);

            //Assert
            Assert.IsType<NotFoundResult>(data.Result);
        }

        [Fact]
        public async void PostCategorias_Return_CreatedResult()
        {
            //Arrange
            var controller = new CategoriasController(repository, mapper);
            var cat = new CategoriaDTO() { Nome = "Categoria Teste Unitario", ImagemUrl = "testeunitario.jpg" };

            //Act
            var data = await controller.Post(cat);

            //Assert
            Assert.IsType<CreatedAtRouteResult>(data);
        }

        //[Fact]
        //public async void PutCategorias_Return_OkResult() //TESTE BUGADO
        //{
        //    //Arrange
        //    var controller = new CategoriasController(repository, mapper);
        //    var catId = 2;

        //    //Act
        //    var existingPost = await controller.Get(catId);
        //    var result = existingPost.Value.Should().BeAssignableTo<CategoriaDTO>().Subject;

        //    var catDto = new CategoriaDTO() { CategoriaId= catId, Nome = "Categoria Atualizada - Teste 1", ImagemUrl = result.ImagemUrl};
        //    var updatedData = await controller.Put(catId, catDto);

        //    //Assert
        //    Assert.IsType<OkResult>(updatedData);

        //}


    }
}
