using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Core.Domain;
using FluentValidation.Results;

namespace Balta.Localizacao.MVVM.Core.Presentaion
{
    public abstract class BaseService<T> where T : BaseModel?
    {
        public CustomResponse<BaseViewModel<T>> CustomResponse { get; private set; }

        protected BaseService()
        {
            CustomResponse = new CustomResponse<BaseViewModel<T>>();
        }

        public virtual async Task<bool> PossuiErros()
        {
            return await CustomResponse.IsCompleted();
        }

        public virtual async Task AdicionarErro(string errorMessage)
        { 
            await CustomResponse.AdicionarErro(errorMessage);
        }
        
        public virtual async Task AdicionarErro(ValidationResult validationResult)
        { 
            await CustomResponse.AtribuirValidationResult(validationResult);
        }

        public virtual async Task AtribuirViewModel(BaseViewModel<T> viewModel)
        {
            await CustomResponse.AtribuirViewModel(viewModel);
        }

        public virtual async Task<CustomResponse<BaseViewModel<T>>> PersistirDados(IUnitOfWork unitOfWork)
        {
            if(!await unitOfWork.Commit())
                AdicionarErro("Erro ao persistir dados");
                
            return CustomResponse;
        }

    }
}
