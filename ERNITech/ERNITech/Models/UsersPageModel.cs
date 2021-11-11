using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace ERNITech.Models
{
    public class UsersPageModel : BindableBase
    {
        // key: rpro, datatype: bool, property: HasData
        private bool _HasData = false;
        public bool HasData { get { return _HasData; } set { _HasData = value; this.RaisePropertyChanged(nameof(HasData)); } }

        // key: rpro, datatype: ObservableCollection<UserModel>, property: Original
        private ObservableCollection<UserModel> _Original;
        public ObservableCollection<UserModel> Original { get { return _Original; } set { _Original = value; this.RaisePropertyChanged(nameof(Original)); } }

        // key: rpro, datatype: ObservableCollection<UserModel>, property: Filtered
        private ObservableCollection<UserModel> _Filtered;
        public ObservableCollection<UserModel> Filtered { get { return _Filtered; } set { _Filtered = value; this.RaisePropertyChanged(nameof(Filtered)); } }
    }
}
