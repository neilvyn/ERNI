using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace ERNITech.Models
{
    public class UserDetailPageModel : BindableBase
    {
        // key: rpro, datatype: UserModel, property: User
        private UserModel _User;
        public UserModel User { get { return _User; } set { _User = value; this.RaisePropertyChanged(nameof(User)); } }
    }
}
