using System;
using System.Collections.Generic;
using System.Text;

namespace H2oDiagnosis2.Models
{
    public enum ApartmentType
    {
        IndividualHouse,
        Apartment,
        SemiGated,
        Gated
    };

    public enum RWHSType
    {
        Storage,// sampu
        Bores,// 
        Pits
    };

    public enum RecPlantType
    {
        Non_PotableUsage,// 
        DomesticUsage
    };

    public struct MyLocation
    {
        public double m_Lat;
        public double m_Long;
        public double m_Alt;
    };

    public struct H20DiagnosticsInputData
    {
        public string m_Name;
        public long m_MobileNumber;
        public string m_EmailId;// Optional
        public string m_CANID;// Optional
        public MyLocation m_Location;

        public ApartmentType m_AptType;
        public double m_RoofArea;
        public int m_FlatCount;
        public int m_PeopleCount;// Optional
        public bool m_WaterMeters;// Optional
        public bool m_TapWaterSavers;// Optional

        public bool m_RWHSExists;
        public RWHSType m_RWHSType;// // Optional based on above
        public int m_BoreWellCount;
        public int m_FunctBoreWellCount;

        public bool m_RecPlantExists;
        public RecPlantType m_RecPlantType;// Optional
        public double m_RecPlantCapacity;// Liters
    };

    public struct H20DiagnosticsOutputData
    {
        public double m_UsageLtMin;
        public double m_UsageLtMax;
        public double m_RWHSWaterLt;
        public double m_RWHSCostMin;
        public double m_RWHSCostMax;
        public double m_RecPlantWaterLtMin;
        public double m_RecPlantWaterLtMax;
        public double m_RecPlantCostMin;
        public double m_RecPlantCostMax;
        public double m_PowerBill;
        public double m_UsageScore;
    };

    public struct H20DiagnosticsData
    {
        public H20DiagnosticsInputData m_H20DiagIpData;
        public H20DiagnosticsOutputData m_H20DiagOpData;
    };
}
