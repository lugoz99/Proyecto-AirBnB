using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using SFAirBUdc.Repository.Implementatios.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Implementatios.Implementation.Parameters
{
    public class ReservationImplementationRepository : IReservationRepository
    {
        public ReservationDbModel CreateRecord(ReservationDbModel record)
        {
            try
            {
                using(Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Reservation.Any(x => x.Property.Id == record.Property.Id &&
                              (x.EnterDate < record.OutDate && x.OutDate > record.EnterDate)))
                    {
                        ReservationMapperRepository mapper = new ReservationMapperRepository();
                        Reservation dbRecord = mapper.MapperT2toT1(record);
                        db.Reservation.Add(dbRecord);
                        db.SaveChanges();
                        record.Id = (int)dbRecord.Id;
                    }
                }
                return record;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteRecord(int record)
        {
            using(Core_DBEntities db = new Core_DBEntities())
            {
                var dbRecord = db.Reservation.Find(record);
                if(dbRecord != null)
                {
                    db.Reservation.Remove(dbRecord);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
        }

        public IEnumerable<ReservationDbModel> GetAllRecords()
        {
            IEnumerable<ReservationDbModel> lista = new List<ReservationDbModel>();

            using (Core_DBEntities db = new Core_DBEntities())
            {
                ReservationMapperRepository mapper = new ReservationMapperRepository();

                // Verifica si hay al menos un registro en la tabla Reservation
                if (db.Reservation.Any() && db.Database.Connection != null)
                {
                    lista = db.Reservation
                        .ToList()
                        .Select(reservation => mapper.MapperT1toT2(reservation))
                        .ToList();
                }
            }

            return lista;
        }




        public ReservationDbModel GetRecord(int recordId)
        {
            using(Core_DBEntities db = new Core_DBEntities())
            {

                ReservationMapperRepository mapper = new ReservationMapperRepository();
                var record = db.Reservation.Find(recordId);
                return mapper.MapperT1toT2(record);

            }
        }

        public int UpdateRecord(ReservationDbModel record)
        {
            ReservationMapperRepository mapper = new ReservationMapperRepository();
            Reservation dbRecord = mapper.MapperT2toT1(record);
            using(Core_DBEntities db = new Core_DBEntities())
            {
                db.Reservation.Attach(dbRecord);
                db.Entry(dbRecord).State = EntityState.Modified;
                return db.SaveChanges();
            }

        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.Property
                               where p.CityId == cityId
                               select p);
                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int propertyOwnerId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from p in db.Property
                               where p.OwnerId == propertyOwnerId
                               select p);
                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }
    }
}
