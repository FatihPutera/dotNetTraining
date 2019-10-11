using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LatihanASP.EntityFramworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LatihanASP.ViewModels;


namespace LatihanASP.ViewModels
{
    public class RegionViewModel
    {
        public int RegionID { get; set; }

        public string RegionName { get; set; }

        public string RegionLongitude { get; set; }

        public string RegionLatitude { get; set; }

        public string Country { get; set; }

        public RegionViewModel()
        {

        }

        public RegionViewModel(Region item)
        {

            string tem = item.RegionDescription;
            RegionID = item.RegionID;

            if (tem.Contains("|"))
            {
                var data = tem.Split('|');
                RegionName = data[0];
                RegionLongitude = data[1];
                RegionLatitude = data[2];
                Country = data[3].Trim();
            }
            else
            {
                RegionName = item.RegionDescription.Trim();
                RegionLongitude = null;
                RegionLatitude = null;
                Country = null;
            }

        }


    }
}