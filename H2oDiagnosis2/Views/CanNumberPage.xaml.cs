using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H2oReport.H2oDiagnosis2.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using H2oDiagnosis2.Models;
using H2oDiagnosis2.Views;

namespace H2oDiagnosis2.Views
{
    //[DesignTimeVisible(false)]
    public partial class CanNumberPage : ContentPage
    {
        //CANNumberModel CANModel;
        //public H2oData x { get; set; }
        //H2oData x;
        public H20DiagnosticsInputData h2oDiagsData { get; set; }

        ContentPage m_NextPage;
      SelectLocation m_MapSelectPage;
      string m_PlaceText = string.Empty;

        public CanNumberPage()
        {
            InitializeComponent();

            h2oDiagsData = new H20DiagnosticsInputData { };
            //h2oDiagsData.m_PageName = "CAN Page";

            BindingContext = h2oDiagsData;

         //BindingContext = CANModel = new CANNumberModel();
      }

      async void OnSelectLocationClicked(object sender, EventArgs args)
      {
         if (null == m_MapSelectPage)
         {
            m_MapSelectPage = new SelectLocation();
         }
         await Navigation.PushAsync(m_MapSelectPage);

      }

      async void OnButtonClicked(object sender, EventArgs args)
        {
            if(null == m_NextPage)
            {
                m_NextPage = new HouseDetailsPage(h2oDiagsData);
            }

         if (m_MapSelectPage != null)
         {
            h2oDiagsData.m_Location = new MyLocation
            {
               m_Lat = (float)m_MapSelectPage.m_lat,
               m_Long = (float)m_MapSelectPage.m_long
         };
            m_PlaceText = m_MapSelectPage.m_Place;
         }
            await Navigation.PushAsync(m_NextPage);
        }
    }
}