namespace Balta.Localizacao.MVVM.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
