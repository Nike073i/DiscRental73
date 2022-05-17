﻿using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices
{
    public class ViewEditProductQuantityFormationService : WindowDataFormationService<EditProductQuantityModel>, IFormationService
    {
        protected override bool EditData(ref EditProductQuantityModel dto)
        {
            if (dto is not EditProductQuantityModel item)
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
                Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            dto.EditQuantity = viewModel.EditQuantity;

            return true;
        }
    }
}
