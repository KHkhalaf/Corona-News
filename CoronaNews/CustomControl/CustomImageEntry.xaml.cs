using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoronaNews.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomImageEntry : ContentView
    {
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(
            nameof(FontFamily),
            typeof(string),
            typeof(CustomImageEntry),
            null,
            BindingMode.OneWay
        );

        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
            nameof(FontSize),
            typeof(double),
            typeof(CustomImageEntry),
            -1.0,
            BindingMode.OneWay
        );

        [TypeConverter(typeof(FontSizeConverter))]
        public double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create(
            nameof(FontAttributes),
            typeof(FontAttributes),
            typeof(CustomImageEntry),
            (object)FontAttributes.None,
            BindingMode.OneWay
        );

        public FontAttributes FontAttributes
        {
            get => (FontAttributes)GetValue(FontAttributesProperty);
            set => SetValue(FontAttributesProperty, value);
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(CustomImageEntry),
            null,
            BindingMode.TwoWay
            );

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
            nameof(TextColor),
            typeof(Color),
            typeof(CustomImageEntry),
            Color.Black,
            BindingMode.TwoWay
            );

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            nameof(Placeholder),
            typeof(string),
            typeof(CustomImageEntry),
            null,
            BindingMode.OneWay
            );

        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }

        public static readonly BindableProperty PlaceholderColorProperty = BindableProperty.Create(
            nameof(PlaceholderColor),
            typeof(Color),
            typeof(CustomImageEntry),
            Color.Gray,
            BindingMode.OneWay
            );

        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(
            nameof(MaxLength),
            typeof(int),
            typeof(CustomImageEntry),
            int.MaxValue,
            BindingMode.OneWay
            );

        public int MaxLength
        {
            get => (int)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
            nameof(IsPassword),
            typeof(bool),
            typeof(CustomImageEntry),
            false,
            BindingMode.OneWay
            );

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public static readonly BindableProperty KeyboardProperty = BindableProperty.Create(
            nameof(Keyboard),
            typeof(Keyboard),
            typeof(CustomImageEntry),
            Keyboard.Default,
            BindingMode.OneWay
            );

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public new static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
            nameof(IsEnabled),
            typeof(bool),
            typeof(CustomImageEntry),
            true,
            BindingMode.OneWay,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                var oThis = (CustomImageEntry)bindable;
                oThis.oEntry.Opacity = (bool) newVal ? 1 : 0.5;
            });

        public new bool IsEnabled
        {
            get => (bool)GetValue(IsEnabledProperty);
            set => SetValue(IsEnabledProperty, value);
        }

        public static readonly BindableProperty LayoutPaddingProperty = BindableProperty.Create(
            nameof(LayoutPadding),
            typeof(Thickness),
            typeof(CustomImageEntry),
            new Thickness(0, 8, 0, 0),
            BindingMode.TwoWay
        );

        public Thickness LayoutPadding
        {
            get => (Thickness)GetValue(LayoutPaddingProperty);
            set => SetValue(LayoutPaddingProperty, value);
        }

        public new static readonly BindableProperty HorizontalOptionsProperty = BindableProperty.Create(
            nameof(HorizontalOptions),
            typeof(LayoutOptions),
            typeof(CustomImageEntry),
            new LayoutOptions(LayoutAlignment.Fill, true),
            BindingMode.TwoWay
        );

        public new LayoutOptions HorizontalOptions
        {
            get => (LayoutOptions)GetValue(HorizontalOptionsProperty);
            set => SetValue(HorizontalOptionsProperty, value);
        }

        public new static readonly BindableProperty VerticalOptionsProperty = BindableProperty.Create(
            nameof(VerticalOptions),
            typeof(LayoutOptions),
            typeof(CustomImageEntry),
            new LayoutOptions(LayoutAlignment.Start, false),
            BindingMode.TwoWay
        );

        public new LayoutOptions VerticalOptions
        {
            get => (LayoutOptions)GetValue(VerticalOptionsProperty);
            set => SetValue(VerticalOptionsProperty, value);
        }

        public static readonly BindableProperty LineColorProperty = BindableProperty.Create(
            nameof(LineColor),
            typeof(Color),
            typeof(CustomImageEntry),
            Color.Gray,
            BindingMode.OneWay
            );

        public Color LineColor
        {
            get => (Color)GetValue(LineColorProperty);
            set => SetValue(LineColorProperty, value);
        }

        public static readonly BindableProperty AccentColorProperty = BindableProperty.Create(
            nameof(AccentColor),
            typeof(Color),
            typeof(CustomImageEntry),
            Color.Accent,
            BindingMode.OneWay
            );

        public Color AccentColor
        {
            get => (Color)GetValue(AccentColorProperty);
            set => SetValue(AccentColorProperty, value);
        }

        public static readonly BindableProperty LeftImageProperty = BindableProperty.Create(
            nameof(LeftImage),
            typeof(ImageSource),
            typeof(CustomImageEntry),
            null,
            BindingMode.TwoWay,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                var oThis = (CustomImageEntry)bindable;
                oThis.imgLeft.Source = (ImageSource)newVal;
                oThis.imgLeft.IsVisible = oThis.imgLeft.Source != null;
            });

        public ImageSource LeftImage
        {
            get => (ImageSource)GetValue(LeftImageProperty);
            set => SetValue(LeftImageProperty, value);
        }

        public event EventHandler LeftImageClicked;
        public void LeftImage_OnClicked(object sender , EventArgs e)
        {
            LeftImageClicked?.Invoke(sender,e);
        }

        public static readonly BindableProperty RightImageProperty = BindableProperty.Create(
            nameof(RightImage),
            typeof(ImageSource),
            typeof(CustomImageEntry),
            null,
            BindingMode.TwoWay,
            propertyChanged: (bindable, oldVal, newVal) =>
            {
                var oThis = (CustomImageEntry)bindable;
                oThis.imgRight.Source = (ImageSource)newVal;
                oThis.imgRight.IsVisible = oThis.imgRight.Source != null;
            });

        public ImageSource RightImage
        {
            get => (ImageSource)GetValue(RightImageProperty);
            set => SetValue(RightImageProperty, value);
        }

        public event EventHandler RightImageClicked;
        public void RightImage_OnClicked(object sender , EventArgs e)
        {
            RightImageClicked?.Invoke(sender,e);
        }

        public new event EventHandler<FocusEventArgs> Focused;

        private void Entry_Focused(object sender , FocusEventArgs e)
        {
            Focused?.Invoke(sender,e);
        }

        public event EventHandler<TextChangedEventArgs> TextChanged;
        public void Entry_OnTextChanged(object sender , TextChangedEventArgs e)
        {
            TextChanged?.Invoke(sender,e);
        }

        private string _mask = string.Empty;
        private IDictionary<int, char> _positions;

        private void SetPositions()
        {
            if (string.IsNullOrEmpty(Mask))
            {
                _positions = null;
                return;
            }

            var list = new Dictionary<int, char>();
            for (var i = 0; i < Mask.Length; i++)
                if (Mask[i] != 'X')
                    list.Add(i, Mask[i]);

            _positions = list;
        }

        public string Mask
        {
            get => _mask;
            set
            {
                _mask = value;
                SetPositions();
            }
        }

        public CustomImageEntry()
        {
            InitializeComponent();

            BindingContext = this;

            imgRight.ImageClicked += RightImage_OnClicked;
            imgLeft.ImageClicked += LeftImage_OnClicked;
            oEntry.Focused += Entry_Focused;
            oEntry.TextChanged += Entry_OnTextChanged;

            SetPositions(); // initialize masked input

            oEntry.Focused += async (s, a) =>
            {
                if (!IsEnabled) return;

                BottomBorder.BackgroundColor = AccentColor;
                HiddenBottomBorder.BackgroundColor = AccentColor;

                if (string.IsNullOrEmpty(oEntry.Text))
                {
                    await Task.WhenAll(
                        HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200)
                    );
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, BottomBorder.Width, BottomBorder.Height), 200);
                }
            };

            oEntry.Unfocused += async (s, a) =>
            {
                if (!IsEnabled) return;

                BottomBorder.BackgroundColor = LineColor;

                if (string.IsNullOrEmpty(oEntry.Text))
                {
                    await Task.WhenAll(
                        HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200)
                    );
                }
                else
                {
                    await HiddenBottomBorder.LayoutTo(new Rectangle(BottomBorder.X, BottomBorder.Y, 0, BottomBorder.Height), 200);
                }
            };

            oEntry.TextChanged += (sender, args)=>
            {
                var entry = (Entry)sender ;
                var text = entry.Text;

                if (string.IsNullOrWhiteSpace(text) || _positions == null)
                    return;

                if (text.Length > Mask.Length)
                {
                    entry.Text = text.Remove(text.Length - 1);
                    return;
                }

                foreach (var position in _positions)
                    if (text.Length >= position.Key + 1)
                    {
                        var value = position.Value.ToString();
                        if (text.Substring(position.Key, 1) != value)
                            text = text.Insert(position.Key, value);
                    }

                if (entry.Text != text)
                    entry.Text = text;
            };
        }

    }

}