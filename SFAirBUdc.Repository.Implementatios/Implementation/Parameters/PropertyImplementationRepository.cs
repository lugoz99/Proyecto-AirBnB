using AirbnbUdc.Repository.Implementation.Mappers;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementation.Mappers.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using SFAirBUdc.Repository.Implementatios.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Implementatios.Implementation.Parameters
{
    public class PropertyImplementationRepository : IPropertyRepository
    {
        public PropertyDbModel CreateRecord(PropertyDbModel record)
        {
            try
            {

                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Property.Any(x => x.PropertyAddress.Equals(record.PropertyAddress)))
                    {
                        PropertyMapperRepository mapper = new PropertyMapperRepository();
                        Property dbRecord = mapper.MapperT2toT1(record);
                        db.Property.Add(dbRecord);
                        db.SaveChanges();
                        // dbRecord asignado el Id que se le asignó en la base de datos
                        record.Id = (int)dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {

                throw e;
            }
            return record;
        }

        public int DeleteRecord(int recordId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertyDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from p in db.Property
                    where p.PropertyAddress.Contains(filter)
                    select p
                    );

                PropertyMapperRepository mapper = new PropertyMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyDbModel GetRecord(int recordId)
        {
            throw new NotImplementedException();
        }

        public int UpdateRecord(PropertyDbModel record)
        {
            throw new NotImplementedException();
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
