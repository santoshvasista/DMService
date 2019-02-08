using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class AddressComponent
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Northeast
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Southwest
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Viewport
    {
        public Northeast northeast { get; set; }
        public Southwest southwest { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        public Viewport viewport { get; set; }
    }

    public class PlusCode
    {
        public string compound_code { get; set; }
        public string global_code { get; set; }
    }

    public class Result
    {
        public List<AddressComponent> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }
        public string place_id { get; set; }
        public PlusCode plus_code { get; set; }
        public List<string> types { get; set; }
    }

    public class MEGeoViewModel
    {
        public List<Result> results { get; set; }
        public string status { get; set; }
    }

    //public class MEGeoViewModel
    //{
    //    public List<MeGeoResultViewModel> results;
    //    public string status;

    //}

    //public class MeGeoResultViewModel
    //{
    //    public List<MeGeoNameViewModel> address_components;
    //    public string formatted_address;
    //    public List<MeGeometryViewModel> geometry;
    //    public string place_id;
    //    public MePlusCode plus_code;
    //    public List<string> types;
    //}

    //public class MeGeoNameViewModel
    //{
    //    public string long_name;
    //    public string short_name;
    //    public List<string> types;
    //}


    //public class MeGeometryViewModel
    //{
    //    public MeGeoLocationViewModel location;
    //    public string location_type;
    //    public MeViewPortViewModel viewport;
    //    //public string place_id;
    //}

    //public class MeGeoLocationViewModel
    //{
    //    public string lat;
    //    public string lng;
    //}

    //public class MeViewPortViewModel
    //{
    //    public MeGeoLocationViewModel northeast;
    //    public MeGeoLocationViewModel southwest;
    //    //public string place_id;
    //    //public MePlusCode plus_code;
    //}

    //public class MePlusCode
    //{
    //    public string compound_code;
    //    public string global_code;
    //}
}
