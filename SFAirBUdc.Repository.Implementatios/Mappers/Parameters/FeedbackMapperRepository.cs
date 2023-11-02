using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Implementatios.Mappers.Parameters
{
    public class FeedbackMapperRepository : BaseMapperRepository<Feedback, FeedBackDbModel>
    {
        public override FeedBackDbModel MapperT1toT2(Feedback input)
        {
            ReservationMapperRepository reservationMapper = new ReservationMapperRepository();
            return new FeedBackDbModel
            {
                Id = (int)input.Id,
                CommentForCostumer = input.CommentsForCustomer,
                RateForOwner = (int)input.RateForOwner,
                CommentsForOwner = input.CommentsForCustomer,
                Reservation = reservationMapper.MapperT1toT2(input.Reservation)
            };
        }

        public override IEnumerable<FeedBackDbModel> MapperT1toT2(IEnumerable<Feedback> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override Feedback MapperT2toT1(FeedBackDbModel input)
        {
            return new Feedback
            {
                Id = (int)input.Id,
                CommentsForCustomer = input.CommentForCostumer,
                RateForCustomer = (int)input.RateForOwner,
                CommentsForOwner = input.CommentsForOwner,
                RateForOwner = (int)input.RateForOwner,
                Reservation = new ReservationMapperRepository().MapperT2toT1(input.Reservation)
            };
        }

        public override IEnumerable<Feedback> MapperT2toT1(IEnumerable<FeedBackDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
