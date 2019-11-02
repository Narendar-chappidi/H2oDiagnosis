using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using H2oReport.H2oDiagnosis2.Models;
//using Microsoft.Office.Interop.Word;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using H2oDiagnosis2.Models;
using H2oDiagnosis2.Views;
using System.Net.Mail;

namespace H2oDiagnosis2.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class ReportPage : ContentPage
   {
      ContentPage m_NextPage;
     H20DiagnosticsData m_h2oDiagsData { get; set; }
      public ReportPage(H20DiagnosticsData h2oDiagsDataParam)
      {
         InitializeComponent();

         m_h2oDiagsData = h2oDiagsDataParam;

         BindingContext = m_h2oDiagsData;
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

      void OnSendReport()
      {
         H2oReporter reporter = new H2oReporter();
         reporter.Report(m_h2oDiagsData);
      }
   }
}