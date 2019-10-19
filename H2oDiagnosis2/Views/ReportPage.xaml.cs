using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace H2oDiagnosis2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        ContentPage m_NextPage;
        public ReportPage()
        {
            InitializeComponent();
        }

        async void OnNext_Clicked(object sender, EventArgs args)
        {
            //if (null == m_NextPage)
            //{
            //    m_NextPage = new RWHSPage();
            //}
            ////MessagingCenter.Send(this, "CANData", x);

            ////MessagingCenter.Subscribe<this, H2oData>(this, "test", async (obj, item) =>


            //await Navigation.PushAsync(m_NextPage);
        }
    }
}