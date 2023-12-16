using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Domain.Models.Validations;
using Bogus.DataSets;

namespace Balta.Localizacao.MVVM.Domain.Tests
{
    public class IbgeModelTests
    {
        [Fact(DisplayName = "IbgeModel Deve Ser Instanciado Sem Erros")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_NovoIbgeModel_DeveSerInstanciadoSemErros()
        {
            // Arrange
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            var result = model.IsValid();

            // Assert
            Assert.True(result);
        }
        
        [Fact(DisplayName = "IbgeModel Deve Ser Instanciado Com Erros De Validacao")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_NovoIbgeModel_DeveSerInstanciadoComErrosDeValidacao()
        {
            // Arrange
            var lorem = new Lorem();
            var model = new IbgeModel("a", lorem.Paragraph(150), lorem.Paragraph(150));

            // Act
            var result = model.IsValid();

            // Assert
            var erros = model.ValidationResult.Errors.Select(e => e.ErrorMessage);
            Assert.False(result);
            Assert.Contains(IbgeModelValidation.IdLengthErrorMessage, erros);
            Assert.Contains(IbgeModelValidation.IdOnlyNumbersErrorMessage, erros);
            Assert.DoesNotContain(IbgeModelValidation.IdRequiredErrorMessage, erros);
            
            Assert.Contains(IbgeModelValidation.StateLengthErrorMessage, erros);
            Assert.DoesNotContain(IbgeModelValidation.StateRequiredErrorMessage, erros);

            Assert.Contains(IbgeModelValidation.CityMaxLengthErrorMessage, erros);
            Assert.DoesNotContain(IbgeModelValidation.CityRequiredErrorMessage, erros);
        }

        [Fact(DisplayName = "IbgeModel Deve Alterar Id Com Sucesso")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarId_DeveAlterarIdComSucesso()
        {
            // Arrange
            var novoId = "1234567";
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetId(novoId);

            // Assert
            Assert.True(model.IsValid());
            Assert.Equal(novoId, model.Id);
        }

        [Fact(DisplayName = "IbgeModel Nao Deve Alterar Id")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarId_NaoDeveAlterarId()
        {
            // Arrange
            var novoId = "abcdefg";
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetId(novoId);

            // Assert
            Assert.True(model.IsValid());
            Assert.NotEqual(novoId, model.Id);
        }

        [Fact(DisplayName = "IbgeModel Deve Alterar State Com Sucesso")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarState_DeveAlterarStateComSucesso()
        {
            // Arrange
            var novoState = "SP";
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetState(novoState);

            // Assert
            Assert.True(model.IsValid());
            Assert.Equal(novoState, model.State);
        }
        
        [Fact(DisplayName = "IbgeModel Nao Deve Alterar State")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarState_NaoDeveAlterarState()
        {
            // Arrange
            var novoState = "Sao Paulo";
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetState(novoState);

            // Assert
            Assert.True(model.IsValid());
            Assert.NotEqual(novoState, model.State);
        }

        [Fact(DisplayName = "IbgeModel Deve Alterar City Com Sucesso")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarCity_DeveAlterarCityComSucesso()
        {
            // Arrange
            var novoCity = "Sao Paulo";
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetCity(novoCity);

            // Assert
            Assert.True(model.IsValid());
            Assert.Equal(novoCity, model.City);
        }
        
        [Fact(DisplayName = "IbgeModel Nao Deve Alterar City")]
        [Trait("Categoria", "Model")]
        public void IbgeModel_AlterarCity_NaoDeveAlterarCity()
        {
            // Arrange
            var lorem = new Lorem();
            var novoCity = lorem.Paragraph(150);
            var model = new IbgeModel("1100031", "RO", "Cabixi");

            // Act
            model.SetCity(novoCity);

            // Assert
            Assert.True(model.IsValid());
            Assert.NotEqual(novoCity, model.City);
        }
    }
}
