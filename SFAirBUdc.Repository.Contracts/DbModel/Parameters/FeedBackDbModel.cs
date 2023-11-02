namespace SFAirBUdc.Repository.Contracts.DbModel.Parameters
{
    public class FeedBackDbModel
    {
        public int Id { get; set; }
        public int RateForOwner { get; set; }

        public string CommentsForOwner { get; set; }

        public string CommentForCostumer { get; set; }

        public int ReservationId { get; set; }

        public ReservationDbModel Reservation { get; set; }


    }
}
