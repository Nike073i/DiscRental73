using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
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
        private readonly IFormationService _dialogService;

        public ProductManagementViewModel(ProductService productService, WindowProductFormationService dialogService, DiscService discService,  dialogService)
        {
            _service = productService;
            _productDialogService = dialogService;
            _discService = discService;

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
            _dialogService.Discs = _discService.GetDiscs();

            if (!_dialogService.Edit(item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item);
                _service.Create(reqDto);
                _dialogService.ShowInformation("Запись создана", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка создания");
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
                _dialogService.ShowInformation("Доступность изменена", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка изменения доступности");
            }
        }

        #endregion

        #region ChangeQuantityCommand - изменение количества элемента

        private ICommand _ChangeQuantityCommand;

        public ICommand ChangeQuantityCommand => _ChangeQuantityCommand ??= new LambdaCommand(OnChangeQuantityCommand, CanChangeQuantityCommand);

        private bool CanChangeQuantityCommand(object? p) => p is ProductResDto;

        private void OnChangeQuantityCommand(object? p)
        {
            var product = p as ProductResDto;
            var model = new EditProductQuantityModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentQuantity = product.Quantity,
                EditQuantity = 5
            };
            if (!_dialogService.Edit(model)) return;
            try
            {
                _service.EditProductQuantity(new EditProductQuantityReqDto
                {
                    ProductId = model.ProductId,
                    EditQuantity = model.EditQuantity
                });
                _dialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Products));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

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
