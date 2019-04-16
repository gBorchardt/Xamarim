using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App33_Mapas
{
    public partial class MainPage : ContentPage
    {
        Map _mapa;

        public MainPage()
        {
            InitializeComponent();

            CrirMapa();

            PermissaoGPSAsync();
        }

        private async Task PermissaoGPSAsync()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Permission.Location))
                        status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var gps = new GPS();
                    if (gps.IsLocationAvailable())
                    {
                        var pos = gps.GetCurrentLocation().GetAwaiter().GetResult();

                        if (pos != null)
                        {
                            var myPos = new Pin()
                            {
                                Position = new Position(pos.Latitude, pos.Longitude),
                                Label = "Minha Posição"
                            };

                            _mapa.Pins.Add(myPos);
                        }
                    }

                    _mapa.IsShowingUser = true;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void CrirMapa()
        {
            _mapa = new Map(MapSpan.FromCenterAndRadius(new Position(-31.760983, -52.3379485), Distance.FromKilometers(2)))
            {
                MapType = MapType.Street,
            };

            var estadio = new Pin()
            {
                Position = new Position(-31.760983, -52.3357598),
                Label = "Estádio Boca do Lobo",
                Address = "R. Antônio dos Anjos, 300 - Centro, Pelotas - RS, 96020-700"
            };

            var pizzaria = new Pin()
            {
                Position = new Position(-31.7598356, -52.336248),
                Label = "Pizzaria Pizzarela",
                Address = "R. Padre Anchieta, 2980 - Centro, Pelotas - RS, 96020-720"
            };

            _mapa.Pins.Add(estadio);
            _mapa.Pins.Add(pizzaria);

            MapContainer.Children.Add(_mapa);
        }
    }
}
