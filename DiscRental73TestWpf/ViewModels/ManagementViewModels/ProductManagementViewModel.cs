using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Base;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.ViewModels.Base;
using MathCore.WPF.Commands;
using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class ProductManagementViewModel : EntityManagementViewModel
    {
        private readonly ProductService _service;
        private readonly DiscService _discService;

        private ShowProductStrategy _ProductStrategy;
        public ShowProductStrategy ProductStrategy => _ProductStrategy ??= new ShowProductStrategy();

        private ShowProductCostStrategy _ProductCostStrategy;
        public ShowProductCostStrategy ProductCostStrategy => _ProductCostStrategy ??= new ShowProductCostStrategy();

        private ShowProductQuantityStrategy _ProductQuantityStrategy;
        public ShowProductQuantityStrategy ProductQuantityStrategy => _ProductQuantityStrategy ??= new ShowProductQuantityStrategy();

        protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        {
            if (!(E.Item is ProductResDto dto))
            {
                E.Accepted = false;
                return;
            }

            var filterText = SearchedFilter;
            if (string.IsNullOrWhiteSpace(filterText)) return;
            if (dto.DiscTitle.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

            E.Accepted = false;
        }

        public override IEnumerable<ProductResDto> Items => _service.GetAll();

        public ProductManagementViewModel(ProductService productService, WindowDataFormationService dialogService, DiscService discService) : base(dialogService)
        {
            _service = productService;
            _discService = discService;
            _FilteredItems.Source = Items;
        }

        #region CreateNewProductCommand - создание продукта

        private ICommand _CreateNewProductCommand;

        public ICommand CreateNewProductCommand => _CreateNewProductCommand ??= new LambdaCommand(OnCreateNewProductCommand, IsLoginUser);

        private void OnCreateNewProductCommand(object? p)
        {
            object item = new ProductResDto();
            var strategy = ProductStrategy;
            strategy.Discs = _discService.GetDiscs();

            _dialogService.ShowStrategy = strategy;

            if (!_dialogService.ShowContent(ref item)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as ProductResDto);
                _service.Create(reqDto);
                _dialogService.ShowInformation("Запись создана", "Успех");
                OnPropertyChanged(nameof(Items));
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

        private bool CanChangeAvailableProduct(object? p) => p is ProductResDto && IsLoginUser(p);

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
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка изменения доступности");
            }
        }

        #endregion

        #region ChangeQuantityCommand - изменение количества элемента

        private ICommand _EditQuantityCommand;

        public ICommand EditQuantityCommand => _EditQuantityCommand ??= new LambdaCommand(OnEditQuantityCommand, CanEditQuantityCommand);

        private bool CanEditQuantityCommand(object? p) => p is ProductResDto && IsLoginUser(p);

        private void OnEditQuantityCommand(object? p)
        {
            var product = p as ProductResDto;
            object model = new EditProductQuantityModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentQuantity = product.Quantity,
                EditQuantity = 5
            };
            _dialogService.ShowStrategy = ProductQuantityStrategy;
            if (!_dialogService.ShowContent(ref model)) return;
            try
            {
                var reqDto = model as EditProductQuantityModel;
                _service.EditProductQuantity(new EditProductQuantityReqDto
                {
                    ProductId = reqDto.ProductId,
                    EditQuantity = reqDto.EditQuantity
                });
                _dialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                _dialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

        #endregion

        #region ChangeCostCommand - изменение стоимости элемента

        private ICommand _ChangeCostCommand;

        public ICommand ChangeCostCommand => _ChangeCostCommand ??= new LambdaCommand(OnChangeCostCommand, CanChangeCostCommand);

        private bool CanChangeCostCommand(object? p) => p is ProductResDto && IsLoginUser(p);

        private void OnChangeCostCommand(object? p)
        {
            _dialogService.ShowStrategy = ProductCostStrategy;
            var product = p as ProductResDto;
            object model = new EditProductCostModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentCost = product.Cost,
            };
            if (!_dialogService.ShowContent(ref model)) return;
            try
            {
                var reqDto = model as EditProductCostModel;
                _service.ChangeProductCost(new ChangeProductCostReqDto
                {
                    ProductId = reqDto.ProductId,
                    Cost = reqDto.NewCost
                });
                _dialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Items));
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
