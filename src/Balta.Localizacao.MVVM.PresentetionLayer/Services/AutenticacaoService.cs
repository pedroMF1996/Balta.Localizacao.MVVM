using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.AutenticaoViewModels;
using Microsoft.AspNetCore.Identity;

namespace Balta.Localizacao.MVVM.PresentetionLayer.Services
{
    public class AutenticacaoService : BaseService<AutenticacaoModel>
    {
        
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AutenticacaoService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<CustomResponse<AutenticacaoModel>> RealizarLogin(LoginViewModel viewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, true);

            if (result.Succeeded)
                return CustomResponse;
            

            if (result.IsLockedOut)
            {
                AdicionarErro("Usuario temporariamente bloqueado por tentativas invalidas");
                return CustomResponse;
            }

            AdicionarErro("Usuario ou senha incorretos");
            return CustomResponse;
        }
        
        public async Task<CustomResponse<AutenticacaoModel>> RegistrarNovoUsuario(RegistrarUsuarioViewModel viewModel)
        {
            var user = new IdentityUser()
            {
                UserName = viewModel.Email,
                Email = viewModel.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
                return CustomResponse;
            

            foreach (var error in result.Errors)
            {
                AdicionarErro(error.Description);
            }

            return CustomResponse;
        }
    }
}
