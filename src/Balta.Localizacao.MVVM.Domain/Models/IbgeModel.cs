using Balta.Localizacao.MVVM.Core.Domain;
using Balta.Localizacao.MVVM.Core.utils;
using Balta.Localizacao.MVVM.Domain.Models.Validations;

namespace Balta.Localizacao.MVVM.Domain.Models
{
    public class IbgeModel : BaseModel
    {
        public string Id { get; private set; }
        public string? City { get; private set; }
        public string? State { get; private set; }

        protected IbgeModel() { }
        public IbgeModel(string id, string state, string city)
        {
            Id = id;
            City = city;
            State = state;
        }

        public async Task<bool> SetId(string id)
        {
            if (!id.IsOnlyNumbers() || Id == id)
                return false;

            Id = id;
            return true;
        }
        
        public async Task<bool> SetCity(string city)
        {
            if (!city.HasMaxLength(80) || City == city)
                return false;
            
            City = city;
            return true;
        }

        public async Task<bool> SetState(string state)
        {
            if (!state.HasMaxLength(2) || State == state)
                return false;
            
            State = state;
            return true;
        }

        public override bool IsValid()
        {
            ValidationResult = new IbgeModelValidation().Validate(this);
            return base.IsValid();
        }  
    }
}
