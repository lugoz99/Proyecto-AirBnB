using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFAirBUdc.Repository.Implementatios.Mappers.Parameters
{
    public class ReservationMapperRepository : BaseMapperRepository<Reservation, ReservationDbModel>
    {
        public override ReservationDbModel MapperT1toT2(Reservation input)
        {
            PropertyMapperRepository mapper = new PropertyMapperRepository();
            CustomerMapperRepository customerMapper = new CustomerMapperRepository();
            return new ReservationDbModel
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                Property = mapper.MapperT1toT2(input.Property),
                Customer = customerMapper.MapperT1toT2(input.Customer)
            };
        }

        public override IEnumerable<ReservationDbModel> MapperT1toT2(IEnumerable<Reservation> input)
        {
            IEnumerable<ReservationDbModel> list = new List<ReservationDbModel>();
            foreach (var item in input)
            {
                list.Append(MapperT1toT2(item));
            }
            return list;
        }

        public override Reservation MapperT2toT1(ReservationDbModel input)
        {
            return new Reservation
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                PropertyId = input.Property.Id,
                CustomerId = input.Customer.Id
            };
        }

        public override IEnumerable<Reservation> MapperT2toT1(IEnumerable<ReservationDbModel> input)
        {
            // Entra un IEnumerable de ReservationDbModel y sale un IEnumerable de Reservation
            IEnumerable<Reservation> list = new List<Reservation>();
            foreach (var item in input)
            {
                list.Append(MapperT2toT1(item));
            }
            return list;
        }
    }
}
