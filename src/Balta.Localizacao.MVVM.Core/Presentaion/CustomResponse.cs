using Balta.Localizacao.MVVM.Core.Domain;
using FluentValidation.Results;
namespace Balta.Localizacao.MVVM.Core.Presentaion
{
    public class CustomResponse<T> where T : BaseModel?
    {
        public ValidationResult ValidationResult { get; private set; }
        public BaseViewModel<T> ViewModel { get; private set; }
        public IReadOnlyCollection<string> Errors => ValidationResult.Errors.Select(e => e.ErrorMessage).ToList();
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

        public async Task<bool> IsValid()
        {
            return ValidationResult.IsValid;
        }

        public async Task<bool> Contains(string msgError)
        {
            return Errors.Contains(msgError);
        }

        public async Task<string> ObterPrimeiroErro()
        {
            return Errors.FirstOrDefault();
        }
    }
}
