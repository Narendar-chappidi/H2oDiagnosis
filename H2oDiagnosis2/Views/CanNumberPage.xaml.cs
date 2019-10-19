using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //H20DiagnosticsInputData h2o

        ContentPage m_NextPage;

        public CanNumberPage()
        {
            InitializeComponent();

            //x = new H2oData
            //{
            //    CanNo = "Can No",
            //    LatLong = "lat"
            //};
            BindingContext = this;

            //BindingContext = CANModel = new CANNumberModel();
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            if(null == m_NextPage)
            {
                m_NextPage = new HouseDetailsPage();
            }
            //MessagingCenter.Send(this, "CANData", x);

            //MessagingCenter.Subscribe<this, H2oData>(this, "test", async (obj, item) =>

           
            await Navigation.PushAsync(m_NextPage);
        }
    }
}