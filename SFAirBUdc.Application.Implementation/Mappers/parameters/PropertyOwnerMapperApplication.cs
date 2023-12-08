using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Mappers.parameters
{
    public class PropertyOwnerMapperApplication : MapperBaseApplication<PropertyOwnerDbModel, PropertyOwnerDTO>
    {
        public override PropertyOwnerDTO MapperT1toT2(PropertyOwnerDbModel input)
        {
            return new PropertyOwnerDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDTO> MapperT1toT2(IEnumerable<PropertyOwnerDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyOwnerDbModel MapperT2toT1(PropertyOwnerDTO input)
        {
            return new PropertyOwnerDbModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT2toT1(IEnumerable<PropertyOwnerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
