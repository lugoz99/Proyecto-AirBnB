using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAirBUdc.GUI.Mappers.Parameters
{
    public class CustomerMapperGui : MapperBaseGUI<CustomerDTO, CustomerModel>
    {
        public override CustomerModel MapperT1toT2(CustomerDTO input)
        {
            return new CustomerModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerModel> MapperT1toT2(IEnumerable<CustomerDTO> input)
        {
            IList<CustomerModel> list = new List<CustomerModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }
        public override CustomerDTO MapperT2toT1(CustomerModel input)
        {
            return new CustomerDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.Cellphone,
                Photo = input.Photo,
            };  
        }

        public override IEnumerable<CustomerDTO> MapperT2toT1(IEnumerable<CustomerModel> input)
        {
            IList<CustomerDTO> list = new List<CustomerDTO>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}