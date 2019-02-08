using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.ViewModel
{
    public class MEResultViewModel
    {
        //public string geoObj;
        //public string distanceObj;
        public double lat;
        public double lng;
        public string name;
        public string address;
        public string distance;

    }

    public class MEOutputViewModel
    {
        public MEOutputViewModel()
        {
            sourceGeoLocation = new MEResultViewModel();
            destinationObjs = new List<MEResultViewModel>();
        }
        public MEResultViewModel sourceGeoLocation;
        public List<MEResultViewModel> destinationObjs;

    }
}
