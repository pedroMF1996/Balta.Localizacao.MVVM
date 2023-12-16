using Balta.Localizacao.MVVM.Core.Domain;

namespace Balta.Localizacao.MVVM.Core.Data
{
    public interface IRepository <T> where T : BaseModel
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
