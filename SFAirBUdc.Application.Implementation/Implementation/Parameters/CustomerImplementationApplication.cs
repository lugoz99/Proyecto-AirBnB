using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Mappers.parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementation.Mappers.Parameters;
using SFAirBUdc.Repository.Implementatios.Mappers.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Implementation.Parameters
{
    public class CustomerImplementationApplication : ICustomerApplication
    {
        ICustomerRepository _customerApplication;
        public CustomerImplementationApplication(ICustomerRepository customer)
        {
            this._customerApplication = customer;
        }

        public CustomerDTO CreateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            CustomerDbModel created = this._customerApplication.CreateRecord(mapped);
            return record;
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._customerApplication.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<CustomerDTO> GetAllRecords(string filter)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            IEnumerable<CustomerDbModel> records = this._customerApplication.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);

        }

        public CustomerDTO GetRecord(int recordId)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel record = this._customerApplication.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._customerApplication.UpdateRecord(mapped);
            return updated;

        }
    }
}
