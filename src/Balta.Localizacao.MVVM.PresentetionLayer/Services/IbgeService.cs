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

        public async Task<CustomResponse<IbgeModel>> AdicionarIbge(IbgeAdicionarViewModel viewModel)


        {
            var ibgeModel = new IbgeModel(viewModel.Id, viewModel.State, viewModel.City);

            if (!ibgeModel.IsValid())
            {
                ibgeModel.ValidationResult.Errors.ForEach(async x => await AdicionarErro(x.ErrorMessage));

                return CustomResponse;
            }

            await _repository.AdicionarIbge(ibgeModel);

            await _repository.UnitOfWork.Commit();

            return CustomResponse;


        }

        public async Task<CustomResponse<IbgeModel>> AtualizarIbge(IbgeAtualizarViewModel viewModel, string id)
        {
            var ibgesModel = await _repository.ObterIbgesModel(new BuscarPorIbgeIdSpecification(id));

            if (ibgesModel.Count() == 0)
            {
                await AdicionarErro("Não existe esse Ibge");

            }

            var ibgeModel = ibgesModel.Single();

            await ibgeModel.SetState(viewModel.State);
            await ibgeModel.SetCity(viewModel.City);
            await ibgeModel.SetId(viewModel.Id);

            await _repository.EditarIbgeModel(ibgeModel);

            await _repository.UnitOfWork.Commit();

            return CustomResponse;
        }

        public async Task<CustomResponse<IbgeModel>> RemoveIbge(IbgeExcluirViewModel viewModel)
        {
            var ibgesModel = await _repository.ObterIbgesModel(new BuscarPorIbgeIdSpecification(viewModel.Id));


            if (ibgesModel.Count() == 0)
            {
                await AdicionarErro("Não existe esse Ibge");

            }

            var ibgeModel = ibgesModel.Single();

            await _repository.RemoverIbgeModel(ibgeModel);

            await _repository.UnitOfWork.Commit();

            return CustomResponse;
        }

    }
}
