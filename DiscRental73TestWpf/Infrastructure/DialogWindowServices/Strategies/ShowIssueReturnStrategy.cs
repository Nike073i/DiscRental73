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
    public class ShowIssueReturnStrategy : IShowContentStrategy
    {
        #region Ограничения на ввод данных 

        public double ReturnSumMaxValue { get; set; }
        public double ReturnSumMinValue { get; set; }

        #endregion

        public IEnumerable<RentalResDto>? Rentals { get; set; }

        public bool ShowDialog(ref object formationData)
        {
            if (formationData is not IssueReturnBindingModel item)
            {
                return false;
            }

            var viewModel = App.Host.Services.GetRequiredService<IssueReturnFormationViewModel>();
            viewModel.Rentals = Rentals ?? new List<RentalResDto>();
            viewModel.IssueReturnBindingModel = item;
            SetValueRange(viewModel);

            var viewModelWindow = App.Host.Services.GetRequiredService<EntityFormationWindowViewModel>();
            viewModelWindow.CurrentModel = viewModel;
            viewModelWindow.Title = "Окно оформления возврата проката";
            viewModelWindow.Caption = "Возврат";

            var dlg = new EntityFormationWindow
            {
                DataContext = viewModelWindow,
                //Owner = ActiveWindow,
                WindowStartupLocation = WindowStartupLocation.CenterOwner
            };

            if (dlg.ShowDialog() != true)
            {
                return false;
            }

            if (!IsCompletedData(viewModel)) return false;

            var inputData = viewModel.IssueReturnBindingModel;
            inputData.RentalId = viewModel.SelectedRental.Id;

            formationData = inputData;

            return true;
        }

        private bool IsCompletedData(IssueReturnFormationViewModel viewModel)
        {
            if (viewModel.SelectedRental is null) return false;

            return true;
        }
        private void SetValueRange(IssueReturnFormationViewModel viewModel)
        {
            viewModel.ReturnSumMaxValue = ReturnSumMaxValue;
            viewModel.ReturnSumMinValue = ReturnSumMinValue;
        }
    }
}
