using SFAirBUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace SFAirBUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IFeedBackRepository
    {
        FeedBackDbModel CreateRecord(FeedBackDbModel record);

        int DeleteRecord(int recorId);

        int UpdateRecord(FeedBackDbModel record);

        FeedBackDbModel GetRecord(int recordId);

        IEnumerable<FeedBackDbModel> GetAllRecords(string filter);


    }
}
