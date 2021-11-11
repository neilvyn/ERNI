using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ERNITech.Views
{
    public partial class UsersPage : ContentPage
    {
        public UsersPage()
        {
            InitializeComponent();
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

        void ListView_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            if (e.Item == null) return;
            if (sender is ListView lv) lv.SelectedItem = null;
        }
    }
}
