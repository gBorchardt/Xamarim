using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

#if __ANDROID__
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Support.Design.Widget;
#endif

#if __IOS__
using UIKit;
using Xamarin.Forms.Platform.iOS;
#endif

namespace App19_SharedProject
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

#if __ANDROID__

            var labelDroid = new TextView(Forms.Context) { Text = "Eu Sou Android Nativo!" };
            SLContainer.Children.Add(labelDroid);

            var floatButton = new FloatingActionButton(Forms.Context);
            floatButton.SetImageResource(Droid.Resource.Drawable.ic_media_play_dark);
            ABSContainer.Children.Add(floatButton);

            floatButton.Click += FloatButton_Click;
#endif


#if __IOS__

            var labelIOS = new UILabel() { Text = "Eu Sou iOS Nativo!" };
            SLContainer.Children.Add(labelIOS);
#endif

        }

        private void FloatButton_Click(object sender, EventArgs e)
        {
            DisplayAlert("FloatButton", "Clicado", "OK");
        }
    }
}
