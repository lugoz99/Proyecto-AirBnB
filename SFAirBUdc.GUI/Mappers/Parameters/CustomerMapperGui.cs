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
            throw new NotImplementedException();
        }

        public override IEnumerable<CustomerModel> MapperT1toT2(IEnumerable<CustomerDTO> input)
        {
            throw new NotImplementedException();
        }

        public override CustomerDTO MapperT2toT1(CustomerModel input)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<CustomerDTO> MapperT2toT1(IEnumerable<CustomerModel> input)
        {
            throw new NotImplementedException();
        }
    }
}