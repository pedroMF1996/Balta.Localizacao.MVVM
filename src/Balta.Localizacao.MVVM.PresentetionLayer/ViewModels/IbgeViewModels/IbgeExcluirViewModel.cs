using Balta.Localizacao.MVVM.Core.Presentaion;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public sealed class IbgeExcluirViewModel : BaseViewModel
    {
        [Required(ErrorMessage = " campo Codigo é obrigatorio.")]
        [MaxLength(7, ErrorMessage = "O campo Codigo deve conter 7 caracteres.")]
        [RegularExpression("/[^0-9]/", ErrorMessage = "O campo Codigo deve conter apenas numeros.")]
        public string Id { get; set; }
    }
}
