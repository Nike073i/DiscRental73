﻿using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using System;
using System.Collections.Generic;
using DiscRental73.Domain.DtoModels.Dto;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class IssueSellFormationViewModel : FormationViewModel
    {
        #region Ограничения на ввод данных 

        public DateTime DateMaxValue { get; set; }

        public DateTime DateMinValue { get; set; }

        #endregion

        #region IssueSellBindingModel IssueSellBindingModel - модель оформления продажи

        private IssueSellBindingModel _IssueSellBindingModel;

        /// <summary>Модель оформления продажи</summary>
        public IssueSellBindingModel IssueSellBindingModel
        {
            get => _IssueSellBindingModel;
            set => Set(ref _IssueSellBindingModel, value);
        }

        #endregion

        #region ProductDto SelectedProduct - выбранный продукт

        private ProductDto _SelectedProduct;
        public ProductDto SelectedProduct
        {
            get => _SelectedProduct;
            set => Set(ref _SelectedProduct, value);
        }

        #endregion

        #region Products IEnumerable - список доступных продуктов 

        private IEnumerable<ProductDto> _Products;

        public IEnumerable<ProductDto> Products
        {
            get => _Products;
            set => Set(ref _Products, value);
        }

        #endregion
    }
}
