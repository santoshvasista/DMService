using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class MEProviderAddressViewModel
    {

        public MEProviderAddressViewModel(string name, string address, double lat, double lng)
        {
            Name = name;
            Address = address;
            Lat = lat;
            Lng = lng;
        }
        public string Name { get; set; }
        //public List<string> TreatmentType { get; set; }
        public string Address { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }

    }
}
