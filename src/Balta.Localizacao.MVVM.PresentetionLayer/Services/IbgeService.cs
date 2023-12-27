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
            var ibge = await _repository.ObterIbgeModelPorId(viewModel.Id);

            if (ibge is null)
            {
                await AdicionarErro("Não existe esse Ibge");
                return CustomResponse;
            }

            if (!await ibge.SetState(viewModel.State) && !await ibge.SetCity(viewModel.City) && !await ibge.SetId(viewModel.Id))
            {
                await AdicionarErro("Registro IBGE não atualizado.");
                return CustomResponse;
            }

            await _repository.EditarIbgeModel(ibge);

            await AtribuirViewModel(viewModel);

            return await PersistirDados(_repository.UnitOfWork);
        }

        public async Task<CustomResponse> ObterIbgePorId(IbgeObterPorIdViewModel viewModel)
        {
            var ibge = await _repository.ObterIbgeModelPorId(viewModel.Id);
            
            if (ibge is null)
            {
                await AdicionarErro("Não existe esse Ibge");
                return CustomResponse;
            }

            IbgeObterPorIdResultViewModel result = new(){
               Id= ibge.Id,
               State = ibge.State,
               City = ibge.City
            };
            await AtribuirViewModel(result);
            return CustomResponse;
        }

        public async Task<CustomResponse> ListarIbge(IbgeListarViewModel viewModel)
        {
            IEnumerable<IbgeModel> result = await ObterIbgesModel(viewModel);

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
            var ibgeModel = await _repository.ObterIbgeModelPorId(viewModel.Id);
            
            if (ibgeModel is null)
            {
                await AdicionarErro("Não existe esse Ibge");
                return CustomResponse;
            }

            await _repository.RemoverIbgeModel(ibgeModel);

            return await PersistirDados(_repository.UnitOfWork);
        }

        private async Task<IEnumerable<IbgeModel>> ObterIbgesModel(IbgeListarViewModel viewModel)
        {
            IEnumerable<IbgeModel> result;

            if (BuscarPorCityStateIdSpecification.IsValid([viewModel.Id, viewModel.State, viewModel.City]))
                result = await _repository.ObterIbgesModel(new BuscarPorCityStateIdSpecification(viewModel.City,
                                                                                                  viewModel.State,
                                                                                                  viewModel.Id,
                                                                                                  viewModel.Size,
                                                                                                  viewModel.Skip));
            else if (BuscarPorStateIdSpecification.IsValid([viewModel.Id, viewModel.State]))
                result = await _repository.ObterIbgesModel(new BuscarPorStateIdSpecification(viewModel.State, viewModel.Id));
            else if (BuscarPorStateCitySpecification.IsValid([viewModel.State, viewModel.City]))
                result = await _repository.ObterIbgesModel(new BuscarPorStateCitySpecification(viewModel.State, viewModel.City));
            else if (BuscarPorCityIdSpecification.IsValid([viewModel.Id, viewModel.City]))
                result = await _repository.ObterIbgesModel(new BuscarPorCityIdSpecification(viewModel.City, viewModel.Id));
            else if (BuscarPorIbgeIdSpecification.IsValid([viewModel.Id]))
                result = await _repository.ObterIbgesModel(new BuscarPorIbgeIdSpecification(viewModel.Id));
            else if (BuscarPorCitySpecification.IsValid([viewModel.City]))
                result = await _repository.ObterIbgesModel(new BuscarPorCitySpecification(viewModel.City));
            else if (BuscarPorStateSpecification.IsValid([viewModel.State]))
                result = await _repository.ObterIbgesModel(new BuscarPorStateSpecification(viewModel.State));
            else
                result = await _repository.ObterIbgesModel();

            return result;
        }
    }
}
