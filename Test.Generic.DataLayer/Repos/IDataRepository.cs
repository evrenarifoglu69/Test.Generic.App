using System;
using System.Collections.Generic;
using System.Text;
using Test.Generic.CoreLayer.CoreModels;

namespace Test.Generic.DataLayer.Repos
{
    public interface IDataRepository
    {
        SourceData Add(SourceData data);
        SourceData Update(SourceData data);
        bool Delete(int id);
        SourceData GetById(int id);

        List<SourceData> GetAll();
    }
}
