using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace H2oDiagnosis2.ViewModels
{
   public class MainViewModel
   {
      //IGoogleMapsApiService googleMapsApi = new GoogleMapsApiService();
      //public bool HasRouteRunning { get; set; }
      public ICommand GetLocationNameCommand { get; set; }
      //public bool IsRouteNotRunning { get { return !HasRouteRunning; } }

      public double m_lat { get; set; }
      public double m_long { get; set; }
      public string m_Place { get; set; }

      public MainViewModel()
      {
         GetLocationNameCommand = new Command<Position>(async (param) => await GetLocationName(param));
      }


      //Get place 
      public async Task GetLocationName(Position position)
      {
         try
         {
            var placemarks = await Geocoding.GetPlacemarksAsync(position.Latitude, position.Longitude);
            m_lat = position.Latitude;
            m_long = position.Longitude;
            var placemark = placemarks?.FirstOrDefault();
            if (placemark != null)
            {
               m_Place = placemark.SubLocality + "," + placemark.Locality + "," + placemark.AdminArea;
            }
            else
            {
               m_Place = string.Empty;
            }
            //var placemark = placemarks?.FirstOrDefault();
            //if (placemark != null)
            //{
            //   PickupText = placemark.FeatureName;
            //}
            //else
            //{
            //   PickupText = string.Empty;
            //}
         }
         catch (Exception ex)
         {
            //Debug.WriteLine(ex.ToString());
         }
      }

   }
}
