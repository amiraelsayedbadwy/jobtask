using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace task2.Behaviors
{
    public class DisableListItemSelectionBehavior : Behavior<Xamarin.Forms.ListView>
    {
        protected override void OnAttachedTo(Xamarin.Forms.ListView bindable)
        {
            base.OnAttachedTo(bindable);

            if (Device.RuntimePlatform == Device.Android)
            {
                bindable.ItemSelected += ListViewOnItemSelected;
            }
        }

        protected override void OnDetachingFrom(Xamarin.Forms.ListView bindable)
        {
            base.OnDetachingFrom(bindable);

            if (Device.RuntimePlatform == Device.Android)
            {
                bindable.ItemSelected -= ListViewOnItemSelected;
            }
        }

        private void ListViewOnItemSelected(object sender, SelectedItemChangedEventArgs selectedItemChangedEventArgs)
        {
            ((Xamarin.Forms.ListView)sender).SelectedItem = null;
        }
    }
}
