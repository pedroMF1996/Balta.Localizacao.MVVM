﻿using Balta.Localizacao.MVVM.Core.Presentaion;
using Balta.Localizacao.MVVM.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Balta.Localizacao.MVVM.PresentetionLayer.ViewModels.IbgeViewModels
{
    public sealed class IbgeListarViewModel : IBaseViewModel
    {
        public string City { get; set; }
        public string State { get; set; }

        [MaxLength(7, ErrorMessage = "O campo Codigo deve conter 7 caracteres.")]
        [RegularExpression("/[^0-9]/", ErrorMessage = "O campo Codigo deve conter apenas numeros.")]
        public string Id { get; set; }
        public int Size { get; set; } = int.MaxValue;
        public int Skip { get; set; } = 0;
        public IEnumerable<IbgeModel> Ibges { get; set; }
    }
}
