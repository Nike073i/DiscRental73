using DiscRental73.Domain.DtoModels.Dto;
using DiscRental73.Wpf.ViewModels.Base;

namespace DiscRental73.Wpf.ViewModels.EntityViewModels
{
    public class ClientViewModel : EntityViewModel
    {
        #region constructors

        public ClientViewModel() : this(new ClientDto()) { }

        public ClientViewModel(ClientDto client)
        {
            Id = client.Id;
            _ContactNumber = client.ContactNumber;
            _FirstName = client.FirstName;
            _SecondName = client.SecondName;
            _Address = client.Address;
        }

        #endregion

        #region properties

        #region Dto : ClientDto - сформированный dto по введенной информации

        public override ClientDto Dto =>
            new()
            {
                Id = Id,
                ContactNumber = ContactNumber,
                FirstName = FirstName,
                SecondName = SecondName,
                Address = Address,
            };

        #endregion

        /// <summary>Идентификатор клиента</summary>
        private int Id { get; }

        #region ContactNumber : string - Номер телефона

        /// <summary>Номер телефона</summary>
        private string _ContactNumber;

        /// <summary>Номер телефона</summary>
        public string ContactNumber { get => _ContactNumber; set => Set(ref _ContactNumber!, value); }

        #endregion

        #region FirstName : string - Имя

        /// <summary>Имя</summary>
        private string _FirstName;

        /// <summary>Имя</summary>
        public string FirstName { get => _FirstName; set => Set(ref _FirstName!, value); }

        #endregion

        #region SecondName : string - Фамилия

        /// <summary>Фамилия</summary>
        private string _SecondName;

        /// <summary>Фамилия</summary>
        public string SecondName { get => _SecondName; set => Set(ref _SecondName!, value); }

        #endregion

        #region Address : string - Адрес

        /// <summary>Адрес</summary>
        private string _Address;

        /// <summary>Адрес</summary>
        public string Address { get => _Address; set => Set(ref _Address!, value); }

        #endregion

        #endregion
    }
}