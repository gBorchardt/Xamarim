using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Ap22_CustomControlNative.Controls;
using Ap22_CustomControlNative.iOS.Controls;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomBoxView), typeof(CustomBoxViewRenderer))]
namespace Ap22_CustomControlNative.iOS.Controls
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public CustomBoxViewRenderer()
        {
            
        }

        public override void Draw(CGRect rect)
        {
            //base.Draw(rect);

            var control = (CustomBoxView)Element;

            using (var context = UIGraphics.GetCurrentContext())
            {
                context.SetStrokeColor(new CGColor(0, 0, 0));
                context.SetLineWidth((float)control.Espessura);

                var rectPath = new CGRect(0, 0, 200, 200);

                context.AddRect(rectPath);
                context.DrawPath(CGPathDrawingMode.Stroke);
            }

        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == CustomBoxView.EspessuraProperty.PropertyName)
                SetNeedsDisplay();
        }
    }
}