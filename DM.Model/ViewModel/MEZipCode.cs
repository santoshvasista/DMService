using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class ZipCode
    {
        public string zip_code { get; set; }
        public double distance { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class ZipCodeRoot
    {
        public List<ZipCode> zip_codes { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string zipcode { get; set; }
        public int error_code { get; set; }
        public string error_msg { get; set; }
    }

    public class ZipCodesStates
    {
        public string county { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string data { get; set; }
        public string zipcode { get; set; }
    }
}
