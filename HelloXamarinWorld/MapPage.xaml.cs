using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using HelloXamarinWorld.Model;
using SQLite;

namespace HelloXamarinWorld
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        private bool hasLocationPermission = false;
        public MapPage()
        {
            InitializeComponent();

            GetPermissions();
        }

        [Obsolete]
        private async void GetPermissions()
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.LocationWhenInUse))
                    {
                        await DisplayAlert("We need your location", "We need to access your current location", "OK");
                    }

                    var result = await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse);
                    if (result.ContainsKey(Permission.LocationWhenInUse))
                        status = result[Permission.LocationWhenInUse];
                }

                if (status == PermissionStatus.Granted)
                {
                    hasLocationPermission = true;
                    GetLocation();

                    locationMap.MyLocationEnabled = true;
                    locationMap.IsShowingUser = true;
                }
                else
                {
                    await DisplayAlert("Location Denied", "Location Denied, You didn't give us permission to access location", "OK");
                }

            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            GetLocation();
            if (hasLocationPermission)
            {
                CrossGeolocator.Current.PositionChanged += Current_PositionChanged;
                await CrossGeolocator.Current.StartListeningAsync(TimeSpan.Zero, Constants.Min_DistanceToListenToLocation_Meter);
            }

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var experiences = conn.Table<Post>().ToList();
                DisplayInMap(experiences);
            }
        }

        private void DisplayInMap(List<Post> experiences)
        {
            foreach (var post in experiences)
            {
                try
                {
                    var position = new Xamarin.Forms.GoogleMaps.Position(post.Latitude, post.Longitude);

                    var pin = new Xamarin.Forms.GoogleMaps.Pin()
                    {
                        Type = Xamarin.Forms.GoogleMaps.PinType.SavedPin,
                        Label = post.VenueName,
                        Address = post.Address,
                        Position = position,
                        Rotation = 33.3f,
                        Tag = "id_osama",
                    };
                    locationMap.Pins.Add(pin);
                }
                catch (NullReferenceException nre) { }
                catch (Exception ex) { }
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossGeolocator.Current.StopListeningAsync();
            CrossGeolocator.Current.PositionChanged -= Current_PositionChanged;
        }
        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            MoveMap(e.Position);
        }

        private async void GetLocation()
        {
            if (hasLocationPermission)
            {
                var locator = CrossGeolocator.Current;
                var position = await locator.GetPositionAsync();

                MoveMap(position);
            }
        }

        private void MoveMap(Position position)
        {
            var center = new Xamarin.Forms.GoogleMaps.Position(position.Latitude, position.Longitude);
            var mapSpan = new Xamarin.Forms.GoogleMaps.MapSpan(center, Constants.Latitude_Degrees, Constants.Longitude_Degrees);
            locationMap.MoveToRegion(mapSpan);
        }
    }
}