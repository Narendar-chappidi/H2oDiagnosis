using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using H2oDiagnosis2.Models;
using H2oDiagnosis2.Views;
using H2oReport.H2oDiagnosis2.Models;

namespace H2oDiagnosis2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RWHSPage : ContentPage
    {
        ContentPage m_NextPage;
        H20DiagnosticsInputData h2oDiagsData { get; set; }
        public RWHSPage(H20DiagnosticsInputData h2oDiagsDataParam)
        {
            InitializeComponent();

            h2oDiagsData = h2oDiagsDataParam;

            BindingContext = h2oDiagsData;
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                h2oDiagsData.m_RWHSType = selectedIndex;
            }
        }

        void OnToggled(object sender, ToggledEventArgs e)
        {
            // Perform an action after examining e.Value
        }

        async void OnNext_Clicked(object sender, EventArgs args)
        {
            if (null == m_NextPage)
            {
                m_NextPage = new RecPlantPage(h2oDiagsData);
            }

            await Navigation.PushAsync(m_NextPage);
        }
    }
}