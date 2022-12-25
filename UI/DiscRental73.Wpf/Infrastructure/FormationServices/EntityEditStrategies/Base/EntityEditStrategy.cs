using DiscRental73.Wpf.ViewModels.Base;
using DiscRental73.Wpf.ViewModels.WindowViewModels;
using DiscRental73.Wpf.Views.Windows;
using System.Windows;

namespace DiscRental73.Wpf.Infrastructure.FormationServices.EntityEditStrategies.Base
{
    public abstract class EntityEditStrategy : IEntityEditStrategy
    {
        #region fields

        private EntityFormationWindowViewModel? _FormationVm;

        #endregion

        #region public methods

        public abstract bool EditDialog(ref object formationData);

        #endregion

        #region protected methods

        protected Window CreateFormationWindow(string title, string caption, EntityViewModel vm)
        {
            _FormationVm = new EntityFormationWindowViewModel
            {
                Title = title,
                Caption = caption,
                CurrentModel = vm
            };
            return new EntityFormationWindow()
            {
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                DataContext = _FormationVm,
            };
        }

        #endregion
    }
}
