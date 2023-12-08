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
    public class PropertyOwnerImplementationRepository : IPropertyOwnerRepository
    {
        public PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.PropertyOwner.Any(x => x.Email.Equals(record.Email)))
                    {
                        PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                        PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                        db.PropertyOwner.Add(dbRecord);
                        db.SaveChanges();
                        // Se asigna el Id que se le asignó en la base de datos
                        record.Id = (int)dbRecord.Id;
                    }
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            return record;
        }

        public int DeleteRecord(int recordId)
        {
            using( Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyOwner.Find(recordId);
                if ( record != null)
                {
                    db.PropertyOwner.Remove(record);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }   
        }

        public IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from po in db.PropertyOwner
                    where po.FirstName.Contains(filter)
                    select po
                    );
                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyOwnerDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyOwner.Find(recordId);

                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        public int UpdateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                    PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                    db.PropertyOwner.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
