using CursoMVC.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursoTest
{
    class CategoriaControllerTest
    {
        private readonly Mock<DbSet<Categoria>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Categoria _categoria;

        public CategoriaControllerTest()
        {
            _mockSet = new Mock<DbSet<Categoria>>();
            _mockContext = new Mock<Context>();
            _categoria = new Categoria { Id = 1, Descricao = "Teste Categoria" };
        }

        [Fact]
        public async Task Get_Categoria()
        {
            var service = new CategoriaController(_mockContext.Object);
            await service.GetCategoria(1);

            _mockSet.Verify(mocks => mocks.FindAsync(1),
                Times.Once());
        }
    }
}
