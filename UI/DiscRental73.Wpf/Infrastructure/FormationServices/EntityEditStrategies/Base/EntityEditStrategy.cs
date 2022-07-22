using DiscRental73.Wpf.ViewModels.Base;
using DiscRental73.Wpf.ViewModels.WindowViewModels;
using DiscRental73.Wpf.Views.Windows;
using System.Windows;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base
{
    public abstract class EntityEditStrategy : IEntityEditStrategy
    {
        public abstract bool EditDialog(ref object formationData);

        protected Window CreateFormationWindow(string title, string caption, EntityViewModel vm)
        {
            var windowVm = new EntityFormationWindowViewModel
            {
                Title = title,
                Caption = caption,
                CurrentModel = vm
            };
            return new EntityFormationWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = windowVm
            };
        }
    }
}
