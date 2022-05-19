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

        #region Ограничения на ввод данных 

        public int ContactNumberLength { get; set; }
        public int FirstNameMaxLength { get; set; }
        public int FirstNameMinLength { get; set; }
        public int SecondNameMaxLength { get; set; }
        public int SecondNameMinLength { get; set; }
        public int AddressMaxLength { get; set; }
        public int AddressMinLength { get; set; }

        #endregion
    }
}
