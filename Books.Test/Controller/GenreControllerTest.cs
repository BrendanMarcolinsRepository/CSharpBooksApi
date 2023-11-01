using Books.Controllers;
using Books.Models.Domain;
using Books.Models.DTOs.GenresDto;
using Books.Service.GenreService;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Test.Controller
{
    public class GenreControllerTest
    {
        private readonly IGenreService genreService;

        public GenreControllerTest()
        {
            this.genreService = A.Fake<IGenreService>();
        }


        [Fact]
        public async Task GenreController_GetAllGenres_ReturnOk()
        {
            //Arrange
            var count = 10;
            var fakeGenres = A.CollectionOfDummy<GenreDto>(count).ToList();
            A.CallTo(() => genreService.GetAllGenre()).Returns(Task.FromResult(fakeGenres));
            var controller = new GenreController(genreService);
            //Act

            var result = await controller.GetAllGenres();
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as List<GenreDto>;

            //Assert

            resultGenres.Should().NotBeNull();
            resultGenres.Should().BeOfType<List<GenreDto>>();
            resultGenres.Should().HaveCount(count);

        }

        [Fact]
        public async Task GenreController_GetGenresById_ReturnOk()
        {
            //Arrange

            var name = "Sci-Fi";
            var id = Guid.NewGuid();

            A.CallTo(() => genreService.GetAGenreById(id)).Returns(Task.FromResult(new GenreDto { Id = id, Name = name }));
            var controller = new GenreController(genreService);

            //Act

            var result = await controller.GetAGenreById(id);
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as GenreDto;


            //Assert
            resultGenres.Should().NotBeNull();

            System.Diagnostics.Debug.WriteLine("Wokring here +++++++ " + resultGenres);
            resultGenres.Should().BeOfType<GenreDto>();

        }


        [Fact]
        public async Task GenreController_GetGenresByName_ReturnOk()
        {
            //Arrange

            var name = "Sci-Fi";
            var id = Guid.NewGuid();

            A.CallTo(() => genreService.GetAGenreByName(name)).Returns(Task.FromResult(new GenreDto { Id = id, Name = name }));
            var controller = new GenreController(genreService);

            //Act

            var result = await controller.GetAGenreByName(name);
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as GenreDto;


            //Assert
            resultGenres.Should().NotBeNull();

            System.Diagnostics.Debug.WriteLine("Wokring here +++++++ " + resultGenres);
            resultGenres.Should().BeOfType<GenreDto>();



        }

        [Fact]
        public async Task GenreController_CreateAGenre_ReturnOk()
        {
            var name = "Sci-Fi";
            var id = Guid.NewGuid();



            var fakeAddDeleteUpdateGenreDto = A.Fake<AddDeleteUpdateGenreDto>();
            

            A.CallTo(() => genreService.CreateAGenre(fakeAddDeleteUpdateGenreDto)).Returns(Task.FromResult(new GenreDto { Id = id, Name = name }));
            var controller = new GenreController(genreService);

            //Act

            var result = await controller.CreateAGenre(fakeAddDeleteUpdateGenreDto);
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as GenreDto;


            //Assert
            resultGenres.Should().NotBeNull();

            System.Diagnostics.Debug.WriteLine("Wokring here +++++++ " + resultGenres);
            resultGenres.Should().BeOfType<GenreDto>();



        }

        [Fact]
        public async Task GenreController_UpdateAGenre_ReturnOk()
        {
            var name = "Sci-Fi";
            var id = Guid.NewGuid();



            var fakeAddDeleteUpdateGenreDto = A.Fake<AddDeleteUpdateGenreDto>();
            var fakeId = A.Fake<GenreDto>();


            A.CallTo(() => genreService.UpdateAGenre(fakeId.Id,fakeAddDeleteUpdateGenreDto)).Returns(Task.FromResult(new GenreDto { Id = id, Name = name }));
            var controller = new GenreController(genreService);

            //Act

            var result = await controller.UpdateAGenre(fakeId.Id,fakeAddDeleteUpdateGenreDto);
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as GenreDto;


            //Assert
            resultGenres.Should().NotBeNull();

            System.Diagnostics.Debug.WriteLine("Wokring here +++++++ " + resultGenres);
            resultGenres.Should().BeOfType<GenreDto>();



        }

        [Fact]
        public async Task GenreController_DeleteAGenre_ReturnOk()
        {
            var name = "Sci-Fi";
            var id = Guid.NewGuid();



            var fakeAddDeleteUpdateGenreDto = A.Fake<AddDeleteUpdateGenreDto>();
            var fakeId = A.Fake<GenreDto>();


            A.CallTo(() => genreService.DeleteAGenre(fakeId.Id, fakeAddDeleteUpdateGenreDto)).Returns(Task.FromResult(new GenreDto { Id = id, Name = name }));
            var controller = new GenreController(genreService);

            //Act

            var result = await controller.DeleteAGenre(fakeId.Id, fakeAddDeleteUpdateGenreDto);
            var okResult = result as OkObjectResult;
            var resultGenres = okResult.Value as GenreDto;


            //Assert
            resultGenres.Should().NotBeNull();

            System.Diagnostics.Debug.WriteLine("Wokring here +++++++ " + resultGenres);
            resultGenres.Should().BeOfType<GenreDto>();



        }
    }
}
