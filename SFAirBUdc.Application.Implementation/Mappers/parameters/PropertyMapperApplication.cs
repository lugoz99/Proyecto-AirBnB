using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Mappers.parameters
{
    public class PropertyMapperApplication : MapperBaseApplication<PropertyDbModel, PropertyDTO>
    {
        public override PropertyDTO MapperT1toT2(PropertyDbModel input)
        {
            CityMapperApplication cityMapper = new CityMapperApplication();
            PropertyOwnerMapperApplication propertyOwnerMapper = new PropertyOwnerMapperApplication();
            return new PropertyDTO
            {
                Id = (int)input.Id,
                PropertyAddress = input.PropertyAddress,
                City = cityMapper.MapperT1toT2(input.City),
                CustomerAmount = input.CustomerAmount,
                Price = (double)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                PropertyOwner = propertyOwnerMapper.MapperT1toT2(input.PropertyOwner),
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService
            };
        }

        public override IEnumerable<PropertyDTO> MapperT1toT2(IEnumerable<PropertyDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyDbModel MapperT2toT1(PropertyDTO input)
        {
            CityMapperApplication cityMapper = new CityMapperApplication();
            PropertyOwnerMapperApplication propertyOwnerMapper = new PropertyOwnerMapperApplication();
            return new PropertyDbModel
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                City = cityMapper.MapperT2toT1(input.City),
                CustomerAmount = input.CustomerAmount,
                Price = (double)input.Price,
                Latitude = input.Latitude,
                Longitude = input.Longitude,
                PropertyOwner = propertyOwnerMapper.MapperT2toT1(input.PropertyOwner),
                CheckinData = input.CheckinData,
                CheckoutData = input.CheckoutData,
                Details = input.Details,
                Pets = input.Pets,
                Freezer = input.Freezer,
                LaundryService = input.LaundryService
            };
        }

        public override IEnumerable<PropertyDbModel> MapperT2toT1(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
