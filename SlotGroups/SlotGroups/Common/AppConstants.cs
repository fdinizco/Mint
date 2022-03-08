using System;
namespace SlotGroups.Common
{
    public static class AppConstants
    {
        //Basically what we have here is a static class to handlle all general contants in the app

        //Project Name - default
        public const string ProjectName = "Slot Groups";

        //Mint image URL
        public const string MintImageURL = "https://mintsoftwaresystems.com/wp-content/uploads/2022/03/MINT_logo_white_top_nav-01.png";

        //Back SVG
        public const string BackImage = "resource://SlotGroups.Resources.SVG.arrow_back.svg";

        //URL to consume API
        public const string ApiURL = "https://run.mocky.io";

        //Data backup
        public const string Data = "{\"categoryName\":\"B737NGQualification\",\"eventName\":\"TrafficAirManagementtraining\",\"slotGroups\":[{\"resources\":[{\"certificates\":[],\"firstName\":\"Ricardo\",\"name\":\"Delgado\",\"photo\":\"https://randomuser.me/api/portraits/men/97.jpg\",\"userId\":\"rdelgado\"}],\"slotGroupName\":\"Instructor\"},{\"resources\":[{\"certificates\":[\"AvSafetyseminar\",\"Flightinstruments\",\"Flightsimulator\"],\"firstName\":\"Aarav\",\"name\":\"Patel\",\"photo\":\"https://randomuser.me/api/portraits/men/4.jpg\",\"userId\":\"apatel\"},{\"certificates\":[],\"firstName\":\"Veri\",\"name\":\"Setiawan\",\"photo\":\"https://uifaces.co/our-content/donated/AW-rdWlG.jpg\",\"userId\":\"vsetiawan\"}],\"slotGroupName\":\"Observer\"}]}";
    }
}
