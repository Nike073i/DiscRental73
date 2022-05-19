using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using DiscRental73TestWpf.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Windows;

namespace DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies
{
    public class ShowIssueRentalStrategy : ShowContentWindowStrategy
    {
        public IEnumerable<ProductResDto>? Products { get; set; }
        public IEnumerable<ClientResDto>? Clients { get; set; }

        public override bool ShowDialog(ref object formationData)
        {
            if (formationData == null) throw new ArgumentNullException(nameof(formationData));
            if (formationData is not IssueRentalBindingModel item)
            {
                return false;
            }

            item.DateOfIssue = DateTime.Now;
            item.DateOfReturn = DateTime.Now.AddDays(7);

            var viewModel = App.Host.Services.GetRequiredService<IssueRentalFormationViewModel>();
            viewModel.Products = Products ?? new List<ProductResDto>();
            viewModel.Clients = Clients ?? new List<ClientResDto>();
            viewModel.IssueRentalBindingModel = item;

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно оформления проката";
            viewModelWindow.Caption = "Прокат";

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

            if (!IsCompletedData(viewModel)) return false;

            var inputData = viewModel.IssueRentalBindingModel;
            inputData.ProductId = viewModel.SelectedProduct.Id;
            inputData.ClientId = viewModel.SelectedClient.Id;

            formationData = inputData;

            return true;
        }

        private bool IsCompletedData(IssueRentalFormationViewModel viewModel)
        {
            if (viewModel.SelectedProduct is null) return false;
            if (viewModel.SelectedClient is null) return false;

            return true;
        }
    }
}
