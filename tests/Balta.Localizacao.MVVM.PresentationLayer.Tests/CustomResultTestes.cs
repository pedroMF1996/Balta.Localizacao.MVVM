using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels;
using Balta.Localizacao.MVVM.Core.Presentaion;
using Xunit;
using Moq.AutoMock;
using FluentValidation.Results;

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

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
            var result = new CustomResponse<IbgeAtualizarViewModel>();

            // Act
            // Assert
            Assert.NotEqual("Teste", await result.ObterPrimeiroErro());
        }
        
        [Fact(DisplayName = "IbgeAtualizar ViewModel Obter Primeiro Erro Com Falha")]
        [Trait("Categoria", "CustomResponse")]
        public async Task CustomResponseAtribuirValidationResult_IbgeAtualizarViewModel_AtribuirValidationResultComSucesso()
        {
            // Arrange
            var result = new CustomResponse<IbgeAtualizarViewModel>();
            var validationResult = new ValidationResult();
            
            // Act
            await result.AtribuirValidationResult(validationResult);

            // Assert
            Assert.Equal(validationResult.IsValid, await result.IsCompleted());
        }
    }
}
