using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAirBUdc.GUI.Models.ReportModels
{
    public class CitiesByCountryReportModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CountryId { get; set; }
        public string CountryName { get; set; }
    }
}