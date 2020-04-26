using System;
using Xamarin.Forms;

namespace CoronaNews.CustomControls
{
    public class CustomButton: Button
    {
        public CustomButton()
        {
        }

        /// <summary>
        /// Manages the binding of the <see cref="DisabledTextColor"/> property
        /// </summary>
        public static readonly BindableProperty DisabledTextColorProperty = BindableProperty.Create(
            propertyName: nameof(DisabledTextColor),
            returnType: typeof(Color),
            declaringType: typeof(CustomButton),
            defaultValue: default(Color),
            defaultBindingMode: BindingMode.OneWay
        );

        public Color DisabledTextColor
        {
            get => (Color)GetValue(DisabledTextColorProperty);
            set => SetValue(DisabledTextColorProperty, value);
        }

    }
}