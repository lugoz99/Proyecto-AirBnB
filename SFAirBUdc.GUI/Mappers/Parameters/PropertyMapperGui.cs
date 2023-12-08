using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Mappers.Parameters;
using SFAirBUdc.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAirBUdc.GUI.Mappers
{
    public class PropertyMapperGui : MapperBaseGUI<PropertyDTO, PropertyModel>
    {
        public override PropertyModel MapperT1toT2(PropertyDTO input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new PropertyModel
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                City = cityMapper.MapperT1toT2(input.City),
                CustomerAmount = input.CustomerAmount,
                Price = input.Price,
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

        public override IEnumerable<PropertyModel> MapperT1toT2(IEnumerable<PropertyDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyDTO MapperT2toT1(PropertyModel input)
        {
            CityMapperGUI cityMapper = new CityMapperGUI();
            PropertyOwnerMapperGUI propertyOwnerMapper = new PropertyOwnerMapperGUI();
            return new PropertyDTO
            {
                Id = input.Id,
                PropertyAddress = input.PropertyAddress,
                City = cityMapper.MapperT2toT1(input.City),
                CustomerAmount = input.CustomerAmount,
                Price = input.Price,
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

        public override IEnumerable<PropertyDTO> MapperT2toT1(IEnumerable<PropertyModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}