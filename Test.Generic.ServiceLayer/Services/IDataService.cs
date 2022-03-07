using System;
using System.Collections.Generic;
using System.Text;
using Test.Generic.Public.Dtos;
using Test.Generic.Public.Models.Source;

namespace Test.Generic.ServiceLayer.Services
{
    public interface IDataService
    {
        SourceCreateResponse Add(SourceCreateRequest data);
        SourceUpdateResponse Update(SourceUpdateRequest data);
        bool Delete(int id);
        ServiceDataDto GetById(int id);

        List<ServiceDataDto> GetAll();
    }
}
