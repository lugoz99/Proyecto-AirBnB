using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Implementatios.Mappers.Parameters
{
    public class PropertyOwnerMapperRepository : BaseMapperRepository<PropertyOwner, PropertyOwnerDbModel>
    {
        public override PropertyOwnerDbModel MapperT1toT2(PropertyOwner input)
        {
            return new PropertyOwnerDbModel
            {
                Id = (int)input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT1toT2(IEnumerable<PropertyOwner> input)
        {
            List<PropertyOwnerDbModel> list = new List<PropertyOwnerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override PropertyOwner MapperT2toT1(PropertyOwnerDbModel input)
        {
            return new PropertyOwner
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Cellphone = input.Cellphone,
                Photo = input.Photo,

            };
        }

        public override IEnumerable<PropertyOwner> MapperT2toT1(IEnumerable<PropertyOwnerDbModel> input)
        {
            List<PropertyOwner> list = new List<PropertyOwner>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
