﻿using System;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Proxy
{
    /// <summary>Предоставляет прокси <see cref="DependencyObject"/> с одним свойством и 
    /// событем уведомляющем о его изменении.</summary>
    /// <typeparam name="T">Тип свойства <see cref="Value"/>.</typeparam>
    public class ProxyValue<T> : Freezable
    {
        /// <summary>Свойство для задания внешних привязок.</summary>
        public T Value
        {
            get => (T)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(nameof(Value), typeof(T), typeof(ProxyValue<T>), new PropertyMetadata(null));

        /// <summary>Привязка по умолсанию - пустой экземпляр <see cref="Binding()"/>.
        /// </summary>
        public static readonly Binding DefaultBinding = new();

        public ProxyValue()
            => SetValueBinding(DefaultBinding);

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            ValueChanged?.Invoke(this, e);
        }

        /// <summary>Событие, возникающее при изменении значения любого <see cref="DependencyProperty"/>.</summary>
        public event EventHandler<DependencyPropertyChangedEventArgs> ValueChanged;

        /// <summary>Возвращает <see langword="true"/>, если значение свойства <see cref="Value"/> не задано.</summary>
        public bool IsUnsetValue => Equals(ReadLocalValue(ValueProperty), DependencyProperty.UnsetValue);

        /// <summary>Очистка всех <see cref="DependencyProperty"/> этого <see cref="ProxyDO"/>.</summary>
        public void Reset()
        {
            LocalValueEnumerator locallySetProperties = GetLocalValueEnumerator();
            while (locallySetProperties.MoveNext())
            {
                DependencyProperty propertyToClear = locallySetProperties.Current.Property;
                if (!propertyToClear.ReadOnly)
                {
                    ClearValue(propertyToClear);
                }
            }

        }

        /// <summary><see langword="true"/> если свойству задана Привязка.</summary>
        public bool IsValueBinding => BindingOperations.GetBindingExpressionBase(this, ValueProperty) != null;

        /// <summary><see langword="true"/> если свойству задана привязка
        /// и она в состоянии <see cref="BindingStatus.Active"/>.</summary>
        public bool IsActiveValueBinding
        {
            get
            {
                BindingExpressionBase exp = BindingOperations.GetBindingExpressionBase(this, ValueProperty);
                if (exp == null)
                {
                    return false;
                }

                BindingStatus status = exp.Status;
                return status == BindingStatus.Active;
            }
        }

        public void SetValueBinding(BindingBase binding)
        {
            if (binding != null)
                BindingOperations.SetBinding(this, ValueProperty, binding);
            else
                BindingOperations.ClearBinding(this, ValueProperty);
        }

        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>Предоставляет прокси <see cref="DependencyObject"/> с одним свойством и 
    /// событем уведомляющем о его изменении.</summary>
    public class ProxyValue : ProxyValue<object>
    {

    }

    /// <summary>Возвращает экземпляр <see cref="ProxyValue{T}"/> для указанного типа
    /// и задаёт в нём указанныую привязку.</summary>
    [MarkupExtensionReturnType(typeof(ProxyValue<>))]
    public class ProxyValueExtension : MarkupExtension
    {
        public Type Type { get; set; }

        public BindingBase ValueBinding { get; set; }

        public ProxyValueExtension(Type type)
        {
            Type = type;
        }

        public ProxyValueExtension()
        {
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            DependencyObject proxy;
            DependencyProperty property;
            Type typeT = Type;
            if (typeT == null)
            {
                typeT = typeof(object);
            }

            Type type = typeof(ProxyValue<>).MakeGenericType(typeT);
            proxy = (DependencyObject)Activator.CreateInstance(type);
            property = (DependencyProperty)proxy.GetType().GetField("ValueProperty", BindingFlags.Public | BindingFlags.Static).GetValue(null);

            if (ValueBinding != null)
            {
                _ = BindingOperations.SetBinding(proxy, property, ValueBinding);
            }

            return proxy;
        }
    }

}