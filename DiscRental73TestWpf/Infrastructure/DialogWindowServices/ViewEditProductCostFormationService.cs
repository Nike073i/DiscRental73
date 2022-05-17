using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewEditProductCostFormationService : WindowDataFormationService<EditProductCostModel>, IFormationService
    {
        protected override bool EditData(ref EditProductCostModel dto)
        {
            if (dto is not EditProductCostModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<EditProductCostFormationViewModel>();

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно изменения цены продукта";
            viewModelWindow.Caption = string.Format("Продукт - {0}, цена - {1}", item.DiscTitle, item.CurrentCost);

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto.NewCost = viewModel.NewCost;

            return true;
        }
    }
}
