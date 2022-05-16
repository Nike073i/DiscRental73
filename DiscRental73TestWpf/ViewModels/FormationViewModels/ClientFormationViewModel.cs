using BusinessLogic.DtoModels.ResponseDto;
using DiscRental73TestWpf.ViewModels.Base;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class ClientFormationViewModel : FormationViewModel
    {
        #region FormationData - ClientResDto - модель клиента

        private ClientResDto _Client;

        /// <summary>Модель сд-диска</summary>
        public ClientResDto Client
        {
            get => _Client;
            set => Set(ref _Client, value);
        }

        #endregion
    }
}
