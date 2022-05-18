using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowProductQuantityStrategy : ShowContentWindowStrategy
    {
        public ShowProductQuantityStrategy(Window activeWindow) : base(activeWindow)
        {
        }

        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not EditProductQuantityModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<EditProductQuantityFormationViewModel>();

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно изменения количества продукта";
            viewModelWindow.Caption = string.Format("Продукт - {0}, количество - {1}", item.DiscTitle, item.CurrentQuantity);

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                Owner = _activeWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            formationData = viewModel.EditQuantity;

            return true;
        }
    }
}