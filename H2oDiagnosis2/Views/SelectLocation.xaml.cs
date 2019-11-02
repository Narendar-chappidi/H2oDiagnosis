using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Xamarin.Forms.GoogleMaps;
using H2oReport.H2oDiagnosis2.Models;


namespace H2oDiagnosis2.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class SelectLocation : ContentPage
   {
      public static readonly BindableProperty GetActualLocationCommandProperty =
       BindableProperty.Create(nameof(GetActualLocationCommand), typeof(ICommand), typeof(SelectLocation), null, BindingMode.TwoWay);
      //public static readonly BindableProperty GetLocationNameCommandProperty =
      //BindableProperty.Create(nameof(GetLocationNameCommand), typeof(ICommand), typeof(SelectLocation), null, BindingMode.TwoWay);

      public ICommand GetLocationNameCommand { get; set; }
      //{
      //   get { return (ICommand)GetValue(GetLocationNameCommandProperty); }
      //   set { SetValue(GetLocationNameCommandProperty, value); }
      //}

      public double m_lat { get { return MyModel.m_lat; } }
      public double m_long { get { return MyModel.m_long; } }
      public string m_Place { get { return MyModel.m_Place; } }

      public SelectLocation()
      {
         InitializeComponent();

         GetActualLocationCommand = new Command(async () => await GetActualLocation());
      }

      public async void OnEnterAddressTapped(object sender, EventArgs e)
      {
         //await Navigation.PushAsync(new SearchPlacePage() { BindingContext = this.BindingContext }, false);

      }


      protected override void OnAppearing()
      {
         base.OnAppearing();
         GetActualLocationCommand.Execute(null);
      }


      public ICommand GetActualLocationCommand
      {
         get { return (ICommand)GetValue(GetActualLocationCommandProperty); }
         set { SetValue(GetActualLocationCommandProperty, value); }
      }
      async Task GetActualLocation()
      {
         try
         {
            //var request = new GeolocationRequest(GeolocationAccuracy.High);
            //var location = await Geolocation.GetLocationAsync(request);
            var location = new Location() { Latitude = 17.4427969, Longitude = 78.3741511, Altitude = 13 };

            if (location != null)
            {
               MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                   new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));
            }
         }
         catch (Exception ex)
         {
            await DisplayAlert("Error", "Unable to get actual location", "Ok");
         }
      }
   }
}
