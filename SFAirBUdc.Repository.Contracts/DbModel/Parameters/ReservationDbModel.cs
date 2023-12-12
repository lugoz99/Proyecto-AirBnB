using System;

namespace SFAirBUdc.Repository.Contracts.DbModel.Parameters
{
    public class ReservationDbModel
    {
        public long Id { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OutDate { get; set; }
        public decimal Price { get; set; }

        public CustomerDbModel Customer { get; set; }

        public PropertyDbModel Property { get; set; }
    }
}
