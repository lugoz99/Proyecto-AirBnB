using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Implementatios.Mappers.Parameters
{
    public class CustomerMapperRepository : BaseMapperRepository<Customer, CustomerDbModel>
    {
        public override CustomerDbModel MapperT1toT2(Customer input)
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

        public override IEnumerable<CustomerDbModel> MapperT1toT2(IEnumerable<Customer> input)
        {
            List<CustomerDbModel> list = new List<CustomerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Customer MapperT2toT1(CustomerDbModel input)
        {
            return new Customer
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Cellphone = input.Cellphone,
                Photo = input.Photo,

            };
        }

        public override IEnumerable<Customer> MapperT2toT1(IEnumerable<CustomerDbModel> input)
        {
            List<Customer> list = new List<Customer>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
