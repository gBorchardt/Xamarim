using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App20_CustomRenderer.Customs;
using App20_CustomRenderer.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace App20_CustomRenderer.Droid
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if(Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.Button_Round);
            }
        }
    }
}