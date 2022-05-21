using BusinessLogic.DtoModels.ResponseDto;
using BusinessLogic.Enums;
using DiscRental73TestWpf.ViewModels.Base;
using System;
using System.Collections;

namespace AdminWpfPlugin.ViewModels
{
    public class EmployeeFormationViewModel : FormationViewModel
    {
        #region FormationData - EmployeeResDto - модель сотрудника

        private EmployeeResDto _Employee;

        /// <summary>Модель сотрудника</summary>
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

        #region Ограничения на ввод данных 

        public int ContactNumberLength { get; set; }
        public int FirstNameMaxLength { get; set; }
        public int FirstNameMinLength { get; set; }
        public int SecondNameMaxLength { get; set; }
        public int SecondNameMinLength { get; set; }
        public int PasswordMaxLength { get; set; }
        public int PasswordMinLength { get; set; }

        #endregion
    }
}
