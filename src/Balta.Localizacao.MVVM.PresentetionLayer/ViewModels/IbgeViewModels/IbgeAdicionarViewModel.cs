using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public sealed class IbgeAdicionarViewModel : BaseViewModel<IbgeModel>
    {
        [Required(ErrorMessage = " campo Codigo é obrigatorio.")]
        [MaxLength(7,ErrorMessage = "O campo Codigo deve conter 7 caracteres.")]
        [RegularExpression("/[^0-9]/",ErrorMessage = "O campo Codigo deve conter apenas numeros.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo Estado é obrigatorio.")]
        [MaxLength(2,ErrorMessage = "O código Estado conter até 2 caracteres")]
        public string State { get; set; }
        [Required(ErrorMessage = "O campo Cidade é obrigatorio.")]
        public string City { get; set; }
    }
}
