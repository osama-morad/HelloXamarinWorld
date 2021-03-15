using System;
using System.Collections.Generic;
using System.Text;

namespace HelloXamarinWorld.Model
{
    public static class Constants
    {
        public static string Google_API_KEY = "AIzaSyCCpzQMk0aqReAr-oAiWQk-MY3CJOc6H-8";
        public static double Latitude_Degrees = 0.1;
        public static double Longitude_Degrees = 0.1;
        public static double Min_DistanceToListenToLocation_Meter = 100;

        public const string VENUE_SEARCH = "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "V4URVK2RG5FUE4WVDW1VK5QC2Q0ZUBVBVDUFC0G0X1VDPY33";
        public const string CLIENT_SECRET = "OYCVEC4UGSK1OGKXT54FCI4CFLEETTSZZJ3MPWLL0UE5DWBU";

    }
}
