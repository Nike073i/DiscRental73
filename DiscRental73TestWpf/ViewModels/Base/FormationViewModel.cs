using MathCore.WPF.ViewModels;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DiscRental73TestWpf.ViewModels.Base
{
    public abstract class FormationViewModel : ViewModel, INotifyDataErrorInfo
    {
        #region Валидация ввода

        private readonly ConcurrentDictionary<string, List<string>> _Errors = new();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public void OnErrorsChanged(string propertyName)
        {
            var handler = ErrorsChanged;
            handler?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            _Errors.TryGetValue(propertyName, out var errorsForName);
            return errorsForName;
        }

        public bool HasErrors
        {
            get { return _Errors.Any(kv => kv.Value != null && kv.Value.Count > 0); }
        }

        #endregion

        #region Словарь данных модели

        private readonly Dictionary<string, object> _DataDictionary;

        protected T GetData<T>(T defaultVal, [CallerMemberName] string propertyName = null!)
        {
            if (_DataDictionary.TryGetValue(propertyName, out var data)) return (T)data;
            return defaultVal;
        }

        protected bool SetData(object data, [CallerMemberName] string propertyName = null!)
        {
            if (_DataDictionary.TryGetValue(propertyName, out var oldVal) && Equals(data, oldVal))
                return false;
            _DataDictionary[propertyName] = data;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region constructors

        protected FormationViewModel()
        {
            _DataDictionary = new Dictionary<string, object>();
        }

        #endregion
    }
}
