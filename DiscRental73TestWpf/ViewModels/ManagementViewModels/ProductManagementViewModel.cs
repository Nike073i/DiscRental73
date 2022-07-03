using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Interfaces.Services;
using DesignDebugStorage.Repositories;
using DiscRental73TestWpf.Infrastructure.DialogWindowServices.Strategies;
using DiscRental73TestWpf.Infrastructure.HelperModels;
using DiscRental73TestWpf.Infrastructure.Interfaces;
using DiscRental73TestWpf.ViewModels.Base;
using DiscRental73TestWpf.ViewModels.FormationViewModels;
using DiscRental73TestWpf.ViewModels.WindowViewModels;
using MathCore.WPF.Commands;
using System;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.ManagementViewModels;

public class ProductManagementViewModel : EntityManagementViewModel
{
    #region readonly fields

    private readonly IProductService _Service;
    private readonly IDiscService _DiscService;
    private readonly ShowProductStrategy _ProductStrategy;
    private readonly ShowProductCostStrategy _ProductCostStrategy;
    private readonly ShowProductQuantityStrategy _ProductQuantityStrategy;

    #endregion

    #region constructors

    /// <summary>Отладочный конструктор для VS</summary>
    public ProductManagementViewModel() : base(null!)
    {
        if (!App.IsDesignMode)
            throw new NotSupportedException("Данный конструктор предназначен для визуального конструктора VS");
        _Service = null!;
        _DiscService = null!;
        _ProductQuantityStrategy = null!;
        _ProductStrategy = null!;
        _ProductCostStrategy = null!;
        Items = new ClientDebugRepository().GetAll();
    }

    public ProductManagementViewModel(IProductService service,
        IDiscService discService,
        IFormationService dialogService,
        EntityFormationWindowViewModel formationWindowVm,
        ProductFormationViewModel formationVm,
        EditProductCostFormationViewModel costFormationVm,
        EditProductQuantityFormationViewModel quantityFormationVm) : base(dialogService)
    {
        _Service = service;
        _DiscService = discService;
        _ProductCostStrategy = new ShowProductCostStrategy(formationWindowVm, costFormationVm);
        _ProductQuantityStrategy = new ShowProductQuantityStrategy(formationWindowVm, quantityFormationVm);
        _ProductStrategy = new ShowProductStrategy(formationWindowVm, formationVm);
        Items = _Service.GetAll();
        //_FilteredItems.Source = Items;
    }

    #endregion

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
        Items = _Service.GetAll();
    }

    #region CreateNewProductCommand - создание продукта

    private ICommand _CreateNewProductCommand;

    public ICommand CreateNewProductCommand => _CreateNewProductCommand ??= new LambdaCommand(OnCreateNewProductCommand, IsLoginUser);

    private void OnCreateNewProductCommand(object? p)
    {
        object item = new ProductResDto();
        var strategy = _ProductStrategy;
        strategy.Discs = _DiscService.GetDiscs();

        if (!DialogService.ShowContent(ref item, strategy)) return;
        try
        {
            var reqDto = CreateReqDtoToCreate(item as ProductResDto);
            _Service.Create(reqDto);
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
            _Service.ChangeAvailable(resDto.Id, !resDto.IsAvailable);
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
        if (!DialogService.ShowContent(ref model, _ProductQuantityStrategy)) return;
        try
        {
            var reqDto = model as EditProductQuantityModel;
            _Service.EditProductQuantity(reqDto.ProductId, reqDto.EditQuantity);
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
        if (!DialogService.ShowContent(ref model, _ProductCostStrategy)) return;
        try
        {
            var reqDto = model as EditProductCostModel;
            _Service.ChangeProductCost(reqDto.ProductId, reqDto.NewCost);
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