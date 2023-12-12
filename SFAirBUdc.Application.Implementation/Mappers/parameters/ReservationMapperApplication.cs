using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;

namespace SFAirBUdc.Application.Implementation.Mappers.parameters
{
    public class ReservationMapperApplication : MapperBaseApplication<ReservationDbModel, ReservationDTO>

    {
        public override ReservationDTO MapperT1toT2(ReservationDbModel input)
        {
            
            CustomerMapperApplication c = new CustomerMapperApplication();
            PropertyMapperApplication p = new PropertyMapperApplication();
            return new ReservationDTO
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                Customer = c.MapperT1toT2(input.Customer),
                Property = p.MapperT1toT2(input.Property)
            };
        }

        public override IEnumerable<ReservationDTO> MapperT1toT2(IEnumerable<ReservationDbModel> input)
        {
            IList<ReservationDTO> list = new List<ReservationDTO>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override ReservationDbModel MapperT2toT1(ReservationDTO input)
        {
            CustomerMapperApplication c = new CustomerMapperApplication();
            PropertyMapperApplication p = new PropertyMapperApplication();
            return new ReservationDbModel
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                Customer = c.MapperT2toT1(input.Customer),
                Property = p.MapperT2toT1(input.Property)
            };
        }

        public override IEnumerable<ReservationDbModel> MapperT2toT1(IEnumerable<ReservationDTO> input)
        {
            IList<ReservationDbModel> list = new List<ReservationDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }
    }
}
