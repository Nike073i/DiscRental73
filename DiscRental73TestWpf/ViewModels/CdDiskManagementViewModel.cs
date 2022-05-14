using BusinessLogic.BusinessLogics;
using BusinessLogic.DtoModels.RequestDto;
using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using BusinessLogic.Mappers;
using DiscRental73TestWpf.Infrastructure.Commands;
using DiscRental73TestWpf.Views.Windows;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels
{
    public class CdDiskManagementViewModel : ViewModel
    {
        private readonly CdDiscService _service;
        private readonly ICommand _DeleteCommand;
        private readonly ICommand _SaveCommand;

        public CdDiskManagementViewModel(CdDiscService service, CdDiscMapper mapper)
        {
            _service = service;
            _DeleteCommand = new DeleteDataCommand<CdDiscReqDto, CdDiscResDto>(_service, mapper);
            _SaveCommand = new SaveDataCommand<CdDiscReqDto, CdDiscResDto>(_service, mapper);
            #region testDataCreate
            //var item1 = new CdDiscResDto
            //{
            //    Id = 1,
            //    Title = "1t",
            //    Performer = "1p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "1g",
            //    NumberOfTracks = 1
            //};
            //var item2 = new CdDiscResDto
            //{
            //    Id = 2,
            //    Title = "2t",
            //    Performer = "2p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "2g",
            //    NumberOfTracks = 2
            //};
            //var item3 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item4 = new CdDiscResDto
            //{
            //    Id = 1,
            //    Title = "1t",
            //    Performer = "1p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "1g",
            //    NumberOfTracks = 1
            //};
            //var item5 = new CdDiscResDto
            //{
            //    Id = 2,
            //    Title = "2t",
            //    Performer = "2p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "2g",
            //    NumberOfTracks = 2
            //};
            //var item6 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item7 = new CdDiscResDto
            //{
            //    Id = 1,
            //    Title = "1t",
            //    Performer = "1p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "1g",
            //    NumberOfTracks = 1
            //};
            //var item8 = new CdDiscResDto
            //{
            //    Id = 2,
            //    Title = "2t",
            //    Performer = "2p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "2g",
            //    NumberOfTracks = 2
            //};
            //var item9 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item10 = new CdDiscResDto
            //{
            //    Id = 1,
            //    Title = "1t",
            //    Performer = "1p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "1g",
            //    NumberOfTracks = 1
            //};
            //var item11 = new CdDiscResDto
            //{
            //    Id = 2,
            //    Title = "2t",
            //    Performer = "2p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "2g",
            //    NumberOfTracks = 2
            //};
            //var item12 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item13 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item14 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item15 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item16 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item17 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //var item18 = new CdDiscResDto
            //{
            //    Id = 3,
            //    Title = "3t",
            //    Performer = "3p",
            //    DateOfRelease = DateTime.Now,
            //    DiscType = DiscType.CD,
            //    Genre = "3g",
            //    NumberOfTracks = 3
            //};
            //_discs = new List<CdDiscResDto>() { item1,item2, item3, item4, item5, item6, item7, item8, item9, item10, item11, item12, item14, item15, item16, item17, item18 }; 
            #endregion
        }

        private CdDiscResDto _SelectedDisc;

        public IEnumerable<CdDiscResDto> Discs => _service.GetAll();
        //private List<CdDiscResDto> _discs;
        //public IEnumerable<CdDiscResDto> Discs { get => _discs; }

        public CdDiscResDto SelectedDisc { get => _SelectedDisc; set => Set(ref _SelectedDisc, value); }

        public ICommand SaveDataCommand => _SaveCommand;
        public ICommand DeleteCommand => _DeleteCommand;

        #region EditItemCommand - редактирование элемента
        private ICommand _EditItemCommand;
        public ICommand EditItemCommand => _EditItemCommand ??= new LambdaCommand(OnEditItemCommand, CanEditItemCommand);

        private bool CanEditItemCommand(object? p)
        {
            return p is CdDiscResDto;
        }

        private void OnEditItemCommand(object? p)
        {
            var item = p as CdDiscResDto;
            var dlg = new CdDiscFormationWindow
            {
                Title = item.Title,
                DateOfRelease = item.DateOfRelease,
                Performer = item.Performer,
                Genre = item.Genre,
                NumberOfTracks = item.NumberOfTracks ?? 0
            };

            if (dlg.ShowDialog() == true)
            {
                MessageBox.Show("Запись отредактирована!");
            }
            else
            {
                MessageBox.Show("Редактирование отменено!");
            }
        }
        #endregion

        #region CreateNewItemCommand - создание элемента
        private ICommand _CreateNewItemCommand;
        public ICommand CreateNewItemCommand => _CreateNewItemCommand ??= new LambdaCommand(OnCreateNewItemCommand);

        private void OnCreateNewItemCommand(object? p)
        {
            var item1 = new CdDiscReqDto
            {
                Title = "1t",
                Performer = "1p",
                DateOfRelease = DateTime.Now,
                DiscType = DiscType.CD,
                Genre = "1g",
                NumberOfTracks = 1
            };
            try
            {
                _service.Save(item1);
                MessageBox.Show("Dobavlen!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("NEDobavlen! : " + ex.Message);
            }
        }
        #endregion
    }
}
