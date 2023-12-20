using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Data.IbgeSpecifications;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Services
{
    public class IbgeService : BaseService<IbgeModel>
    {
        private readonly IIbgeRepository _repository;
        public IbgeService(IIbgeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CustomResponse> AdicionarIbge(IbgeAdicionarViewModel viewModel)
        {
            var ibgeModel = new IbgeModel(viewModel.Id, viewModel.State, viewModel.City);

            if (!ibgeModel.IsValid())
            {
                ibgeModel.ValidationResult.Errors.ForEach(async x => await CustomResponse.AdicionarErro(x.ErrorMessage));
                await AtribuirViewModel(viewModel);
                return CustomResponse;
            }

            await _repository.AdicionarIbge(ibgeModel);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<CustomResponse> AtualizarIbge(IbgeAtualizarViewModel viewModel, string id)
        {
            var ibgesModel = await _repository.ObterIbgesModel(new BuscarPorIbgeIdSpecification(id));
            
            if (ibgesModel.Count() == 0)
            {
                await AdicionarErro("Não existe esse Ibge");

                return CustomResponse;
            }

            var ibgeModel = ibgesModel.Single();

            await ibgeModel.SetState(viewModel.State);
            await ibgeModel.SetCity(viewModel.City);
            await ibgeModel.SetId(viewModel.Id);

            await _repository.EditarIbgeModel(ibgeModel);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<CustomResponse> ListarIbge(IbgeListarViewModel viewModel)
        {
            IEnumerable<IbgeModel> result;

            if (string.IsNullOrEmpty(viewModel.Id) && string.IsNullOrEmpty(viewModel.State) && string.IsNullOrEmpty(viewModel.City))
                result = await _repository.ObterIbgesModel();
            else
                result = await _repository.ObterIbgesModel(new
                    BuscarPorCityStateIdSpecification(
                    viewModel.City,
                    viewModel.State,
                    viewModel.Id,
                    viewModel.Size,
                    viewModel.Skip)); 
            viewModel.Ibges = result;

            if(result.Count() == 0)
            {
              return CustomResponse;
            }

            await AtribuirViewModel(viewModel);

            return CustomResponse;
        }

        public async Task<CustomResponse> RemoveIbge(IbgeExcluirViewModel viewModel)
        {
            var ibgesModel = await _repository.ObterIbgesModel(new BuscarPorIbgeIdSpecification(viewModel.Id));
            
            if (ibgesModel.Count() == 0)
            {
                await AdicionarErro("Não existe esse Ibge");

                return CustomResponse;
            }

            var ibgeModel = ibgesModel.Single();

            await _repository.RemoverIbgeModel(ibgeModel);

            return await PersistirDados(_repository.UnitOfWork);
        }
    }
}
