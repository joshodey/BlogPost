using System.Data;
using System.Net;
using System.Text.Json;

namespace BlogBlazor.entities
{
    public class ApiResponse
    {
        public List<data> Data { get; set; }
    }

    public class data
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

    