using FluentValidation.Results;

namespace Balta.Localizacao.MVVM.Core.Domain
{
    public abstract class BaseModel
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected BaseModel() 
        { 
            ValidationResult = new ValidationResult(); 
        }

        public virtual bool IsValid() { 
            return ValidationResult.IsValid; 
        }
    }
}
