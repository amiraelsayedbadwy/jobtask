using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace task2.Controls
{
   public class NoBorderEntriy : Entry
    {
        public static BindableProperty DisplaySuggestionsProperty = BindableProperty.Create(nameof(DisplaySuggestions), typeof(bool), typeof(NoBorderEntriy), true);

        public NoBorderEntriy() { this.TextChanged += NoBorderEntry_TextChanged; }

        private void NoBorderEntry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public bool DisplaySuggestions
        {
            get { return (bool)GetValue(DisplaySuggestionsProperty); }
            set { SetValue(DisplaySuggestionsProperty, value); }
        }

    }
}