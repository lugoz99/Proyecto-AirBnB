using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Mappers.parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementation.Implementation.Parameters;
using System.Collections.Generic;


namespace SFAirBUdc.Application.Implementation.Implementation.Parameters
{

    namespace AirbnbUdc.Application.Implementation.Implementation.Parameters
    {
        public class CountryImplementationApplication : ICountryApplication
        {
            ICountryRepository _countryRepository;

            public CountryImplementationApplication()
            {
                this._countryRepository = new CountryImplementationRepository();
            }

            public CountryDTO CreateRecord(CountryDTO record)
            {
                CountryMapperApplication mapper = new CountryMapperApplication();
                CountryDbModel mapped = mapper.MapperT2toT1(record);
                CountryDbModel created = this._countryRepository.CreateRecord(mapped);
                return mapper.MapperT1toT2(created);
            }

            public int DeleteRecord(int recordId)
            {
                int deleted = this._countryRepository.DeleteRecord(recordId);
                return deleted;
            }

            public IEnumerable<CountryDTO> GetAllRecords(string filter)
            {
                CountryMapperApplication mapper = new CountryMapperApplication();
                IEnumerable<CountryDbModel> records = this._countryRepository.GetAllRecords(filter);
                return mapper.MapperT1toT2(records);
            }

            public CountryDTO GetRecord(int recordId)
            {
                CountryMapperApplication mapper = new CountryMapperApplication();
                CountryDbModel record = this._countryRepository.GetRecord(recordId);
                return mapper.MapperT1toT2(record);
            }

            public int UpdateRecord(CountryDTO record)
            {
                CountryMapperApplication mapper = new CountryMapperApplication();
                CountryDbModel mapped = mapper.MapperT2toT1(record);
                int updated = this._countryRepository.UpdateRecord(mapped);
                return updated;
            }
        }
    }
}
