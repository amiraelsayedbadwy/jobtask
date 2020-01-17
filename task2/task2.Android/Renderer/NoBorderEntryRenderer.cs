using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using task2.Controls;
using task2.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(NoBorderEntriy), typeof(NoBorderEntryRenderer))]
namespace task2.Droid.Renderer
{
   public class NoBorderEntryRenderer : EntryRenderer
    {
        public NoBorderEntryRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
                Control.TextAlignment = Android.Views.TextAlignment.Gravity;
                Control.SetPadding(0, 0, 0, 0);
                IntPtr IntPtrtextViewClass = JNIEnv.FindClass(typeof(TextView));
                IntPtr mCursorDrawableResProperty = JNIEnv.GetFieldID(IntPtrtextViewClass, "mCursorDrawableRes", "I");
                JNIEnv.SetField(Control.Handle, mCursorDrawableResProperty, Resource.Drawable.cursor_drawable);

                var noBorderEntry = Element as NoBorderEntriy;

                if (noBorderEntry != null && !noBorderEntry.DisplaySuggestions)
                {
                    Control.InputType = Android.Text.InputTypes.TextFlagNoSuggestions;
                }
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);


        }
    }
}