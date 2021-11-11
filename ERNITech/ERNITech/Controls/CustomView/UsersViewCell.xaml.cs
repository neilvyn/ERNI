using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ERNITech.Controls.CustomView
{
    public partial class UsersViewCell : ContentView
    {
        #region bindables
        // key: bpro_twoway, datatype: string, property: Image, class: UsersViewCell
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image), typeof(string), typeof(UsersViewCell), default(string), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as UsersViewCell;
        });
        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // key: bpro_twoway, datatype: int, property: UserId, class: UsersViewCell
        public static readonly BindableProperty UserIdProperty = BindableProperty.Create(nameof(UserId), typeof(int), typeof(UsersViewCell), default(int), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as UsersViewCell;
        });
        public int UserId
        {
            get { return (int)GetValue(UserIdProperty); }
            set { SetValue(UserIdProperty, value); }
        }

        // key: bpro_twoway, datatype: string, property: Name, class: UsersViewCell
        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(string), typeof(UsersViewCell), default(string), BindingMode.TwoWay, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var view = bindable as UsersViewCell;
        });
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        #endregion

        public UsersViewCell()
        {
            InitializeComponent();
        }
    }
}
