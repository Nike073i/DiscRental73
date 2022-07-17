using System.Collections.Generic;

namespace DiscRental73.Wpf.ViewModels
{
    public class FormationService
    {
        #region fields

        private readonly Dictionary<string, object> _Values;

        #endregion

        #region constructors

        public FormationService()
        {
            _Values = new Dictionary<string, object>();
        }

        #endregion

        #region public methods

        public T GetData<T>(T defaultVal, string propertyName)
        {
            if (_Values.TryGetValue(propertyName, out var data)) return (T)data;
            return defaultVal;
        }

        public bool SetData(object data, string propertyName)
        {
            if (_Values.TryGetValue(propertyName, out var oldVal) && Equals(data, oldVal))
                return false;
            _Values[propertyName] = data;
            return true;
        }

        #endregion
    }
}
