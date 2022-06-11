using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.Base;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels
{
    public class ProductManagementViewModel : EntityManagementViewModel
    {
        private readonly IProductService _service;
        private readonly IDiscService _discService;

        private ShowProductStrategy _ProductStrategy;
        public ShowProductStrategy ProductStrategy => _ProductStrategy ??= new ShowProductStrategy();

        private ShowProductCostStrategy _ProductCostStrategy;
        public ShowProductCostStrategy ProductCostStrategy => _ProductCostStrategy ??= new ShowProductCostStrategy();

        private ShowProductQuantityStrategy _ProductQuantityStrategy;
        public ShowProductQuantityStrategy ProductQuantityStrategy => _ProductQuantityStrategy ??= new ShowProductQuantityStrategy();

        //protected override void OnItemsFiltered(object sender, FilterEventArgs E)
        //{
        //    if (!(E.Item is ProductResDto dto))
        //    {
        //        E.Accepted = false;
        //        return;
        //    }

        //    var filterText = SearchedFilter;
        //    if (string.IsNullOrWhiteSpace(filterText)) return;
        //    if (dto.DiscTitle.Contains(filterText, StringComparison.OrdinalIgnoreCase)) return;

        //    E.Accepted = false;
        //}

        protected override void OnRefreshCommand(object? p)
        {
            Items = _service.GetAll();
        }

        public ProductManagementViewModel(IProductService productService, IFormationService dialogService, IDiscService discService) : base(dialogService)
        {
            _service = productService;
            _discService = discService;
            Items = _service.GetAll();
            //_FilteredItems.Source = Items;
        }

        #region CreateNewProductCommand - создание продукта

        private ICommand _CreateNewProductCommand;

        public ICommand CreateNewProductCommand => _CreateNewProductCommand ??= new LambdaCommand(OnCreateNewProductCommand, IsLoginUser);

        private void OnCreateNewProductCommand(object? p)
        {
            object item = new ProductResDto();
            var strategy = ProductStrategy;
            strategy.Discs = _discService.GetDiscs();

            if (!DialogService.ShowContent(ref item, strategy)) return;
            try
            {
                var reqDto = CreateReqDtoToCreate(item as ProductResDto);
                _service.Create(reqDto);
                DialogService.ShowInformation("Запись создана", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                DialogService.ShowWarning(ex.Message, "Ошибка создания");
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
                DialogService.ShowInformation("Доступность изменена", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                DialogService.ShowWarning(ex.Message, "Ошибка изменения доступности");
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
            if (!DialogService.ShowContent(ref model, ProductQuantityStrategy)) return;
            try
            {
                var reqDto = model as EditProductQuantityModel;
                _service.EditProductQuantity(new EditProductQuantityReqDto
                {
                    ProductId = reqDto.ProductId,
                    EditQuantity = reqDto.EditQuantity
                });
                DialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                DialogService.ShowWarning(ex.Message, "Ошибка изменения");
            }
        }

        #endregion

        #region ChangeCostCommand - изменение стоимости элемента

        private ICommand _ChangeCostCommand;

        public ICommand ChangeCostCommand => _ChangeCostCommand ??= new LambdaCommand(OnChangeCostCommand, CanChangeCostCommand);

        private bool CanChangeCostCommand(object? p) => p is ProductResDto && IsLoginUser(p);

        private void OnChangeCostCommand(object? p)
        {
            var product = p as ProductResDto;
            object model = new EditProductCostModel
            {
                ProductId = product.Id,
                DiscTitle = product.DiscTitle,
                CurrentCost = product.Cost,
            };
            if (!DialogService.ShowContent(ref model, ProductCostStrategy)) return;
            try
            {
                var reqDto = model as EditProductCostModel;
                _service.ChangeProductCost(new ChangeProductCostReqDto
                {
                    ProductId = reqDto.ProductId,
                    Cost = reqDto.NewCost
                });
                DialogService.ShowInformation("Количество измененно", "Успех");
                OnPropertyChanged(nameof(Items));
            }
            catch (Exception ex)
            {
                DialogService.ShowWarning(ex.Message, "Ошибка изменения");
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
