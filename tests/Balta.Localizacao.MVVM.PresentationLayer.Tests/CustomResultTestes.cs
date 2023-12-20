using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels;
using Balta.Localizacao.MVVM.Core.Presentaion;
using Xunit;
using Moq.AutoMock;
using FluentValidation.Results;
using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Domain.Models;

namespace Balta.Localizacao.MVVM.PresentationLayer.Tests
{
    public class CustomResponseTestes
    {
        [Fact(DisplayName = "Atribuir o ViewModel ao CustomResponse")]
        [Trait("Categoria", "CustomResponse")]
        public async Task AtribuirViewModelAoCustomResponse_IbgeAtualizarViewModel_AtribuiViewModelComSucesso()
        {
            // Arrange
            var viewModel = new IbgeAtualizarViewModel()
            {
                City = "Ribeirao Preto",
                State = "SP",
                Id = "3501234"
            };
            var result = new CustomResponse();

            // Act
            await result.AtribuirViewModel(viewModel);

            // Assert
            Assert.Equal(viewModel, result.ViewModel);
        }

        [Fact(DisplayName = "Atribuir ViewModel Ao CustomResponse Do Service")]
        [Trait("Categoria", "CustomResponse")]
        public async Task AtribuirViewModelAoCustomResponseDoService_IbgeAtualizarViewModel_AtribuiViewModelComSucesso()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();
            var viewModel = new IbgeAtualizarViewModel()
            {
                City = "Ribeirao Preto",
                State = "SP",
                Id = "3501234"
            };

            // Act
            await service.AtribuirViewModel(viewModel);

            // Assert
            Assert.Equal(viewModel, service.CustomResponse.ViewModel);
        }

        [Fact(DisplayName = "IbgeAtualizar ViewModel IsCompleted Com Sucesso")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseIsCompleted_IbgeAtualizarViewModel_IsCompletedComSucesso()
        {
            // Arrange
            var viewModel = new IbgeAtualizarViewModel()
            {
                City = "Ribeirao Preto",
                State = "SP",
                Id = "3501234"
            };
            var result = new CustomResponse();

            // Act
            await result.AtribuirViewModel(viewModel);

            // Assert
            Assert.True(await result.IsCompleted());
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel IsCompleted Com Erro")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseIsCompleted_IbgeAtualizarViewModel_IsCompletedComErro()
        {
            // Arrange
            var result = new CustomResponse();

            // Act
            await result.AdicionarErro("Teste");

            // Assert
            Assert.False(await result.IsCompleted());
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel Contains Erro Com Sucesso")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseContains_IbgeAtualizarViewModel_ContainsErroComSucesso()
        {
            // Arrange
            var result = new CustomResponse();

            // Act
            await result.AdicionarErro("Teste");
            
            // Assert
            Assert.True(await result.Contains("Teste"));
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel Obter Primeiro Erro Com Sucesso")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseObterPrimeiroErro_IbgeAtualizarViewModel_ObterPrimeiroErroComSucesso()
        {
            // Arrange
            var result = new CustomResponse();

            // Act
            await result.AdicionarErro("Teste");

            // Assert
            Assert.Equal("Teste", await result.ObterPrimeiroErro());
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel Obter Primeiro Erro Com Falha")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseObterPrimeiroErro_IbgeAtualizarViewModel_ObterPrimeiroErroComFalha()
        {
            // Arrange
            var result = new CustomResponse();

            // Act
            // Assert
            Assert.NotEqual("Teste", await result.ObterPrimeiroErro());
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel Obter Primeiro Erro Com Falha")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseAtribuirValidationResult_IbgeAtualizarViewModel_AtribuirValidationResultComSucesso()
        {
            // Arrange
            var result = new CustomResponse();
            var validationResult = new ValidationResult();
            
            // Act
            await result.AtribuirValidationResult(validationResult);

            // Assert
            Assert.Equal(validationResult.IsValid, await result.IsCompleted());
        }

        [Fact(DisplayName = "AdicionarErro Ao CustomResponse Do Service")]
        [Trait("Categoria", "BaseService")]
        public async Task AdicionarErroAoCustomResponseDoService_IbgeAtualizarViewModel_AdicionarErroComSucesso()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();

            // Act
            await service.AdicionarErro("Teste");

            // Assert
            Assert.Equal("Teste", await service.CustomResponse.ObterPrimeiroErro());
        }
        
        [Fact(DisplayName = "AdicionarErro ValidationResult Ao CustomResponse Do Service")]
        [Trait("Categoria", "BaseService")]
        public async Task AdicionarErroValidationResultAoCustomResponseDoService_IbgeAtualizarViewModel_AdicionarErroValidationResultComSucesso()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();
            var validationResult = new ValidationResult();

            // Act
            await service.AdicionarErro(validationResult);

            // Assert
            Assert.Equal(validationResult.IsValid, await service.CustomResponse.IsCompleted());
        }

        [Fact(DisplayName = "PossuiErros Service")]
        [Trait("Categoria", "BaseService")]
        public async Task PossuiErroCustomResponseDoService_CustomResponseDoService_PossuiErroComSucesso()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();

            // Act
            await service.AdicionarErro("Teste");

            // Assert
            Assert.True(await service.PossuiErros());
        }
        
        [Fact(DisplayName = "PersistirDados Do Service Com Sucesso")]
        [Trait("Categoria", "BaseService")]
        public async Task PersistirDadosService_CustomResponseDoService_PersistirDadosComSucesso()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();
            var unitOfWork = automocker.GetMock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Commit())
                .Returns(Task.FromResult(true));

            // Act
            await service.PersistirDados(unitOfWork.Object);

            // Assert
            Assert.False(await service.PossuiErros());
        }
        
        [Fact(DisplayName = "PersistirDados Do Service Com Falha")]
        [Trait("Categoria", "BaseService")]
        public async Task PersistirDadosService_CustomResponseDoService_PersistirDadosComFalha()
        {
            // Arrange
            var automocker = new AutoMocker();
            var service = automocker.CreateInstance<ServiceMock>();
            var unitOfWork = automocker.GetMock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Commit())
                .Returns(Task.FromResult(false));

            // Act
            await service.PersistirDados(unitOfWork.Object);

            // Assert
            Assert.True(await service.PossuiErros());
        }
    }
}
