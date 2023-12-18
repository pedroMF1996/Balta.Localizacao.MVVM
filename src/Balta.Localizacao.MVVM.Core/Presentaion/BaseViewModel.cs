using Balta.Localizacao.MVVM.Core.Domain;
using FluentValidation.Results;

namespace Balta.Localizacao.MVVM.Core.Presentaion
{
    public abstract class BaseViewModel<T> where T : BaseModel
    {
        public ValidationResult ValidationResult { get; protected set; }

        public virtual bool IsValid()
        {
            return ValidationResult.IsValid;
        }
    }
}
