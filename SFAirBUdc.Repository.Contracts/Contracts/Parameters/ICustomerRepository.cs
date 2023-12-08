using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDbModel> GetAllRecords(string filter);
        CustomerDbModel CreateRecord(CustomerDbModel record);
        int UpdateRecord(CustomerDbModel record);
        CustomerDbModel GetRecord(int recordId);
        int DeleteRecord(int recordId);


    }
}
