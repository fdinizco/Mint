using Xamarin.Forms;

namespace SlotGroups.Controls
{
    public partial class NavigationBar : ContentView
    {
        public static readonly BindableProperty NavigationBarTitleProperty = BindableProperty.Create(nameof(NavigationBarTitle), typeof(string), typeof(NavigationBar), string.Empty);
        public static readonly BindableProperty LeftIconProperty = BindableProperty.Create(nameof(LeftIcon), typeof(string), typeof(NavigationBar), string.Empty);

        public string NavigationBarTitle
        {
            get => (string)GetValue(NavigationBarTitleProperty);
            set => SetValue(NavigationBarTitleProperty, value);
        }

        public string LeftIcon
        {
            get => (string)GetValue(LeftIconProperty);
            set => SetValue(LeftIconProperty, value);
        }
    }
}
