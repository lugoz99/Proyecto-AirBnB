using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerRepository
    {
        IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter);
        PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record);
        int UpdateRecord(PropertyOwnerDbModel record);
        PropertyOwnerDbModel GetRecord(int recordId);
        int DeleteRecord(int recordId);
    }
}
