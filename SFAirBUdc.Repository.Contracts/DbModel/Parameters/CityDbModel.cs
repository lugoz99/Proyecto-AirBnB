using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.DbModel.Parameters
{
    public class CityDbModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
         public int CountryId { get; set; }

        public CountryDbModel Country { get; set; }
    }
}
