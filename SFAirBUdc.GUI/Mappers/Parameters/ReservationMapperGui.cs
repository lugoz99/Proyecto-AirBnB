using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.GUI.Models.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SFAirBUdc.GUI.Mappers.Parameters
{
    public class ReservationMapperGui : MapperBaseGUI<ReservationDTO, ReservationModel>
    {
        public override ReservationModel MapperT1toT2(ReservationDTO input)
        {
            return new ReservationModel
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                Property = new PropertyMapperGui().MapperT1toT2(input.Property),
                Customer = new CustomerMapperGui().MapperT1toT2(input.Customer)
            };
        }

        public override IEnumerable<ReservationModel> MapperT1toT2(IEnumerable<ReservationDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override ReservationDTO MapperT2toT1(ReservationModel input)
        {
            return new ReservationDTO
            {
                Id = input.Id,
                EnterDate = input.EnterDate,
                OutDate = input.OutDate,
                Price = input.Price,
                Property = new PropertyMapperGui().MapperT2toT1(input.Property),
                Customer = new CustomerMapperGui().MapperT2toT1(input.Customer)
            };
        }

        public override IEnumerable<ReservationDTO> MapperT2toT1(IEnumerable<ReservationModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}