using Balta.Localizacao.MVVM.Core.Domain;
using FluentValidation.Results;
namespace Balta.Localizacao.MVVM.Core.Presentaion
{
    public class CustomResponse<T> where T : BaseModel?
    {
        private ValidationResult _validationResult;
        public BaseViewModel<T> ViewModel { get; private set; }
        public IReadOnlyCollection<string> Errors => _validationResult.Errors.Select(e => e.ErrorMessage).ToList();
        public CustomResponse()
        {
            _validationResult = new ValidationResult();
        }

        public async Task AdicionarErro(string errorMessage)
        {
            _validationResult.Errors.Add(new ValidationFailure("Erro de processamento", errorMessage));
        }

        public async Task AtribuirViewModel(BaseViewModel<T> viewModel)
        {
            ViewModel = viewModel;
        }

        public async Task AtribuirValidationResult(ValidationResult validationResult)
        {
            _validationResult = validationResult;
        }

        public async Task<bool> IsCompleted()
        {
            return _validationResult.IsValid;
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
