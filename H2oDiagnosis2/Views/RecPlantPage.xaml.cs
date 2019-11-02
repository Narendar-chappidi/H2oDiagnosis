using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using H2oDiagnosis2.Models;
using H2oDiagnosis2.Views;
using System.Net.Http;
using Newtonsoft.Json;
using H2oReport.H2oDiagnosis2.Models;

namespace H2oDiagnosis2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecPlantPage : ContentPage
    {
        ContentPage m_NextPage;
        H20DiagnosticsInputData h2oDiagsData { get; set; }
        public RecPlantPage(H20DiagnosticsInputData h2oDiagsDataParam)
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
                h2oDiagsData.m_RecPlantType = selectedIndex;
            }
        }

      static int i = 10;

      H20DiagnosticsOutputData CalculateUsageScore()
      {
         H20DiagnosticsOutputData opData = new H20DiagnosticsOutputData();

         const int m_AvgPeopleCount = 4;
         const int m_WaterPerCapitaMin = 100;
         const int m_WaterPerCapitaMax = 135;
         const double m_RunOffCoeff = 0.9;
         const double m_AnnualRainfall = 824.7;
         const double m_LtCostMin = 0.2;
         const double m_LtCostMax = 0.5;
         const double m_DaysInYear = 365;

         H20DiagnosticsInputData ipData = h2oDiagsData;

            opData.m_UsageLtMin = ipData.m_FlatCount * m_AvgPeopleCount * m_WaterPerCapitaMin * m_DaysInYear;
            opData.m_UsageLtMax = ipData.m_FlatCount * m_AvgPeopleCount * m_WaterPerCapitaMax * m_DaysInYear;

            opData.m_RWHSWaterLtMin = ipData.m_RoofArea * 0.0929 * m_RunOffCoeff * m_AnnualRainfall * 0.8;
            opData.m_RWHSWaterLtMax = ipData.m_RoofArea * 0.0929 * m_RunOffCoeff * m_AnnualRainfall * 0.9;

            opData.m_RWHSCostMin = opData.m_RWHSWaterLtMin * m_LtCostMin;
            opData.m_RWHSCostMax = opData.m_RWHSWaterLtMax * m_LtCostMax;
            
            opData.m_RecPlantWaterLtMin = opData.m_UsageLtMin * 0.3;
            opData.m_RecPlantWaterLtMax = opData.m_UsageLtMax * 0.5;

            opData.m_RecPlantCostMin = opData.m_RecPlantWaterLtMin * m_LtCostMin;
            opData.m_RecPlantCostMax = opData.m_RecPlantWaterLtMax * m_LtCostMax;

         //opData.m_PowerBill
         opData.m_UsageScore += 100;
         if (ipData.m_RWHSExists)
         {
            if (ipData.m_RWHSIsOverFlow)
            {
               opData.m_UsageScore += 0;
            }
            else
            {
               //if (overflow)
               {
                  if (ipData.m_RWHSType == 0) // Storage
                     opData.m_UsageScore += 100;
                  else if (ipData.m_RWHSType == 1) // Directly sent to Recharge Pits
                     opData.m_UsageScore += 70;
                  else if (ipData.m_RWHSType == 2) // Directly sent to borewell
                     opData.m_UsageScore += 50;
               }
            }
         }
         else
         {
         }         

         if (ipData.m_RecPlantExists)
         {
            if (ipData.m_RecPlantType == 1) // non-potable
               opData.m_UsageScore += 50;
            else // domestic use
               opData.m_UsageScore += 70;
         }
         else
         {
            opData.m_UsageScore += 0;
         }

         opData.m_UsageScore = opData.m_UsageScore / 3;
            return opData;
      }

      async void OnNext_Clicked(object sender, EventArgs args)
        {
         H20DiagnosticsData data = new H20DiagnosticsData();
         data.m_H20DiagIpData = h2oDiagsData;
        data.m_H20DiagOpData = CalculateUsageScore();

            if (null == m_NextPage)
            {
                m_NextPage = new ReportPage(data);
            }
         //MessagingCenter.Send(this, "CANData", x);

         //MessagingCenter.Subscribe<this, H2oData>(this, "test", async (obj, item) =>


         string apartmentType = string.Empty;
         switch (h2oDiagsData.m_AptType)
         {
            case 0:
               apartmentType = "individual";
               break;
            case 1:
               apartmentType = "apartment";
               break;
            case 2:
               apartmentType = "gated";
               break;
            case 3:
               apartmentType = "semi-gated";
               break;
            default:
               apartmentType = "individual";
               break;
         }

         string rwhsType = string.Empty;
         switch (h2oDiagsData.m_RWHSType)
         {
            case 0:
               rwhsType = "Storage";
               break;
            case 1:
               rwhsType = "Bores";
               break;
            case 2:
               rwhsType = "Pits";
               break;
            default:
               rwhsType = "Pits";
               break;
         }

         string recPlantType = string.Empty;
         switch (h2oDiagsData.m_RecPlantType)
         {
            case 0:
               recPlantType = "Nonpotable";
               break;
            case 1:
               recPlantType = "Domestic";
               break;
            default:
               recPlantType = "Domestic";
               break;
         }



         MuncipalCAN can = new MuncipalCAN
         {
            Name = h2oDiagsData.m_Name,
            PhoneNumber = h2oDiagsData.m_MobileNumber,
            Mailid = h2oDiagsData.m_EmailId,
            CANId = h2oDiagsData.m_CANID,
            Latitude = h2oDiagsData.m_Location.m_Lat,
            Longitude = h2oDiagsData.m_Location.m_Long,
            ApartmentType = apartmentType,
            RoofArea = (long)h2oDiagsData.m_RoofArea,
            FlatCount = h2oDiagsData.m_FlatCount,
            PeopleCount = h2oDiagsData.m_PeopleCount,
            WaterMeter = h2oDiagsData.m_WaterMeters,
            TapWaterSavers = h2oDiagsData.m_TapWaterSavers,
            RWHS = h2oDiagsData.m_RWHSExists,
            RWHSType = rwhsType,
            RWHSOverflow = h2oDiagsData.m_RWHSIsOverFlow,
            BoreWellCount = (short)h2oDiagsData.m_BoreWellCount,
            FunctBoreWellCount = (short)h2oDiagsData.m_FunctBoreWellCount,
            RecyclingPlant = h2oDiagsData.m_RecPlantExists,
            RecyclingPlantType = recPlantType,
            PlantCapacity = (long)h2oDiagsData.m_RecPlantCapacity,
            UsageScore = (short)data.m_H20DiagOpData.m_UsageScore
         };

         HttpClient httpClient = new HttpClient();
         //HttpRequestMessage reqMsg = new HttpRequestMessage(HttpMethod.Post, "http://IN-HGS3300:62148/");
         //reqMsg.Headers.Add("Accept-Language", "application/json");
         //reqMsg.Headers.Add("Content-Type", "application/json");
         httpClient.BaseAddress = new Uri("http://IN-HGS3300:62250/");

         httpClient.DefaultRequestHeaders.Add("Accept-Language", "application/json");
         httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
         string body = JsonConvert.SerializeObject(can);

         HttpContent content = new StringContent(body);

         try
         {
            HttpResponseMessage response = await httpClient.PostAsync("api/H2ODiagnostics/v1/", content);
         }
         catch(SystemException)
         {

         }



            await Navigation.PushAsync(m_NextPage);
        }
    }
}


