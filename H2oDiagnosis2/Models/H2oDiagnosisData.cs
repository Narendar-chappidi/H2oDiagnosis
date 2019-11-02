using System;
using System.Collections.Generic;
using System.Text;
using H2oReport;

namespace H2oDiagnosis2.Models
{
   // public enum ApartmentType
   // {
   //     IndividualHouse,
   //     Apartment,
   //     SemiGated,
   //     Gated
   // };

   // public enum RWHSType
   // {
   //     Storage,// sampu
   //     Bores,// 
   //     Pits
   // };

   // public enum RecPlantType
   // {
   //     Non_PotableUsage,// 
   //     DomesticUsage
   // };

   // public struct MyLocation
   // {
   //     public float m_Lat;
   //     public float m_Long;
   //     public float m_Alt;
   // };

   // public class H20DiagnosticsInputData
   // {
   //     //public string m_PageName { get; set; }
   //     public string m_Name { get; set; }
   //     public long m_MobileNumber { get; set; }
   //     public string m_EmailId { get; set; }// Optional
   //     public int m_CANID { get; set; }// Optional
   //     public MyLocation m_Location { get; set; }

   //     public int m_AptType { get; set; }
   //     public double m_RoofArea { get; set; }
   //     public int m_FlatCount { get; set; }
   //     public int m_PeopleCount { get; set; }// Optional
   //     public bool m_WaterMeters { get; set; }// Optional
   //     public bool m_TapWaterSavers { get; set; }// Optional

   //     public bool m_RWHSExists { get; set; }
   //     public int m_RWHSType { get; set; }// // Optional based on above
   //     public bool m_RWHSIsOverFlow { get; set; }
   //     public int m_BoreWellCount { get; set; }
   //     public int m_FunctBoreWellCount { get; set; }

   //     public bool m_RecPlantExists { get; set; }
   //     public int m_RecPlantType { get; set; }// Optional
   //     public double m_RecPlantCapacity { get; set; }// Liters
   // };

   // public struct H20DiagnosticsOutputData
   // {
   //     public double m_UsageLtMin;
   //     public double m_UsageLtMax;
   //     public double m_RWHSWaterLtMin;
   //     public double m_RWHSWaterLtMax;
   //     public double m_RWHSCostMin;
   //     public double m_RWHSCostMax;
   //     public double m_RecPlantWaterLtMin;
   //     public double m_RecPlantWaterLtMax;
   //     public double m_RecPlantCostMin;
   //     public double m_RecPlantCostMax;
   //     public double m_PowerBill;
   //     public double m_UsageScore;
   // };

   [Serializable]
   public class MuncipalCAN
   {
      public string Name { get; set; }
      public long PhoneNumber { get; set; }
      public string Mailid { get; set; }
      public long CANId { get; set; }
      public float Latitude { get; set; }
      public float Longitude { get; set; }
      public string ApartmentType { get; set; }
      public long RoofArea { get; set; }
      public int FlatCount { get; set; }
      public int PeopleCount { get; set; }
      public bool WaterMeter { get; set; }
      public bool TapWaterSavers { get; set; }
      public bool RWHS { get; set; }
      public string RWHSType { get; set; }
      public bool RWHSOverflow { get; set; }
      public short BoreWellCount { get; set; }
      public short FunctBoreWellCount { get; set; }
      public bool RecyclingPlant { get; set; }
      public string RecyclingPlantType { get; set; }
      public Nullable<long> PlantCapacity { get; set; }
      public short UsageScore { get; set; }
   }

   //public struct H20DiagnosticsData
   // {
   //     public H20DiagnosticsInputData m_H20DiagIpData;
   //     public H20DiagnosticsOutputData m_H20DiagOpData;
   // };
}
