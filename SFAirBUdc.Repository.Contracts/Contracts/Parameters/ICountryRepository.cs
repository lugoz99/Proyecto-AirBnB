using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface ICountryRepository
    {
        // Se define las operaciones CRUD
        CountryDbModel CreateRecord(CountryDbModel record);

        int DeleteRecord(int recorId);

        int UpdateRecord(CountryDbModel record);

        CountryDbModel GetRecord(int recorId);

        IEnumerable<CountryDbModel> GetAllRecords(string filter);
    }
}
