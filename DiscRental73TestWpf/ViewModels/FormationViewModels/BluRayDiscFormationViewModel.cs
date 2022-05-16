using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class BluRayDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - BluRayDiscResDto - модель BluRay-диска

        private BluRayDiscResDto _BluRayDisc;

        /// <summary>Модель BluRay-диска</summary>
        public BluRayDiscResDto BluRayDisc
        {
            get => _BluRayDisc;
            set => Set(ref _BluRayDisc, value);
        }

        #endregion
    }
}
