using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App24_GestosAnimacoes
{
    public partial class MainPage : ContentPage
    {
        int count;
        public MainPage()
        {
            InitializeComponent();

            //Gesture
            // Tap - Toque/Click
            // Pinch - Pinça (Galeria de Imagens)
            // Pan - Mover & Arrastar (Objetos)

            var pan = new PanGestureRecognizer();
            pan.PanUpdated += PanGestureRecognizer_Pan;

            MyLabel.GestureRecognizers.Add(pan);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            count++;
            //DisplayAlert("Tapped", "Label Clicada: " + count, "OK");

            //Animações Xamarin
            //MyBox.TranslateTo(200, 350, 1000, Easing.BounceOut);
            //MyBox.ScaleTo(2, 5000);
            //MyBox.FadeTo(0.5, 1000);
            //MyBox.RotateTo(45, 1000);

            var anim = new Animation(v => MyBox.WidthRequest = v, 50, 100);
            anim.Commit(this, "animação", length: 1000);
        }

        private void PanGestureRecognizer_Pan(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
            {

                var rect = new Rectangle(e.TotalX, e.TotalY, 200, 25);

                AbsoluteLayout.SetLayoutBounds(MyLabel, rect);
                AbsoluteLayout.SetLayoutFlags(MyLabel, AbsoluteLayoutFlags.None);
            }
        }
    }
}
