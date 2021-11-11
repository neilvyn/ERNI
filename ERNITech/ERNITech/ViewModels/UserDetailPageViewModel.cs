using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ERNITech.Models;
using ERNITech.Services.Predefined;
using ERNITech.Services.Rest;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace ERNITech.ViewModels
{
    public class UserDetailPageViewModel : ViewModelBase
    {
        // key: rpro, datatype: UserDetailPageModel, property: ClassProperty
        private UserDetailPageModel _ClassProperty = new UserDetailPageModel();
        public UserDetailPageModel ClassProperty { get { return _ClassProperty; } set { _ClassProperty = value; this.RaisePropertyChanged(nameof(ClassProperty)); } }

        #region events and delegates
        public DelegateCommand BackCommand { get; set; }
        #endregion

        #region variables
        private INavigationService navigationService;
        #endregion

        public UserDetailPageViewModel(INavigationService _navigationService) : base(_navigationService)
        {
            navigationService = _navigationService;
            BackCommand = new DelegateCommand(BackControl);
        }

        private void BackControl()
        {
            navigationService.GoBackAsync(animated: true);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("UserItem"))
                ClassProperty.User = parameters.GetValue<UserModel>("UserItem");
            else
                BackControl();
        }
    }
}
