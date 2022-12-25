using DiscRental73.Domain.DtoModels.Base;
using DiscRental73.Interfaces.Dto;
using DiscRental73.Interfaces.Services.Base;
using DiscRental73.Wpf.ViewModels.Interfaces;
using MathCore.ViewModels;
using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73.Wpf.ViewModels.Base
{
    public abstract class ActionViewModel<TDto> : ViewModel, IActionViewModel<TDto>
        where TDto : DtoBase
    {
        #region fields

        private readonly IService<TDto> _Service;

        #endregion

        #region constructors

        protected ActionViewModel(IService<TDto> service)
        {
            _Service = service;
        }

        #endregion

        #region properties

        public Action<TDto?>? OnChangedSelectedItemAction { get; set; }

        #region selected items

        private TDto? _SelectedItem;

        public TDto? SelectedItem
        {
            get => _SelectedItem;
            set
            {
                if (Set(ref _SelectedItem, value))
                    OnChangedSelectedItemAction?.Invoke(value);
            }
        }

        #endregion

        #region ActionHeader : string - Заголовок представления действий с сущностью

        /// <summary>Заголовок представления действий с сущностью</summary>
        private string _ActionHeader = "Список действий";

        /// <summary>Заголовок представления действий с сущностью</summary>
        public string ActionHeader
        {
            get => _ActionHeader;
            set => Set(ref _ActionHeader, value);
        }

        #endregion

        #region items

        private IEnumerable<TDto>? _Items;
        public IEnumerable<TDto>? Items
        {
            get => _Items;
            private set => Set(ref _Items, value);
        }

        #endregion

        #endregion

        #region commands

        #region RefreshCommand - обновление списка элементов

        private ICommand? _RefreshCommand;

        public ICommand RefreshCommand => _RefreshCommand ??= new LambdaCommand(OnExecutedRefreshCommand);

        private void OnExecutedRefreshCommand(object? p) => RefreshItems();

        #endregion

        #endregion

        #region protected methods

        protected void RefreshItems() => Items = _Service.GetAll();

        #endregion
    }

    public abstract class ActionViewModel<TDto, TDetailDto> : ActionViewModel<TDto>
        where TDto : DtoBase
        where TDetailDto : DtoBase, IDetailDto
    {
        private readonly IService<TDto, TDetailDto> _DetailService;
        protected ActionViewModel(IService<TDto, TDetailDto> service)
            : base(service)
        {
            _DetailService = service;
        }
    }
}
