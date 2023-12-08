using SFAirBUdc.Application.Contracts.Contracts.Parameters;
using SFAirBUdc.Application.Contracts.DTO.parameters;
using SFAirBUdc.Application.Implementation.Mappers.parameters;
using SFAirBUdc.Repository.Contracts.Contracts.Parameters;
using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using SFAirBUdc.Repository.Implementatios.Implementation.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFAirBUdc.Application.Implementation.Implementation.Parameters
{
        public class PropertyImplementationApplication : IPropertyApplication
    {
            IPropertyRepository _propertyRepository;

            public PropertyImplementationApplication(IPropertyRepository propertyRepository)
            {
                _propertyRepository = propertyRepository;
            }

            public PropertyDTO CreateRecord(PropertyDTO record)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                PropertyDbModel mapped = mapper.MapperT2toT1(record);
                PropertyDbModel created = this._propertyRepository.CreateRecord(mapped);
                return mapper.MapperT1toT2(created);
            }

            public int DeleteRecord(int recordId)
            {
                int deleted = this._propertyRepository.DeleteRecord(recordId);
                return deleted;
            }

            public IEnumerable<PropertyDTO> GetAllRecords(string filter)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecords(filter);
                return mapper.MapperT1toT2(records);
            }

            public IEnumerable<PropertyDTO> GetAllRecordsByCityId(int cityId)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByCityId(cityId);
                return mapper.MapperT1toT2(records);
            }

            public IEnumerable<PropertyDTO> GetAllRecordsByPropertyOwnerId(int propertyOwnerId)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                IEnumerable<PropertyDbModel> records = this._propertyRepository.GetAllRecordsByPropertyOwnerId(propertyOwnerId);
                return mapper.MapperT1toT2(records);
            }

            public PropertyDTO GetRecord(int recordId)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                PropertyDbModel record = this._propertyRepository.GetRecord(recordId);
                return mapper.MapperT1toT2(record);
            }

            public int UpdateRecord(PropertyDTO record)
            {
                PropertyMapperApplication mapper = new PropertyMapperApplication();
                PropertyDbModel mapped = mapper.MapperT2toT1(record);
                int updated = this._propertyRepository.UpdateRecord(mapped);
                return updated;
            }
        }
    
}
