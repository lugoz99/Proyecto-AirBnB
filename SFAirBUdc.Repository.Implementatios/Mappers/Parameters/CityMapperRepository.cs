using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Implementation.Mappers.Parameters
{
    public class CityMapperRepository : BaseMapperRepository<City, CityDbModel>
    {
        public override CityDbModel MapperT1toT2(City input)
        {
            CountryMapperRepository countryMapper = new CountryMapperRepository();
            return new CityDbModel
            {
                Id = input.Id,
                Name = input.CityName,
                Country = countryMapper.MapperT1toT2(input.Country)
            };
        }

        
        public override IEnumerable<CityDbModel> MapperT1toT2(IEnumerable<City> input)
        {
            IList<CityDbModel> list = new List<CityDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        //public override IEnumerable<CityDbModel> MapperT1toT2(IEnumerable<City> input)
        //{
        //    foreach (var item in input)
        //    {
        //        yield return MapperT1toT2(item);
        //    }
        //}

        public override City MapperT2toT1(CityDbModel input)
        {
            return new City
            {
                Id = input.Id,
                CityName = input.Name,
                Country = new CountryMapperRepository().MapperT2toT1(input.Country)
            };
        }


        public override IEnumerable<City> MapperT2toT1(IEnumerable<CityDbModel> input)
        {
            IList<City> list = new List<City>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }

    }
}