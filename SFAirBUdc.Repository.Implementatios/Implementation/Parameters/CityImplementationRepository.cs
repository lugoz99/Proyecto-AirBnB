using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementation.Mappers.Parameters;
using SFAirBUdc.Repository.Implementatios.DataModel;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace SFAirBUdc.Repository.Implementation.Implementation.Parameters
{
    public class CityImplementationRepository : ICityRepository
    {
        /// <summary>
        /// Método para crear un registro de City en la base de datos
        /// </summary>
        /// <param name="record">Registro a guardar</param>
        /// <returns>El registro guardado con id cuando se guarda o sin Id cuando no. O una excepción</returns>
        public CityDbModel CreateRecord(CityDbModel record)
        {
            Debug.WriteLine($"metodo crear ciurdad: {record.Id}, Name: {record.Name}");

            try
            {
                Debug.WriteLine($"metodo crear ciurdad: {record.Id}, Name: {record.Name}");

                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.City.Any(x => x.CityName.Equals(record.Name)))
                    {
                        Debug.WriteLine($"Id: {record.Id}, Name: {record.Name}");
                        CityMapperRepository mapper = new CityMapperRepository();
                        City dbRecord = mapper.MapperT2toT1(record);
                        db.City.Add(dbRecord);
                        db.SaveChanges();
                        // dbRecord asignado el Id que se le asignó en la base de datos
                        record.Id = dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {
                Debug.WriteLine($"metodo crear ciurdad exepcion : {record.Id}, Name: {record.Name}");

                throw e;
            }
            return record;
        }


        /// <summary>
        /// Método para eliminar un registro de City en la base de datos
        /// </summary>
        /// <param name="recordId">Id del registro a eliminar</param>
        /// <returns>1 cuando se elimina, 0 cuando no existe, o excepción</returns>
        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    City record = db.City.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.City.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                // porque se tiene como llave foránea en otra tabla
                throw e;
            }
        }

        /// <summary>
        /// Método para obtener todos los registros de City en la base de datos
        /// </summary>
        /// <returns>Listado de registros con países</returns>
        public IEnumerable<CityDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.City
                    where c.CityName.Contains(filter)
                    select c
                );

                CityMapperRepository mapper = new CityMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }


        /// <summary>
        /// Método para obtener todos los registros de City en la base de datos por Id de país
        /// </summary>
        /// <param name="countryId">Id del país</param>
        /// <returns>Lista de ciudades</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<CityDbModel> GetAllRecordsByCountryId(int countryId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (from c in db.City
                               where c.CountryId == countryId
                               select c);
                CityMapperRepository mapper = new CityMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public CityDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.City.Find(recordId);

                CityMapperRepository mapper = new CityMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        /// <summary>
        /// Método para actualizar un registro de City en la base de datos
        /// </summary>
        /// <param name="record">Registro con nuevos datos</param>
        /// <returns>1 cuando se actualiza, 0 cuando no se actualiza o una excepciòn</returns>
        public int UpdateRecord(CityDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    CityMapperRepository mapper = new CityMapperRepository();
                    City dbRecord = mapper.MapperT2toT1(record);
                    db.City.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    // TODO : Aqui es db.SaveChanges o return 1 si se actualizo o cero si no
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