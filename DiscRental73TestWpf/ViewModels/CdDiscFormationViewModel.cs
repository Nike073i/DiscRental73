using BusinessLogic.DtoModels.ResponseDto;
using MathCore.WPF.ViewModels;

namespace DiscRental73TestWpf.ViewModels
{
    public class CdDiscFormationViewModel : ViewModel
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
