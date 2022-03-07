using Newtonsoft.Json;
using System.Collections.Generic;
using Test.Generic.CoreLayer.CoreModels;
using Test.Generic.Shared.Helper;

namespace Test.Generic.DataLayer.Repos
{
    public class DataRepository : IDataRepository
    {

        public SourceData Add(SourceData data)
        {
            var restClient = new RestSharp.RestClient(StaticValues.EndUrl);
            var request = new RestSharp.RestRequest("", RestSharp.Method.POST);
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            request.AddJsonBody(new
            {
                title = data.Title,
                body = data.Body,
                userId = data.UserId
            });

            var res = restClient.Execute(request);
            var dataResponse = JsonConvert.DeserializeObject<SourceData>(res.Content);
            return dataResponse;
        }

        public bool Delete(int id)
        {
            var restClient = new RestSharp.RestClient(StaticValues.EndUrl);
            var request = new RestSharp.RestRequest($"/{id}", RestSharp.Method.DELETE);
            //request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            //request.AddJsonBody(new
            //{
            //    title = data.Title,
            //    body = data.Body,
            //    userId = data.UserId
            //});

            var res = restClient.Execute(request);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            return false;
        }

        public List<SourceData> GetAll()
        {
            var restClient = new RestSharp.RestClient(StaticValues.EndUrl);
            var request = new RestSharp.RestRequest($"", RestSharp.Method.GET);
            //request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            //request.AddJsonBody(new
            //{
            //    title = data.Title,
            //    body = data.Body,
            //    userId = data.UserId
            //});

            var res = restClient.Execute(request);
            //if (res.StatusCode == System.Net.HttpStatusCode.OK)
            var dataResponse = JsonConvert.DeserializeObject<List<SourceData>>(res.Content);
            return dataResponse;
        }

        public SourceData GetById(int id)
        {
            var restClient = new RestSharp.RestClient(StaticValues.EndUrl);
            var request = new RestSharp.RestRequest($"/{id}", RestSharp.Method.GET);
            //request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            //request.AddJsonBody(new
            //{
            //    title = data.Title,
            //    body = data.Body,
            //    userId = data.UserId
            //});

            var res = restClient.Execute(request);
            //if (res.StatusCode == System.Net.HttpStatusCode.OK)
            var dataResponse = JsonConvert.DeserializeObject<SourceData>(res.Content);
            return dataResponse;
        }

        public SourceData Update(SourceData data)
        {
            var restClient = new RestSharp.RestClient(StaticValues.EndUrl);
            var request = new RestSharp.RestRequest($"/{data.Id}", RestSharp.Method.PUT);
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");
            request.AddJsonBody(new
            {
                title = data.Title,
                body = data.Body,
                userId = data.UserId,
                id = data.Id
            });

            var res = restClient.Execute(request);
            var dataResponse = JsonConvert.DeserializeObject<SourceData>(res.Content);
            return dataResponse;
        }
    }
}
