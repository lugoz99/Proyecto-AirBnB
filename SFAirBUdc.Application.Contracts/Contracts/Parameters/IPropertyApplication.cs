using SFAirBUdc.Application.Contracts.DTO.parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyApplication
    {
        PropertyDTO CreateRecord(PropertyDTO record);
        int DeleteRecord(int recordId);

        int UpdateRecord(PropertyDTO record);

        PropertyDTO GetRecord(int recordId);

        IEnumerable<PropertyDTO> GetAllRecords(string filter);

        IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(int propertyOwnerId);
    }
}
