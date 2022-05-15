using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CdDiscFormationViewModel : FormationViewModel
    {
        #region FormationData - CdDiscResDto - модель сд-диска

        private CdDiscResDto _CdDisc;

        /// <summary>Модель сд-диска</summary>
        public CdDiscResDto CdDisc
        {
            get => _CdDisc;
            set => Set(ref _CdDisc, value);
        }

        #endregion
    }
}
