using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class DvdDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - DvdDiscResDto - модель Dvd-диска

        private DvdDiscResDto _DvdDisc;

        /// <summary>Модель Dvd-диска</summary>
        public DvdDiscResDto DvdDisc
        {
            get => _DvdDisc;
            set => Set(ref _DvdDisc, value);
        }

        #endregion
    }
}
