using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Ap22_CustomControlNative.Controls;
using Ap22_CustomControlNative.Droid.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomBoxView),typeof(CustomBoxViewRenderer))]
namespace Ap22_CustomControlNative.Droid.Controls
{
    public class CustomBoxViewRenderer : BoxRenderer
    {
        public CustomBoxViewRenderer()
        {
            SetWillNotDraw(false);
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            var control = (CustomBoxView)Element;

            var p = new Paint();
            p.StrokeWidth = (float)control.Espessura;
            p.Color = Android.Graphics.Color.Black;
            p.SetStyle(Paint.Style.Stroke);

            var rect = new Rect(0, 0, 200, 200);

            canvas.DrawRect(rect, p);

            canvas.DrawLine(100, 0, 100, 200, p);

            canvas.DrawLine(0, 100, 200, 100, p);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Invalidate();
        }
    }
}