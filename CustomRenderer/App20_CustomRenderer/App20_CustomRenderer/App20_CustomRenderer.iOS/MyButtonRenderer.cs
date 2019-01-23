using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App20_CustomRenderer.Customs;
using App20_CustomRenderer.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyButton), typeof(MyButtonRenderer))]
namespace App20_CustomRenderer.iOS
{
    public class MyButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Layer.CornerRadius = 10; // this value vary as per your desire
                Control.ClipsToBounds = true;
                Control.BackgroundColor = UIColor.Blue;
            }
        }
    }
}