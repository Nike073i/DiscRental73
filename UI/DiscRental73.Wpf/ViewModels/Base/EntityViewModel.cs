using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Wpf.ViewModels.Interfaces;
using MathCore.WPF.ViewModels;

namespace DiscRental73.Wpf.ViewModels.Base
{
    public abstract class EntityViewModel : ViewModel, IEntityViewModel
    {
        public abstract DtoBase Dto { get; }
    }
}
