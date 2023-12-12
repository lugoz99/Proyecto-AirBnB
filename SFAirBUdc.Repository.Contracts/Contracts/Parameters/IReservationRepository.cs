using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IReservationRepository
    {
        ReservationDbModel CreateRecord(ReservationDbModel record);
        IEnumerable<ReservationDbModel> GetAllRecords();

        ReservationDbModel GetRecord(int recordId);
        int UpdateRecord(ReservationDbModel record);
        int DeleteRecord(int record);



    }
}
