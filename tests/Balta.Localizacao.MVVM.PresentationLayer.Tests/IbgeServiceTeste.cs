using Balta.Localizacao.MVVM.PresentetionLayer.Services;
using Bogus;
using Moq.AutoMock;
using Moq;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels;
using Balta.Localizacao.MVVM.Domain.Interfaces;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.Core.Data;
using Balta.Localizacao.MVVM.Data.IbgeSpecifications;
using Balta.Localizacao.MVVM.Domain.Specification;
using Balta.Localizacao.MVVM.Core.Presentaion;

namespace Balta.Localizacao.MVVM.PresentationLayer.Tests
{
    public class IbgeServiceTeste
    {
        [Fact(DisplayName = "Deve Cadastrar um Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Deve_Cadastrar_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<IbgeAdicionarViewModel>().CustomInstantiator(f => new IbgeAdicionarViewModel()
            {
                City=f.Address.City(),
                State="MA",
                Id="1234567",
                
            }).Generate();

            var service = autoMocker.CreateInstance<IbgeService>();
           
            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.AdicionarIbge(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);
    
            // Act
            var result = await service.AdicionarIbge(viewModel);

            // Assert
            Assert.True(await result.IsCompleted());
      
        }

        [Fact(DisplayName = "Deve não cadastrar Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Nao_Deve_Cadastrar_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<IbgeAdicionarViewModel>().CustomInstantiator(f => new IbgeAdicionarViewModel()
            {
                City = f.Address.City(),
                State = "MAS",
                Id = "1234567",

            }).Generate();

            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.AdicionarIbge(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.AdicionarIbge(viewModel);

            // Assert
            Assert.False(await result.IsCompleted());


        }



        [Fact(DisplayName = "Deve atualizar Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Deve_Atualizar_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeAtualizarViewModel>().CustomInstantiator(f => new IbgeAtualizarViewModel()
            {
                City = f.Address.City(),
                State = "MA",
                Id = "1234567",

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id,"MA","TESTE");

            

            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.EditarIbgeModel(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.ObterIbgesModel(It.IsAny<ISpecification<IbgeModel>>())).ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.AtualizarIbge(viewModel, viewModel.Id);

            // Assert
            Assert.True(await result.IsCompleted());


        }


        [Fact(DisplayName = "Deve não atualizar Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Nao_Deve_Atualizar_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeAtualizarViewModel>().CustomInstantiator(f => new IbgeAtualizarViewModel()
            {
                City = f.Address.City(),
                State = "MA",
                Id = "1234567",

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id, "MA", "TESTE");



            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.EditarIbgeModel(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.ObterIbgesModel(new BuscarPorIbgeIdSpecification(viewModel.Id))).ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.AtualizarIbge(viewModel, viewModel.Id);

            // Assert
            Assert.False(await result.IsCompleted());


        }


        [Fact(DisplayName = "Deve remove Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Deve_Remove_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeExcluirViewModel>().CustomInstantiator(f => new IbgeExcluirViewModel()
            {
                Id = "1234567",

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id, "MA", "TESTE");



            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.RemoverIbgeModel(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.ObterIbgesModel(It.IsAny<ISpecification<IbgeModel>>())).ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.RemoveIbge(viewModel);

            // Assert
            Assert.True(await result.IsCompleted());


        }


        [Fact(DisplayName = "Deve não remove Ibge ")]
        [Trait("Categoria", "IbgeService")]
        public async Task Nao_Deve_Remove_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeExcluirViewModel>().CustomInstantiator(f => new IbgeExcluirViewModel()
            {
                Id = "1234567",

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id, "MA", "TESTE");



            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.RemoverIbgeModel(It.IsAny<IbgeModel>())).Returns(Task.CompletedTask);

            ibgeRepository.Setup(s => s.ObterIbgesModel(new BuscarPorIbgeIdSpecification(viewModel.Id))).ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.RemoveIbge(viewModel);

            // Assert
            Assert.False(await result.IsCompleted());


        }


        [Fact(DisplayName = "Deve encontra ibge")]
        [Trait("Categoria", "IbgeService")]
        public async Task Deve_Encontra_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeListarViewModel>().CustomInstantiator(f => new IbgeListarViewModel()
            {
                City = f.Address.City(),
                State = "MA",
                Id = "1234567",

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id, "MA", "TESTE");

            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.ObterIbgesModel(It.IsAny<ISpecification<IbgeModel>>())).ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            // Act
            var result = await service.ListarIbge(viewModel);

            // Assert
            Assert.True(await result.IsCompleted());


        }


        [Fact(DisplayName = "Deve retorna uma Lista vazia de ibge")]
        [Trait("Categoria", "IbgeService")]
        public async Task Deve_Retorna_Uma_Lista_Vazia_De_Ibge()
        {
            // Arrange
            var autoMocker = new AutoMocker();

            var viewModel = new Faker<IbgeListarViewModel>().CustomInstantiator(f => new IbgeListarViewModel()
            {
                City = f.Address.City(),
                State = "MA",
                Id = "1234567",
                Size=0,
                Skip=10

            }).Generate();

            var ibgeModel = new IbgeModel(viewModel.Id, "MA", "TESTE");

            var service = autoMocker.CreateInstance<IbgeService>();

            var ibgeRepository = autoMocker.GetMock<IIbgeRepository>();

            var unitWork = autoMocker.GetMock<IUnitOfWork>();

            unitWork.Setup(s => s.Commit()).Returns(Task.FromResult(true));

            ibgeRepository.Setup(s => s.ObterIbgesModel(new BuscarPorCityStateIdSpecification(
                viewModel.City,
                viewModel.State,
                viewModel.State,
                viewModel.Size,
                viewModel.Skip)))
                .ReturnsAsync(new List<IbgeModel>()
            {
                ibgeModel
            });

            ibgeRepository.Setup(s => s.UnitOfWork).Returns(unitWork.Object);

            var customerResponse = new CustomResponse();
            // Act
            var result = await service.ListarIbge(viewModel);

            // Assert
            Assert.Equal(customerResponse.Errors,result.Errors);


        }


    }
}
