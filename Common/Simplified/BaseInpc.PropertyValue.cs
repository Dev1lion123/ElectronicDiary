using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Simplified
{
    // Реализация получения и здания значения свойству по его имени
    public abstract partial class BaseInpc : INotifyPropertyChanged
    {
        protected void SetValue(string propertyName, object value)
        {
            PropertyValue.SetValue(this, propertyName, value);
        }
        protected object GetValue(string propertyName)
        {
            return PropertyValue.GetValue(this, propertyName);
        }

        protected IEnumerable<string> GetPropertyName()
        {
            return PropertyValue.GetPropertyName(this);
        }
    }
}
