using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyRepository
    {
        IEnumerable<PropertyDbModel> GetAllRecords(string filter);
        PropertyDbModel CreateRecord(PropertyDbModel record);
        int UpdateRecord(PropertyDbModel record);
        PropertyDbModel GetRecord(int recordId);
        int DeleteRecord(int recordId);

        IEnumerable<PropertyDbModel> GetAllRecordsByCityId(int cityId);
        IEnumerable<PropertyDbModel> GetAllRecordsByPropertyOwnerId(int propertyOwnerId);
    }
}
