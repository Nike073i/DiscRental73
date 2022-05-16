using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.ViewModels.Base;
using System;
using System.Collections;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class EmployeeFormationViewModel : FormationViewModel
    {
        #region FormationData - EmployeeResDto - модель сотрудника

        private EmployeeResDto _Employee;

        /// <summary>Модель сд-диска</summary>
        public EmployeeResDto Employee
        {
            get => _Employee;
            set => Set(ref _Employee, value);
        }

        #endregion

        #region Positions - IEnumerable UserPosition

        private IEnumerable _Positions = Enum.GetValues(typeof(UserPosition));

        public IEnumerable Positions
        {
            get => _Positions;
            set => Set(ref _Positions, value);
        }

        #endregion
    }
}