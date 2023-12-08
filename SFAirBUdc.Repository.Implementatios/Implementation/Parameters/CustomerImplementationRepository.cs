using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using SFAirBUdc.Repository.Implementatios.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace SFAirBUdc.Repository.Implementatios.Implementation.Parameters
{
    public class CustomerImplementationRepository : ICustomerRepository
    {
        public CustomerDbModel CreateRecord(CustomerDbModel record)
        {
            try
            {
                using(Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Customer.Any( x => x.Email.Equals(record.Email)))
                    {
                        CustomerMapperRepository mapper = new CustomerMapperRepository();
                        // Se mapea un CustomerDbModel a un Customer
                        Customer dbRecord = mapper.MapperT2toT1(record);
                        db.Customer.Add(dbRecord);
                        db.SaveChanges();
                        // Se asigna el Id que se le asignó en la base de datos
                        record.Id = dbRecord.Id;    
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
            try
            {
                using(Core_DBEntities db = new Core_DBEntities())
                {
                    Customer record = db.Customer.Find(recordId);
                    if (record != null)
                    {
                        db.Customer.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CustomerDbModel> GetAllRecords(string filter)
        {
            // TODO : Aqui es db.SaveChanges o return 1 si se actualizo o cero si no
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    var records = (
                        from po in db.Customer
                        where po.FirstName.Contains(filter)
                        select po
                        );
                    CustomerMapperRepository mapper = new CustomerMapperRepository();
                    return mapper.MapperT1toT2(records);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public CustomerDbModel GetRecord(int recordId)
        {
            try
            {
                using(Core_DBEntities db = new Core_DBEntities())
                {
                    CustomerMapperRepository mapper = new CustomerMapperRepository();
                    Customer record = db.Customer.Find(recordId);
                    return mapper.MapperT1toT2(record);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int UpdateRecord(CustomerDbModel record)
        {
            try
            {
                using( Core_DBEntities db = new Core_DBEntities())
                {
                    CustomerMapperRepository mapper = new CustomerMapperRepository();
                    Customer dbRecord = mapper.MapperT2toT1(record);
                    db.Customer.Attach(dbRecord);
                    // Con entry 
                    db.Entry(dbRecord).State = EntityState.Modified;
                    // se devuelve el número de registros afectados
                    return db.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
