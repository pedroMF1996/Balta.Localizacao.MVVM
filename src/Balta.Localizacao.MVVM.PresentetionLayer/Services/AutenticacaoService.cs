using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.Configurations;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Services
{
    public class AutenticacaoService : BaseService<AutenticacaoModel>
    {
        
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSetings _appSettings;

        public AutenticacaoService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<AppSetings> appSettings)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        public async Task<CustomResponse<AutenticacaoModel>> RealizarLogin(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse;
            }

            if (result.IsLockedOut)
            {
                AdicionarErro("Usuario temporariamente bloqueado por tentativas invalidas");
                return CustomResponse;
            }

            AdicionarErro("Usuario ou senha incorretos");
            return CustomResponse;
        }
        
        public async Task<CustomResponse<AutenticacaoModel>> RegistrarNovoUsuario(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse;
            }

            if (result.IsLockedOut)
            {
                AdicionarErro("Usuario temporariamente bloqueado por tentativas invalidas");
                return CustomResponse;
            }

            AdicionarErro("Usuario ou senha incorretos");
            return CustomResponse;
        }
    }
}
