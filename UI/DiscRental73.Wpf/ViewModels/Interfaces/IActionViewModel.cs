using DiscRental73.Domain.DtoModels.Base;
using System;
using System.Collections.Generic;

namespace DiscRental73.Wpf.ViewModels.Interfaces
{
    public interface IActionViewModel<TDto> where TDto : DtoBase
    {
        Action<TDto?>? OnChangedSelectedItemAction { get; set; }
        TDto? SelectedItem { get; }
        IEnumerable<TDto>? Items { get; }
    }
}
