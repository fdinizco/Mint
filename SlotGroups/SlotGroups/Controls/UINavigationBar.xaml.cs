using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SlotGroups.Controls
{
    [DesignTimeVisible(true)]
    public partial class UINavigationBar : ContentView
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(UINavigationBar), string.Empty);
        public static readonly BindableProperty LeftIconProperty = BindableProperty.Create(nameof(LeftIcon), typeof(string), typeof(UINavigationBar), string.Empty);
        public static BindableProperty LeftIconCommandProperty = BindableProperty.Create(nameof(LeftIconCommand), typeof(ICommand), typeof(UINavigationBar));

        public ICommand LeftIconCommand
        {
            get => (ICommand)GetValue(LeftIconCommandProperty);
            set => SetValue(LeftIconCommandProperty, value);
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string LeftIcon
        {
            get => (string)GetValue(LeftIconProperty);
            set => SetValue(LeftIconProperty, value);
        }

        public UINavigationBar()
        {
            InitializeComponent();
        }
    }
}
