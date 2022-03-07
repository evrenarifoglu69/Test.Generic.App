using System.Collections.Generic;

namespace Test.Generic.App.Models
{
    public class ViewDataModel
    {
        public List<DataModel> ListData { get; set; }

        public DataModel Detail { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; }
    }

    public class DataModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }
}