using DiscRental73TestWpf.ViewModels.ControlsItems;
using DiscRental73TestWpf.Views.CustomControls;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Controls;

namespace DiscRental73TestWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для IssueView.xaml
    /// </summary>
    public partial class IssueView : UserControl
    {
        public IssueView()
        {
            InitializeComponent();
            MenuRegistration();
        }

        private void MenuRegistration()
        {
            var menuSellsSubItems = new List<SubItem>();
            menuSellsSubItems.Add(new SubItem("Оформить продажу"));
            menuSellsSubItems.Add(new SubItem("Оформить возврат"));
            var menuSellItem = new ItemMenu("Продажа", menuSellsSubItems, PackIconKind.Store);

            var menuRentalSubItems = new List<SubItem>();
            menuRentalSubItems.Add(new SubItem("Оформить прокат"));
            menuRentalSubItems.Add(new SubItem("Оформить возврат"));
            menuRentalSubItems.Add(new SubItem("Отмена проката"));
            var menuRentalItem = new ItemMenu("Прокат", menuRentalSubItems, PackIconKind.Timelapse);

            var menuSystemSubItems = new List<SubItem>();
            menuSystemSubItems.Add(new SubItem("Выход"));
            var menuSystemItem = new ItemMenu("Система", menuSystemSubItems, PackIconKind.CellphoneSystemUpdate);

            Menu.Children.Add(new CustomMenuItem(menuSellItem));
            Menu.Children.Add(new CustomMenuItem(menuRentalItem));
            Menu.Children.Add(new CustomMenuItem(menuSystemItem));
        }
    }
}
