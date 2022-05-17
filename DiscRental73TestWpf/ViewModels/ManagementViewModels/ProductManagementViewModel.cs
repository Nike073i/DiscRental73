using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class ProductManagementViewModel : ViewModel
    {
        private readonly ProductService _service;
        private readonly DiscService _discService;
        private readonly WindowProductFormationService _productDialogService;
        private readonly IFormationService _EditProductQuantityDialogService;
        private readonly IFormationService _EditProductCostDialogService;

        public ProductManagementViewModel(ProductService productService,
            ViewProductFormationService dialogService, DiscService discService,
            ViewEditProductQuantityFormationService editProductQuantityService,
            ViewEditProductCostFormationService editProductCostService)
        {
            _service = productService;
            _productDialogService = dialogService;
            _discService = discService;
            _EditProductQuantityDialogService = editProductQuantityService;
            _EditProductCostDialogService = editProductCostService;
        }

        public IEnumerable<ProductResDto> Products => _service.GetAll();

        #region SelectedProduct - ProductResDto - модель выбранного продукта

        private ProductResDto _SelectedProduct;

        public ProductResDto SelectedProduct
        {
            get => _SelectedProduct;
            set => Set(ref _SelectedProduct, value);
        }

        #endregion

        #region CreateNewProductCommand - создание продукта

        private ICommand _CreateNewProductCommand;

        public ICommand CreateNewProductCommand => _CreateNewProductCommand ??= new LambdaCommand(OnCreateNewProductCommand);

        private void OnCreateNewProductCommand(object? p)
        {
            var item = new ProductResDto();
            _productDialogService.Discs = _discService.GetDiscs();

            if (!_productDialogService.Edit(item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item);
                _service.Create(reqDto);
                _productDialogService.ShowInformation("Запись создана", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _productDialogService.ShowWarning(ex.Message, "Ошибка создания");
            }
        }

        #endregion

        #region ChangeAvailableProductCommand - команда изменения доступности продукта

        private ICommand _ChangeAvailableProductCommand;

        public ICommand ChangeAvailableProductCommand => _ChangeAvailableProductCommand ??= new LambdaCommand(OnChangeAvailableProduct, CanChangeAvailableProduct);

        private bool CanChangeAvailableProduct(object? p) => p is ProductResDto;

        private void OnChangeAvailableProduct(object? p)
        {
            try
            {
                var resDto = p as ProductResDto;
                var reqDto = new ChangeProductAvailable
                {
                    ProductId = resDto.Id,
                    IsAvailable = !resDto.IsAvailable
                };
                _service.ChangeAvailable(reqDto);
                _EditProductQuantityDialogService.ShowInformation("Доступность изменена", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _EditProductQuantityDialogService.ShowWarning(ex.Message, "Ошибка изменения доступности");
            }
        }

        #endregion

        #region ChangeQuantityCommand - изменение количества элемента

        private ICommand _EditQuantityCommand;

        public ICommand EditQuantityCommand => _EditQuantityCommand ??= new LambdaCommand(OnEditQuantityCommand, CanEditQuantityCommand);

        private bool CanEditQuantityCommand(object? p) => p is ProductResDto;

        private void OnEditQuantityCommand(object? p)
        {
            var product = p as ProductResDto;
            var model = new EditProductQuantityModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentQuantity = product.Quantity,
                EditQuantity = 5
            };
            if (!_EditProductQuantityDialogService.Edit(model)) return;
            try
            {
                _service.EditProductQuantity(new EditProductQuantityReqDto
                {
                    ProductId = model.ProductId,
                    EditQuantity = model.EditQuantity
                });
                _EditProductQuantityDialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _EditProductQuantityDialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

        #endregion

        #region ChangeCostCommand - изменение стоимости элемента

        private ICommand _ChangeCostCommand;

        public ICommand ChangeCostCommand => _ChangeCostCommand ??= new LambdaCommand(OnChangeCostCommand, CanChangeCostCommand);

        private bool CanChangeCostCommand(object? p) => p is ProductResDto;

        private void OnChangeCostCommand(object? p)
        {
            var product = p as ProductResDto;
            var model = new EditProductCostModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentCost = product.Cost,
            };
            if (!_EditProductCostDialogService.Edit(model)) return;
            try
            {
                _service.ChangeProductCost(new ChangeProductCostReqDto
                {
                    ProductId = model.ProductId,
                    Cost = model.NewCost
                });
                _EditProductCostDialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _EditProductCostDialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

        #endregion

        #region RefreshCommand - обновление списка элементов

        private ICommand _RefreshCommand;

        public ICommand RefreshCommand => _RefreshCommand ??= new LambdaCommand(OnRefreshCommand, CanRefreshCommand);

        private bool CanRefreshCommand(object? p) => _service is not null;

        private void OnRefreshCommand(object? p) => OnPropertyChanged(nameof(Products));

        #endregion

        private ProductReqDto CreateReqDtoToCreate(ProductResDto resDto)
        {
            var reqDto = new ProductReqDto
            {
                DiscId = resDto.DiscId,
                Cost = resDto.Cost,
                Quantity = resDto.Quantity,
                IsAvailable = resDto.IsAvailable,
            };
            return reqDto;
        }
    }
}
