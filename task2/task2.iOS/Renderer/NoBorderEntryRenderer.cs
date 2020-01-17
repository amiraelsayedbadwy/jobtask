using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using task2.Controls;
using task2.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(NoBorderEntriy), typeof(NoBorderEntryRenderer))]
namespace task2.iOS.Renderer
{
    public class NoBorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Clear;
                Control.BorderStyle = UITextBorderStyle.None;
                Control.TintColor = UIColor.FromRGB(0, 158, 213);

                if (Element is NoBorderEntriy noBorderEntry)
                {
                    if (!noBorderEntry.DisplaySuggestions)
                    {
                        Control.AutocorrectionType = UITextAutocorrectionType.No;
                    }

                }
            }
        }


    }
}