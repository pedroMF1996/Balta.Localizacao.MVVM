using Balta.Localizacao.MVVM.PresentetionLayer.Services;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Moq;
using Moq.AutoMock;

namespace Balta.Localizacao.MVVM.PresentationLayer.Tests
{
    public class AutenticacaoServiceTestes
    {
        [Fact(DisplayName = "Deve Realizar Login Com Sucesso")]
        [Trait("Categoria", "AutenticationServices")]
        public async Task LoginViewModel_RealizarLogin_DeveRealizarLoginComSucesso()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<LoginViewModel>().CustomInstantiator(f => new LoginViewModel()
            {
                Email = f.Internet.Email(),
                Password = f.Internet.Password()
            }).Generate();
            var service = autoMocker.CreateInstance<AutenticacaoService>();
            var signInManager = autoMocker.GetMock<SignInManager<IdentityUser>>();
            var signInResult = SignInResult.Success;
            signInManager.Setup(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(signInResult);

            // Act
            var result = await service.RealizarLogin(viewModel);

            // Assert
            Assert.True(result.ValidationResult.IsValid);
            signInManager.Verify(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once());
        }


		[Fact(DisplayName = "Nao Deve Realizar Login Por Erro de Validacao do ViewModel")]
		[Trait("Categoria", "AutenticationServices")]
		public async Task LoginViewModel_RealizarLogin_NaoDeveRealizarLogin()
		{
			// Arrange
			var autoMocker = new AutoMocker();
			var viewModel = new Faker<LoginViewModel>().CustomInstantiator(f => new LoginViewModel()
			{
				Email = "",
				Password = f.Internet.Password()
			}).Generate();
			var service = autoMocker.CreateInstance<AutenticacaoService>();

			// Act
			var result = await service.RealizarLogin(viewModel);

			// Assert
			var erros = result.ValidationResult.Errors.Select(e => e.ErrorMessage);
			Assert.False(result.ValidationResult.IsValid);
			Assert.Contains(LoginViewModelValidations.EmailRequiredErrorMessage, erros);
			Assert.Contains(LoginViewModelValidations.EmailInvalidErrorMessage, erros);
		}

		[Fact(DisplayName = "Nao Deve Realizar Login Por Erro de Credenciais")]
        [Trait("Categoria", "AutenticationServices")]
        public async Task LoginViewModel_RealizarLogin_NaoDeveRealizarLoginCredenciaisInvalidas()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<LoginViewModel>().CustomInstantiator(f => new LoginViewModel()
            {
                Email = f.Internet.Email(),
                Password = f.Internet.Password()
            }).Generate();
            var service = autoMocker.CreateInstance<AutenticacaoService>();
            var signInManager = autoMocker.GetMock<SignInManager<IdentityUser>>();
            var signInResult = SignInResult.Failed;
            signInManager.Setup(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(signInResult);

            // Act
            var result = await service.RealizarLogin(viewModel);

            // Assert
            var erros = result.ValidationResult.Errors.Select(e => e.ErrorMessage);
            Assert.False(result.ValidationResult.IsValid);
            Assert.Contains("Usuario ou senha incorretos", erros);
            signInManager.Verify(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact(DisplayName = "Nao Deve Realizar Login Por Travamento")]
        [Trait("Categoria", "AutenticationServices")]
        public async Task LoginViewModel_RealizarLogin_NaoDeveRealizarLoginPorTravamento()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<LoginViewModel>().CustomInstantiator(f => new LoginViewModel()
            {
                Email = f.Internet.Email(),
                Password = f.Internet.Password()
            }).Generate();
            var service = autoMocker.CreateInstance<AutenticacaoService>();
            var signInManager = autoMocker.GetMock<SignInManager<IdentityUser>>();
            var signInResult = SignInResult.LockedOut;
            signInManager.Setup(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .ReturnsAsync(signInResult);

            // Act
            var result = await service.RealizarLogin(viewModel);

            // Assert
            var erros = result.ValidationResult.Errors.Select(e => e.ErrorMessage);
            Assert.False(result.ValidationResult.IsValid);
            Assert.Contains("Usuario temporariamente bloqueado por tentativas invalidas", erros);
            signInManager.Verify(s => s.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()), Times.Once());
        }

        [Fact(DisplayName = "Deve Registrar Usuario Com Sucesso")]
        [Trait("Categoria", "AutenticationServices")]
        public async Task RegistrarUsuarioViewModel_RegistrarUsuario_DeveRegistrarUsuarioComSucesso()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<RegistrarUsuarioViewModel>().CustomInstantiator(f => new RegistrarUsuarioViewModel()
                {
                    Email = f.Internet.Email(),
                    Password = f.Internet.Password()
                })
                .RuleFor(vm=> vm.ConfirmPassword, (f, vm) => vm.Password).Generate();
            var service = autoMocker.CreateInstance<AutenticacaoService>();
            
            var _userManager = autoMocker.GetMock<UserManager<IdentityUser>>();
            var identityresult = IdentityResult.Success;
            _userManager.Setup(u => u.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(identityresult);

            // Act
            var result = await service.RegistrarNovoUsuario(viewModel);

            // Assert
            Assert.True(result.ValidationResult.IsValid);
            _userManager.Verify(u => u.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()), Times.Once());
        }

        [Fact(DisplayName = "Deve Registrar Usuario Com Sucesso")]
        [Trait("Categoria", "AutenticationServices")]
        public async Task RegistrarUsuarioViewModel_RegistrarUsuario_NaoDeveRegistrarUsuarioPorSenhasNaoCorresponderem()
        {
            // Arrange
            var autoMocker = new AutoMocker();
            var viewModel = new Faker<RegistrarUsuarioViewModel>().CustomInstantiator(f => new RegistrarUsuarioViewModel()
                {
                    Email = f.Internet.Email(),
                    Password = f.Internet.Password()
                })
                .RuleFor(vm=> vm.ConfirmPassword, (f, vm) => vm.Password).Generate();
            var service = autoMocker.CreateInstance<AutenticacaoService>();
            
            var _userManager = autoMocker.GetMock<UserManager<IdentityUser>>();
            var error = new IdentityErrorDescriber().PasswordMismatch();
            var identityresult = IdentityResult.Failed(new IdentityError() { Code = error.Code, Description = error.Description });

            _userManager.Setup(u => u.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()))
                .ReturnsAsync(identityresult);

            // Act
            var result = await service.RegistrarNovoUsuario(viewModel);

            // Assert
            var erros = result.ValidationResult.Errors.Select(x => x.ErrorMessage);
            Assert.False(result.ValidationResult.IsValid);
            Assert.Contains(error.Description, erros);
            _userManager.Verify(u => u.CreateAsync(It.IsAny<IdentityUser>(), It.IsAny<string>()), Times.Once());
        }
    }
}
