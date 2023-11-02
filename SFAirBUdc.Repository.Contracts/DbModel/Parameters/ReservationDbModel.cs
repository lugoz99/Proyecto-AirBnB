using System;

namespace SFAirBUdc.Repository.Contracts.DbModel.Parameters
{
    public class ReservationDbModel
    {
        public int Id { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OudDate { get; set; }

        public float Price { get; set; }

        public int PropertyId { get; set; }

        public int CustomerId { get; set; }

        //public PropertyDbModel {get;set;}
        //public CustomerDbModel {get;set;}
    }
}
