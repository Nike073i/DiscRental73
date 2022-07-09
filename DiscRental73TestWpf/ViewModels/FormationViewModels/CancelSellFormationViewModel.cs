using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CancelSellFormationViewModel : FormationViewModel
    {
        #region SellDto SelectedSell - выбранная продажа

        private SellDto _SelectedSell;
        public SellDto SelectedSell
        {
            get => _SelectedSell;
            set => Set(ref _SelectedSell, value);
        }

        #endregion

        #region Sells IEnumerable - список всех доступных продаж 

        private IEnumerable<SellDto> _Sells;

        public IEnumerable<SellDto> Sells
        {
            get => _Sells;
            set => Set(ref _Sells, value);
        }

        #endregion

        #region DailySells IEnumerable - список продаж по дате 

        private IEnumerable<SellDto> _DailySells;

        public IEnumerable<SellDto> DailySells
        {
            get => _DailySells;
            set => Set(ref _DailySells, value);
        }

        #endregion

        #region DateTime DateOfSell - выбранная дата продажи

        private DateTime _DateOfSell;

        public DateTime DateOfSell
        {
            get => _DateOfSell;
            set
            {
                Set(ref _DateOfSell, value);
                DailySells = Sells.Where(rec => rec.DateOfSell == value).ToList();
            }
        }

        #endregion

        #region CancelSellBindingModel CancelSellBindingModel - модель отмены продажи

        private CancelSellBindingModel _CancelSellBindingModel;

        /// <summary>Модель отмены продажи</summary>
        public CancelSellBindingModel CancelSellBindingModel
        {
            get => _CancelSellBindingModel;
            set => Set(ref _CancelSellBindingModel, value);
        }

        #endregion
    }
}
