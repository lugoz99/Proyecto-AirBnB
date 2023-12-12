using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Mappers.parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Implementation.Parameters
{
    public class ReservationImplementationApplication : IReservationApplication
    {
        IReservationRepository _app;
        ReservationMapperApplication mapper = new ReservationMapperApplication();
        public ReservationImplementationApplication(IReservationRepository app)
        {
            this._app = app;   
        }
        public ReservationDTO CreateRecord(ReservationDTO record)
        {
            ReservationDbModel reservationDbModel = mapper.MapperT2toT1(record);
            ReservationDbModel created = this._app.CreateRecord(reservationDbModel);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._app.DeleteRecord(recordId); 
            return deleted;
        }

        public IEnumerable<ReservationDTO> GellAllRecord()
        {
            IEnumerable<ReservationDbModel> records = this._app.GetAllRecords();
            return mapper.MapperT1toT2(records);
        }

        public ReservationDTO GetRecord(int record)
        {
            ReservationDbModel reservation = this._app.GetRecord(record);
            return mapper.MapperT1toT2(reservation);  
        }

        public int UpdateRecord(ReservationDTO record)
        {
            ReservationDbModel reservationDbModel = mapper.MapperT2toT1(record);
            int updated = this._app.UpdateRecord(reservationDbModel);
            return updated;
        }

        
    }
}
