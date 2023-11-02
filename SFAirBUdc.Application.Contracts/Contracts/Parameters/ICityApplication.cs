using SFAirBUdc.Application.Contracts.DTO.parameters;
using System.Collections.Generic;

namespace SFAirBUdc.Application.Contracts.Contracts.Parameters
{
    public interface ICityApplication
    {
        CityDTO CreateRecord(CityDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CityDTO record);
        CityDTO GetRecord(int recordId);
        IEnumerable<CityDTO> GetAllRecords(string filter);
        IEnumerable<CityDTO> GetAllRecordsByCountryId(int countryId);
    }

}
