using Balta.Localizacao.MVVM.Core.Domain;
using FluentValidation.Results;
namespace Balta.Localizacao.MVVM.Core.Presentaion
{
    public class CustomResponse<T> where T : BaseModel?
    {
        public ValidationResult ValidationResult { get; private set; }
        public BaseViewModel<T> ViewModel { get; private set; }

        public CustomResponse()
        {
            ValidationResult = new ValidationResult();
        }

        public async Task AdicionarErro(string errorMessage)
        {
            ValidationResult.Errors.Add(new ValidationFailure("Erro de processamento", errorMessage));
        }

        public async Task AtribuirViewModel(BaseViewModel<T> viewModel)
        {
            ViewModel = viewModel;
        }

        public async Task AtribuirValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}
