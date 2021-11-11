using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERNITech.Models;
using ERNITech.Services.Network;
using ERNITech.Services.Predefined;
using ERNITech.Services.Rest;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ERNITech.ViewModels
{
    public class UsersPageViewModel : ViewModelBase, IResponseConnector
    {
        // key: rpro, datatype: UsersPageModel, property: ClassProperty
        private UsersPageModel _ClassProperty = new UsersPageModel();
        public UsersPageModel ClassProperty { get { return _ClassProperty; } set { _ClassProperty = value; this.RaisePropertyChanged(nameof(ClassProperty)); } }

        #region events and delegates
        public DelegateCommand ShowUsersCommand { get; set; }
        public DelegateCommand<object> ItemTappedCommand { get; set; }
        #endregion

        #region variables
        private INavigationService navigationService;
        private readonly RestService restService;
        private readonly NetworkHelper networkHelper;
        CancellationTokenSource cts;
        #endregion

        public UsersPageViewModel(INavigationService _navigationService, RestService _restService, NetworkHelper _networkHelper) : base(_navigationService)
        {
            navigationService = _navigationService;
            networkHelper = _networkHelper;
            restService = _restService;
            restService.RestResponseDelegate = this;

            ShowUsersCommand = new DelegateCommand(ShowUsersControl);
            ItemTappedCommand = new DelegateCommand<object>(ItemTappedAction);
        }

        async private void ShowUsersControl()
        {
            // if validated
            await GetUsers();
        }

        private void ItemTappedAction(object obj)
        {
            var usr = obj as UserModel;
            LogConsole.AsyncOutput(this, usr.Name);

            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("UserItem", usr);

            navigationService.NavigateAsync(Constants.UserDetailPage, parameters: navParams, animated: true);
        }

        private async Task GetUsers()
        {
            ClassProperty.Original = null;
            ClassProperty.HasData = false;

            if (!networkHelper.HasInternet())
                Acr.UserDialogs.UserDialogs.Instance.Alert(Constants.NO_CONNECTION.Description, Constants.NO_CONNECTION.Title, Constants.AlertPositiveLabel);
            else {
                try
                {
                    cts = new CancellationTokenSource();
                    Acr.UserDialogs.UserDialogs.Instance.ShowLoading();

                    string url = Constants.URL_USERS;
                    await restService.Request(EnumHttpMethod.Get, url, ctoken: cts.Token, ws_query: "show_users");
                    cts = null;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                    Acr.UserDialogs.UserDialogs.Instance.HideLoading();
                    Acr.UserDialogs.UserDialogs.Instance.Alert(Constants.HOST_UNREACHABLE.Description, Constants.HOST_UNREACHABLE.Title, Constants.AlertPositiveLabel);
                }
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            LogConsole.AsyncOutput(this, "show users");
        }

        public void ReceiveError(string title, string error, string ws_query) => Acr.UserDialogs.UserDialogs.Instance.Alert(error, title, Constants.AlertPositiveLabel);

        public void ReceiveJSONData(string jsonString, string ws_query)
        {
            Device.BeginInvokeOnMainThread(() => Acr.UserDialogs.UserDialogs.Instance.HideLoading());
            var jsonData = Controls.Utilities.StringUtil.ToJObject(jsonString);

            if (jsonData != null)
            {
                switch (ws_query)
                {
                    case "show_users":
                        if (jsonData.ContainsKey("obj"))
                        {
                            ClassProperty.Original = JsonConvert.DeserializeObject<ObservableCollection<UserModel>>(jsonData["obj"].ToString());

                            //ClassProperty.Filtered = new ObservableCollection<UserModel>(ClassProperty.Original.Distinct());
                            ClassProperty.Filtered = new ObservableCollection<UserModel>();
                            foreach (var item in ClassProperty.Original)
                            {
                                bool hasDupe = false;
                                ClassProperty.Filtered.All(orig => {
                                    if (item.Id == orig.Id && item.Name == orig.Name && item.Image == orig.Image)
                                        hasDupe = true;
                                    return true;
                                });

                                if(!hasDupe)
                                    ClassProperty.Filtered.Add(item);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            ClassProperty.HasData = ClassProperty.Original.Count > 0;
        }
    }
}
