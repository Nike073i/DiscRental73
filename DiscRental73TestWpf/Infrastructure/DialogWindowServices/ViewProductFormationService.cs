using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewProductFormationService : WindowProductFormationService, IFormationService
    {
        protected override bool EditData(ref ProductResDto dto)
        {
            if (dto is not ProductResDto item)
            {
                return false;
            }

            if (item.Id.Equals(0))
            {
                item.IsAvailable = true;
            }

            var viewModel = App.Host.Services.GetRequiredService<ProductFormationViewModel>();
            viewModel.Product = item;
            viewModel.Discs = Discs;

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно создания продукта";
            viewModelWindow.Caption = "Продукт";

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

            dto = viewModel.Product;

            return true;
        }
    }
}
