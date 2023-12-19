using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity; 

namespace Balta.Localizacao.MVVM.PresentetionLayer.Services
{
    public class AutenticacaoService : BaseService<AutenticacaoModel>
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        
        public AutenticacaoService(SignInManager<IdentityUser> signInManager,
                                   UserManager<IdentityUser> userManager,
                                   IAuthenticationService authenticationService,
                                   IHttpContextAccessor httpContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authenticationService = authenticationService;
            _httpContext = httpContext;
        }

        public async Task<CustomResponse<AutenticacaoModel>> RealizarLogin(LoginViewModel viewModel)
        {
            if(!viewModel.EhValido())
            {
                await AdicionarErro(viewModel.ValidationResult);
                return CustomResponse;
            }    

            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);

            if (result.Succeeded)
                return CustomResponse;
            

            if (result.IsLockedOut)
            {
                await AdicionarErro("Usuario temporariamente bloqueado por tentativas invalidas");
                return CustomResponse;
            }

            await AdicionarErro("Usuario ou senha incorretos");
            return CustomResponse;
        }
        
        public async Task<CustomResponse<AutenticacaoModel>> RegistrarNovoUsuario(RegistrarUsuarioViewModel viewModel)
        {
			if (!viewModel.EhValido())
			{
				await AdicionarErro(viewModel.ValidationResult);
				return CustomResponse;
			}

			var user = new IdentityUser()
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);
                return CustomResponse;
            }
            

            foreach (var error in result.Errors)
            {
                await AdicionarErro(error.Description);
            }

            return CustomResponse;
        }

        public async Task Logout()
        {
            await _authenticationService.SignOutAsync(_httpContext.HttpContext, CookieAuthenticationDefaults.AuthenticationScheme, null);
        }
    }
}
