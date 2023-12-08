using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Mappers.parameters
{
    // CustomerDbModel es la capa inferior
    // CustomerDTO
    public class CustomerMapperApplication : MapperBaseApplication<CustomerDbModel, CustomerDTO>
    {
        public override CustomerDTO MapperT1toT2(CustomerDbModel input)
        {
            return new CustomerDTO
            {
                Id = (int)input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Cellphone = input.Cellphone,    
                Email = input.Email,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDTO> MapperT1toT2(IEnumerable<CustomerDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }


        public override CustomerDbModel MapperT2toT1(CustomerDTO input)
        {
            return new CustomerDbModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Cellphone = input.Cellphone,
                Email = input.Email,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT2toT1(IEnumerable<CustomerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
