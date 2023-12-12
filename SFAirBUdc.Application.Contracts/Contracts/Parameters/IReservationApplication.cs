using SFAirBUdc.Application.Contracts.DTO.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Contracts.Contracts.Parameters
{
    public interface IReservationApplication
    {


        ReservationDTO CreateRecord(ReservationDTO record);
        ReservationDTO GetRecord(int record);

        int UpdateRecord(ReservationDTO record);
        int DeleteRecord(int recordId);
        IEnumerable<ReservationDTO> GellAllRecord();

        
    }
}
