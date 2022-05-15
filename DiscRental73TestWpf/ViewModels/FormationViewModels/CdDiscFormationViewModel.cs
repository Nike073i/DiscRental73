using BusinessLogic.DtoModels.ResponseDto;
using MathCore.WPF.Commands;
using MathCore.WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace DiscRental73TestWpf.ViewModels.FormationViewModels
{
    public class CdDiscFormationViewModel : ViewModel, INotifyDataErrorInfo
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

        #region Валидация ввода

        private ConcurrentDictionary<string, List<string>> _errors = new ConcurrentDictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            if (handler != null)
                handler(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            List<string> errorsForName;
            _errors.TryGetValue(propertyName, out errorsForName);
            return errorsForName;
        }

        public bool HasErrors
        {
            get { return _errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }

        #endregion
    }
}
