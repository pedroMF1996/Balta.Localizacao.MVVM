using Balta.Localizacao.MVVM.PresentetionLayer.Services;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Moq.AutoMock;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.Domain.Specification;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Data.Repositorios;
using Balta.Localizacao.MVVM.Data;
using Balta.Localizacao.MVVM.Core.Data;

namespace Balta.Localizacao.MVVM.PresentationLayer.Tests
{
    public class IbgeServiceTeste
    {
        [Fact(DisplayName = "Deve Cadastrar um Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task LoginViewModel_RealizarLogin_DeveRealizarLoginComSucesso()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<IbgeAdicionarViewModel>().CustomInstantiator(f => new IbgeAdicionarViewModel()
            {
                City=f.Address.City(),
                State="MA",
                Id="1234567",
                
            }).Generate();

            var service = autoMocker.CreateInstance<IbgeService>();
           
            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.AdicionarIbge(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);
    
            // Act
            var result = await service.AdicionarIbge(viewModel);

            // Assert
            Assert.True(result.ValidationResult.IsValid);
      
        }
    }
}
