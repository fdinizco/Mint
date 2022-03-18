using SlotGroups.Common;
using SlotGroups.Interfaces;
using SlotGroups.ViewModels;
using SlotGroups.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SlotGroups.Services.Local;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SlotGroups
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync(NavigateTo.Root);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterForNavigation(containerRegistry);
            RegisterServices(containerRegistry);
        }

        private void RegisterForNavigation(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<SlotGroupsPage, SlotGroupsPageViewModel>(NavigateTo.Detail);
        }

        private void RegisterServices(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAlert, Alert>();
        }

    }
}
