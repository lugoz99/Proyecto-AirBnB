using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Implementatios.Mappers.Parameters
{
    public class ReservationMapperRepository : BaseMapperRepository<Reservation, ReservationDbModel>
    {
        public override ReservationDbModel MapperT1toT2(Reservation input)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<ReservationDbModel> MapperT1toT2(IEnumerable<Reservation> input)
        {
            throw new NotImplementedException();
        }

        public override Reservation MapperT2toT1(ReservationDbModel input)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Reservation> MapperT2toT1(IEnumerable<ReservationDbModel> input)
        {
            throw new NotImplementedException();
        }
    }
}
