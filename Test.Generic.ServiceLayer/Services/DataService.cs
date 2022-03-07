using System.Collections.Generic;
using System.Linq;
using Test.Generic.CoreLayer.CoreModels;
using Test.Generic.DataLayer.Repos;
using Test.Generic.Public.Dtos;
using Test.Generic.Public.Models.Source;

namespace Test.Generic.ServiceLayer.Services
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _dataRepository;

        public DataService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public SourceCreateResponse Add(SourceCreateRequest data)
        {
            var result = _dataRepository.Add(new SourceData()
            {
                Body = data.Body,
                Title = data.Title,
                UserId = data.UserId
            });
            return new SourceCreateResponse()
            {
                Body = result.Body,
                Id = result.Id,
                Title = result.Title,
                UserId = result.UserId
            };
        }

        public bool Delete(int id)
        {
            return _dataRepository.Delete(id);
        }

        public List<ServiceDataDto> GetAll()
        {
            var result = _dataRepository.GetAll();
            return result.Select(x=> new ServiceDataDto()
            {
                Body = x.Body,
                Id = x.Id,
                Title = x.Title,
                UserId = x.UserId
            })?.ToList();
        }

        public ServiceDataDto GetById(int id)
        {
            var result = _dataRepository.GetById(id);
            return new ServiceDataDto()
            {
                Body = result.Body,
                Id = result.Id,
                Title = result.Title,
                UserId = result.UserId
            };
        }

        public SourceUpdateResponse Update(SourceUpdateRequest data)
        {
            var result = _dataRepository.Update(new SourceData()
            {
                Body = data.Body,
                Id = data.Id,
                Title = data.Title,
                UserId = data.UserId
            });
            return new SourceUpdateResponse()
            {
                Body = result.Body,
                Id = result.Id,
                Title = result.Title,
                UserId = result.UserId
            };
        }
    }
}
