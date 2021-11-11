using System;
using ERNITech.Services.Network;
using ERNITech.Services.Predefined;
using ERNITech.Services.Rest;
using ERNITech.ViewModels;
using ERNITech.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ERNITech
{
    public partial class App
    {
        #region device scale
        public static float ScreenHeight { get; set; }
        public static float ScreenWidth { get; set; }
        public static float DeviceScale { get; set; }
        public static double StatusBarHeight { get; set; }
        public static double NativeScale { get; set; }
        public static double AppScale { get; set; }
        public static double ScreenScale { get { return (ScreenHeight + ScreenHeight) / (320.0f + 568.0f); } }
        #endregion

        private NetworkHelper NetworkHelper;
        private RestService RestServices;

        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();
            // Instantiate possible services (Session, Permissions, Socket, Analytics, Subscription Keys, etc)

            // Page Redirections
            NavigationService.NavigateAsync(Constants.UsersPage);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>(Constants.NAVIGATION_PAGE);
            containerRegistry.RegisterForNavigation<UsersPage, UsersPageViewModel>(Constants.UsersPage);
            containerRegistry.RegisterForNavigation<UserDetailPage, UserDetailPageViewModel>(Constants.UserDetailPage);

            containerRegistry.RegisterInstance<INetworkHelper>(NetworkHelper);
            containerRegistry.RegisterInstance<IRestService>(RestServices);
        }
    }
}
