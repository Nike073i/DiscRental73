using DiscRental73TestWpf.ViewModels.ControlsItems;
using System.Windows.Controls;
using System.Windows;

namespace DiscRental73TestWpf.Views.CustomControls
{
    public partial class CustomMenuItem : UserControl
    {
        public CustomMenuItem(ItemMenu itemMenu)
        {
            DataContext = itemMenu;
            InitializeComponent();
            ExpanderMenu.Visibility = itemMenu.SubItems is null ? Visibility.Collapsed : Visibility.Visible;
            //ListViewItemMenu.Visibility = itemMenu.SubItems is null ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
